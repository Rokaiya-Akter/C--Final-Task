// === Master/Program.cs ===
using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;
using System.Collections.Concurrent;
using System.Diagnostics;


class Master
{
    static ConcurrentDictionary<string, int> index = new();

    static void Main(string[] args)
    {
        Process.GetCurrentProcess().ProcessorAffinity = (IntPtr)(1 << 2); // CPU Core 2
        Console.WriteLine("[Master] Started on CPU Core 2");

        string pipe1 = args.Length > 0 ? args[0] : "agent1";
        string pipe2 = args.Length > 1 ? args[1] : "agent2";

        Thread t1 = new(() => ListenPipe(pipe1));
        Thread t2 = new(() => ListenPipe(pipe2));

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        Console.WriteLine("\n=== Final Aggregated Index ===");
        foreach (var kvp in index)
        {
            Console.WriteLine(kvp.Key + ":" + kvp.Value);
        }
    }

    static void ListenPipe(string pipeName)
    {
        using var pipe = new NamedPipeServerStream(pipeName, PipeDirection.In);
        pipe.WaitForConnection();
        using var reader = new StreamReader(pipe, Encoding.UTF8);

        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            if (line == null) continue;
            var parts = line.Split(':');
            if (parts.Length != 3) continue;
            string key = parts[0] + ":" + parts[1];
            int value = int.Parse(parts[2]);
            index.AddOrUpdate(key, value, (k, old) => old + value);
        }
    }
}
