// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using Buidler;
using Core;
using KompasApi;
using Services;
using System;
using System.IO;
using System.Globalization;
using System.Xml.Linq;

Console.WriteLine("Hello, World!");
var builder = new ShelfBuilder();
var stopWatch = new Stopwatch();
var apiService = new KompasWrapper();
stopWatch.Start();
var shelfParameters = new ShelfParameters();
var streamWriter = new StreamWriter($"log{apiService}.txt", true);
var process = Process.GetCurrentProcess();


// Define variables to track the peak
// memory usage of the process.
long peakPagedMem = 0,
    peakWorkingSet = 0,
    peakVirtualMem = 0;
// Start the process.
using (Process myProcess = Process.GetCurrentProcess())
{
    // Display the process statistics until
    // the user closes the program.
    do
    {
        if (!myProcess.HasExited)
        {
            builder.BuildShelf(shelfParameters, apiService);
            // Refresh the current process property values.
            myProcess.Refresh();

            Console.WriteLine();

            // Display current process statistics.

            Console.WriteLine($"{myProcess} -");
            Console.WriteLine("-------------------------------------");

            Console.WriteLine($"  Physical memory usage     : {myProcess.WorkingSet64}");
            Console.WriteLine($"  Base priority             : {myProcess.BasePriority}");
            Console.WriteLine($"  Priority class            : {myProcess.PriorityClass}");
            Console.WriteLine($"  User processor time       : {myProcess.UserProcessorTime}");
            Console.WriteLine($"  Privileged processor time : {myProcess.PrivilegedProcessorTime}");
            Console.WriteLine($"  Total processor time      : {myProcess.TotalProcessorTime}");
            Console.WriteLine($"  Paged system memory size  : {myProcess.PagedSystemMemorySize64}");
            Console.WriteLine($"  Paged memory size         : {myProcess.PagedMemorySize64}");

            // Update the values for the overall peak memory statistics.
            peakPagedMem = myProcess.PeakPagedMemorySize64;
            peakVirtualMem = myProcess.PeakVirtualMemorySize64;
            peakWorkingSet = myProcess.PeakWorkingSet64;

            if (myProcess.Responding)
            {
                Console.WriteLine("Status = Running");
            }
            else
            {
                Console.WriteLine("Status = Not Responding");
            }
        }
    }
    while (!myProcess.WaitForExit(1000));

    Console.WriteLine();
    Console.WriteLine($"  Process exit code          : {myProcess.ExitCode}");

    // Display peak memory statistics for the process.
    Console.WriteLine($"  Peak physical memory usage : {peakWorkingSet}");
    Console.WriteLine($"  Peak paged memory usage    : {peakPagedMem}");
    Console.WriteLine($"  Peak virtual memory usage  : {peakVirtualMem}");
}
