## Project Objective

This project implements a distributed system in C# using console applications. It consists of two agent programs (ScannerA and ScannerB) and a master program. The system is designed to:

- Read and process .txt files in parallel
- Send indexed word data from agents to the master using named pipes
- Aggregate and display final word frequency or word sequence data

---

## System Components

1. **ScannerA (Agent A)**
   - Scans .txt files from a folder named `textsA`
   - Extracts words and calculates either frequency or sequence
   - Sends data to the master using pipe named `agent1`

2. **ScannerB (Agent B)**
   - Scans .txt files from folder `textsB`
   - Sends processed word data to the master via pipe `agent2`

3. **Master Process**
   - Waits for connections on pipes `agent1` and `agent2`
   - Receives and merges data from both agents
   - Displays final aggregated word counts or ordered word lists

---

## Technologies Used

- Language: C#
- Platform: .NET 8.0 SDK + Runtime
- Communication: Named Pipes (`NamedPipeClientStream`, `NamedPipeServerStream`)
- Multithreading: Background threads for processing and communication
- CPU Affinity: Manually set for each executable to run on separate cores

---

## How to Run

1. **Prerequisites:**
   - Install .NET 8.0 SDK
   - Ensure folders `textsA` and `textsB` exist and contain .txt files

2. **Build:**
   - Open the solution in Visual Studio or use `dotnet build` from terminal

3. **Run Master:**
dotnet run --project Master agent1 agent2


4. **Run ScannerA and ScannerB (in separate terminals):**
dotnet run --project ScannerA textsA
dotnet run --project ScannerB textsB



## Sample Output

textsA/file1.txt: hello: 3
textsB/file2.txt: world: 5


or (in sequence mode):
textsA/file1.txt: hello -> world -> test


## Multithreading Design

- Each scanner:
  - Thread 1: Reads and indexes files
  - Thread 2: Sends data to master
- Master:
  - One thread per pipe to process data concurrently

---

## CPU Affinity

Each application is assigned a unique CPU core using the `ProcessorAffinity` property for better parallel performance.

---

## Challenges & Fixes

| Problem                      | Solution                                |
|-----------------------------|------------------------------------------|
| .NET 6 Runtime not found     | Upgraded to .NET 8                      |
| DirectoryNotFoundException  | Created missing `textsA` and `textsB`   |
| Unordered output            | Adjusted logic to maintain sequence     |

---

## Test Environment

- OS: Windows 10 (x64)
- Language: C#
- IDE: Notepad / Visual Studio
- .NET SDK: 8.0
- Communication: Named Pipes
- Output View: Console

---

## Conclusion

- ✔️ Agents scan and send file data in parallel
- ✔️ Master process merges data correctly
- ✔️ Communication via named pipes is reliable and efficient
- ✔️ Gained hands-on experience with multithreading, IPC, and CPU affinity in C#

---

## License

This project is submitted for academic purposes and is not intended for production use.
