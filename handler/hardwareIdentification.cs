using System;
using System.Management;

namespace abuse.handler
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

        public static string videoId()
        {
            return identifier("Win32_VideoController", "DriverVersion")
            + identifier("Win32_VideoController", "Name");
        }

        public static string macId()
        {
            return identifier("Win32_NetworkAdapterConfiguration",
                "MACAddress", "IPEnabled");
        }

        internal class cs2
        {
            public static string Wmi(string wmiClass, string wmiProperty)
            {
                var result = "";
                var mc = new ManagementClass(wmiClass);
                var moc = mc.GetInstances();

                foreach (var o in moc)
                {
                    var mo = (ManagementObject)o;

                    //Only get the first one
                    if (result != "")
                        continue;

                    try
                    {
                        result = mo[wmiProperty].ToString();

                        break;
                    }
                    catch
                    {
                        // ignored
                    }
                }

                return result;
            }

            public static string biosId()
            {
                return Wmi("Win32_BIOS", "ReleaseDate") + Wmi("Win32_BIOS", "SMBIOSBIOSVersion");
            }

            public static string cpuId()
            {
                string result = Wmi("Win32_Processor", "UniqueId");
                if (result == "")
                {
                    result = Wmi("Win32_Processor", "ProcessorId");
                    if (result == "")
                    {
                        result = Wmi("Win32_Processor", "Name");
                        if (result == "")
                        {
                            result = Wmi("Win32_Processor", "Manufacturer");
                        }
                        result += Wmi("Win32_Processor", "MaxClockSpeed");
                    }
                }
                return result;
            }

            public static string diskId()
            {
                return Wmi("Win32_DiskDrive", "Model");
            }

            public static string videoId()
            {
                return Wmi("Win32_VideoController", "Name");
            }
        }
    }
}
