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
using InventorApi;

var builder = new ShelfBuilder();
var apiService = new InventorWrapper();
var shelfParameters = new ShelfParameters();
var streamWriter = new StreamWriter($"log{apiService}.txt", true);

long peakPagedMem = 0,
    peakWorkingSet = 0,
    peakVirtualMem = 0,
    countDetal = 1;
builder.BuildShelf(shelfParameters, apiService);

using (Process myProcess = Process.GetProcessesByName("Inventor").FirstOrDefault())
{
   
    do
    {
        if (!myProcess.HasExited)
        {
            builder.BuildShelf(shelfParameters, apiService);
            countDetal++;
            myProcess.Refresh();
            Console.WriteLine();
            Console.WriteLine($"{myProcess} -");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"  Количество деталей        : {countDetal}");
            Console.WriteLine($"  Physical memory usage     : {myProcess.WorkingSet64}");
            Console.WriteLine($"  Base priority             : {myProcess.BasePriority}");
            Console.WriteLine($"  Priority class            : {myProcess.PriorityClass}");
            Console.WriteLine($"  User processor time       : {myProcess.UserProcessorTime}");
            Console.WriteLine($"  Privileged processor time : {myProcess.PrivilegedProcessorTime}");
            Console.WriteLine($"  Total processor time      : {myProcess.TotalProcessorTime}");
            Console.WriteLine($"  Paged system memory size  : {myProcess.PagedSystemMemorySize64}");
            Console.WriteLine($"  Paged memory size         : {myProcess.PagedMemorySize64}");
            streamWriter.WriteLine($"{countDetal} {myProcess.WorkingSet64} {myProcess.UserProcessorTime}");
            streamWriter.Flush();
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
    while (countDetal != 200);

    Console.WriteLine();
    Console.WriteLine($"  Process exit code          : {myProcess.ExitCode}");

    Console.WriteLine($"  Peak physical memory usage : {peakWorkingSet}");
    Console.WriteLine($"  Peak paged memory usage    : {peakPagedMem}");
    Console.WriteLine($"  Peak virtual memory usage  : {peakVirtualMem}");
}
