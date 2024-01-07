using System;
using System.Windows.Forms;
using abuse.handler;
using System.Threading;
using libc.hwid;

namespace abuse
{
    internal class Program
    {
        public static string hwidType;
        static Thread thread = new Thread((ThreadStart)(() => 
        {
            if (hwidType == "1")
            {
                try
                {
                    string hwid = $"{hardwareIdentification.cpuId()} - {hardwareIdentification.diskId()} - {hardwareIdentification.biosId()} - {hardwareIdentification.videoId()}";
                    Clipboard.SetText(hwid);
                    Console.Clear();
                    Console.WriteLine($"HWID: {hwid}");
                    consoleManager.centerText("Copied minecraft HWID to clipboard");
                    consoleManager.keepOpen();
                }
                catch (Exception ex)
                {
                    consoleManager.centerText($"Error grabbing minecraft HWID. Error: {ex.Message}");
                    consoleManager.keepOpen();
                    Clipboard.SetText(ex.Message);
                }
            }
            if (hwidType == "2")
            {
                var hwid = HwId.Generate();
                Clipboard.SetText(hwid);
                Console.Clear();
                consoleManager.centerText($"HWID: {hwid}");
                consoleManager.centerText("Copied counter strike HWID to clipboard");
                consoleManager.keepOpen();
            }
            else
            {
                Console.Clear();
                consoleManager.centerText("Pick a correct option retard");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }));
        
        static void Main(string[] args)
        {
            consoleManager.moveWindowToCenter();
            consoleWriter.writeLogo();
            Console.Title = "@buse whitelister";
            Console.WriteLine("\n");
            consoleManager.centerText("Pick a project");
            consoleWriter.optionsWriter("Minecraft");
            consoleWriter.optionsWriter("Counter Strike");
            var cheat = Console.ReadLine();;
            hwidType = cheat;
            consoleManager.centerText("Grabbing HWID");
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }
    }
}