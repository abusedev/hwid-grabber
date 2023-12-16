﻿using System;
using System.Windows.Forms;
using abuse.handler;
using System.Threading;

namespace abuse
{
    internal class Program
    {
        static Thread thread = new Thread((ThreadStart)(() => 
        {
            try
            {
                string hwid = $"{hardwareIdentification.cpuId()} - {hardwareIdentification.diskId()} - {hardwareIdentification.biosId()} - {hardwareIdentification.videoId()}";
                Clipboard.SetText(hwid);
                Console.Clear();
                Console.WriteLine($"HWID: {hwid}");
                consoleManager.centerText("Copied HWID to clipboard");
                consoleManager.keepOpen();
            }
            catch (Exception ex)
            {
                consoleManager.centerText($"Error grabbing HWID. Error: {ex.Message}");
                consoleManager.keepOpen();
                Clipboard.SetText(ex.Message);
            }
        }));
        
        static void Main(string[] args)
        {
            consoleManager.moveWindowToCenter();
            Console.Title = "@buse whitelister"; 
            consoleManager.centerText("Grabbing HWID");
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }
    }
}