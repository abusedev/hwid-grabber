using System;
using System.Windows.Forms;
using maycryhwid.handler;
using System.Threading;

namespace maycryhwid
{
    internal class Program
    {
        static Thread thread = new Thread((ThreadStart)(() => 
        {
            try
            {
                string hwid = $"{hardwareIdentification.cpuId()} - {hardwareIdentification.diskId()} - {hardwareIdentification.biosId()}";
                Clipboard.SetText(hwid);
                Console.Clear();
                consoleManager.centerText($"HWID: {hwid}");
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
            Console.Title = "maycry whitelister"; 
            consoleManager.centerText("Grabbing HWID");
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }
    }
}