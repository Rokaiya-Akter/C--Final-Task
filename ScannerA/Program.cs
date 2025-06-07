// === ScannerA/Program.cs ===
using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic; 


class ScannerA
{
    static void Main(string[] args)
    {
        Process.GetCurrentProcess().ProcessorAffinity = (IntPtr)(1 << 0); // CPU Core 0
        Console.WriteLine("[ScannerA] Started on CPU Core 0");

        string directory = args.Length > 0 ? args[0] : "./textsA";
        string pipeName = "agent1";

        Thread worker = new Thread(() => ScanAndSend(directory, pipeName));
        worker.Start();
    }

    static void ScanAndSend(string dir, string pipeName)
    {
        using var pipe = new NamedPipeClientStream(".", pipeName, PipeDirection.Out);
        pipe.Connect();
        using var writer = new StreamWriter(pipe, Encoding.UTF8) { AutoFlush = true };

        foreach (var file in Directory.GetFiles(dir, "*.txt"))
        {
            var wordCounts = new Dictionary<string, int>();
            var words = File.ReadAllText(file).Split(new[] { ' ', '\n', '\r', '.', ',', ';', '!' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                var w = word.ToLower();
                if (!wordCounts.ContainsKey(w)) wordCounts[w] = 0;
                wordCounts[w]++;
            }
            foreach (var kvp in wordCounts)
            {
                writer.WriteLine($"{Path.GetFileName(file)}:{kvp.Key}:{kvp.Value}");
            }
        }
    }
}

