# File Scanner Project (Distributed Systems)
## Project Summary
In this project, I made 3 separate C# console applications that work together to scan text files and count words

## What Each Part Does

### ScannerA
- Reads `.txt` files from a folder
- Counts how many times each word appears
- Sends that data to the Master using a pipe called `agent1`

### ScannerB
- Same as ScannerA but works on another folder.
- Sends data to Master through a different pipe `agent2`

### Master
- Waits for both Scanners to send their data
- Takes the word counts from both, combines them
- Shows the final word count results on the screen

## Example Output

Data received from agent1.  
Data received from agent2.  

--- Merged Word Count Results ---  
textA.txt:all:1
textB.txt:summer:1
textB.txt:your:1
textA.txt:i:1
textA.txt:well:1
textA.txt:hello:1
textA.txt:doing:1
textA.txt:everyone:1
textA.txt:are:1
textB.txt:vacation:1
textB.txt:enjoy:1
textA.txt:hope:1

## How I Built and Ran It

1. I used Visual studio to write all code  (ScannerA, ScannerB, Master)  
2. I opened 3 different seperate  terminals:  
   - First, I ran the ScannerA  
   - Then I ran ScannerB  
   - Finally, I ran master

3. I passed the folder paths and pipe names as arguments like this:  

master-
cd C:\Users\Surface\FileScannerSystem\Master\bin\Debug\net8.0
dotnet Master.dll agent1 agent2

scannerA-
cd C:\Users\Surface\FileScannerSystem\ScannerA\bin\Debug\net8.0
dotnet ScannerA.dll C:\Users\Surface\FileScannerSystem\textsA

scannerB-
cd C:\Users\Surface\FileScannerSystem\ScannerB\bin\Debug\net8.0
dotnet ScannerB.dll C:\Users\Surface\FileScannerSystem\textsB


## Files in My Project

- ScannerA/Program.cs / ScannerA.csproj  
- ScannerB/Program.cs / ScannerB.csproj  
- Master/Program.cs/master.csproj  
- WordCount.cs  
- testsA/testA.txt  
- testsB/testB.txt  
- testing report.pdf
- UML Diagram.pdf
