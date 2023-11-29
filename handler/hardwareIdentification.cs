using System;

namespace kamishiro.handler
{
    internal class hardwareIdentification
    {
        private static string identifier(string wmiClass, string wmiProperty, string wmiMustBeTrue)
        {
            string result = "";
            System.Management.ManagementClass mc = new System.Management.ManagementClass(wmiClass);
            System.Management.ManagementObjectCollection moc = mc.GetInstances();
            foreach (System.Management.ManagementObject mo in moc)
            {
                if (mo[wmiMustBeTrue].ToString() == "True")
                {
                    if (result == "")
                    {
                        try
                        {
                            result = mo[wmiProperty].ToString();
                            break;
                        }
                        catch
                        {
                        }
                    }
                }
            }
            return result;
        }
        
        private static string identifier(string wmiClass, string wmiProperty)
        {
            string result = "";
            System.Management.ManagementClass mc = new System.Management.ManagementClass(wmiClass);
            System.Management.ManagementObjectCollection moc = mc.GetInstances();
            foreach (System.Management.ManagementObject mo in moc)
            {
                //Only get the first one
                if (result == "")
                {
                    try
                    {
                        result = mo[wmiProperty].ToString();
                        break;
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
            }
            return result;
        }
        
        public static string biosId()
        {
            return identifier("Win32_BIOS", "ReleaseDate") + identifier("Win32_BIOS", "SMBIOSBIOSVersion");
        }
        
        public static string cpuId()
        {
            string result = identifier("Win32_Processor", "UniqueId");
            if (result == "")
            {
                result = identifier("Win32_Processor", "ProcessorId");
                if (result == "") 
                {
                    result = identifier("Win32_Processor", "Name");
                    if (result == "")
                    {
                        result = identifier("Win32_Processor", "Manufacturer");
                    }
                    result += identifier("Win32_Processor", "MaxClockSpeed");
                }
            }
            return result;
        }
        
        public static string diskId()
        {
            return identifier("Win32_DiskDrive", "Model");
        }
    }
}