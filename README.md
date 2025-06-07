# 🧠 C# Final Project: Distributed File Indexing System

## 📚 Course
**Object-Oriented Programming**

## 👩‍💻 Developed By
**Rokaiya Akter**  
Sub-Group: 1

## 👨‍🏫 Supervisor
**Donatas Dervinis, Assist. Prof., Dr.**



## 🎯 Objective

This project demonstrates a distributed file indexing system using C#. It features:

- **Two scanner agents** (`ScannerA` and `ScannerB`) that independently scan text files and extract word information.
- **One master process** that collects and displays the indexed data received from both agents via **named pipes**.

---

## 🧱 System Components

### 🔹 ScannerA (Agent A)
- Scans `.txt` files from the folder `textsA`.
- Extracts word data (count or sequence).
- Sends data to the master using pipe: `agent1`.

### 🔹 ScannerB (Agent B)
- Scans `.txt` files from the folder `textsB`.
- Sends processed data via pipe: `agent2`.

### 🔹 Master Process
- Waits for connections from both agents.
- Receives and processes incoming word data.
- Aggregates and displays results:
  - Total word counts **or**
  - Ordered word sequences (based on configuration).

---

## 🧪 Test Environment

| Component         | Details                  |
|------------------|--------------------------|
| OS               | Windows 10 (x64)         |
| .NET Version     | .NET 8.0 SDK + Runtime   |
| Language         | C#                       |
| Text Editor      | Notepad                  |
| Communication    | Named Pipes              |
| Multithreading   | Each app uses background threads |
| CPU Affinity     | Set using `ProcessorAffinity` |

---

 Multithreading Design
Scanners:

One thread for reading files

One thread for sending data to master

Master:

Separate thread for each named pipe connection

Concurrent data aggregation

🔧 Challenges & Solutions
Problem	Solution
.NET 6 missing	Upgraded to .NET 8
DirectoryNotFoundException	Created textsA and textsB folders
Unordered Output	Improved data sending logic for sequence

