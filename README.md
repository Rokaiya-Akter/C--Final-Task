# 📁 File Indexing System with C# Agents and Master

## 🔍 Overview

This project is a distributed word indexing system built with C#. It consists of three console applications:

- **Scanner A (Agent 1)**
- **Scanner B (Agent 2)**
- **Master Process**

The scanners analyze `.txt` files and send word counts to the master process via named pipes. The master aggregates and displays the results.

---

## 🚀 Getting Started

### 🧱 Prerequisites

- .NET 6 SDK or higher
- Windows OS (for Named Pipes and Processor Affinity support)
- Visual Studio 2022 or newer (recommended)

---

## 🛠️ Build Instructions

1. Open the solution in Visual Studio or compile each project using the `dotnet` CLI:
   ```bash
   dotnet build ScannerA/ScannerA.csproj
   dotnet build ScannerB/ScannerB.csproj
   dotnet build Master/Master.csproj
  
  

🧵 Multithreading
Agents use multiple threads:

One for reading files

One for sending data via named pipes

Master uses multiple threads to handle simultaneous pipe connections and process incoming data.

⚙️ CPU Affinity
Each component is assigned a specific CPU core using Process.ProcessorAffinity to improve parallel performance.
