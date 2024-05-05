using Microsoft.Win32;
using System;

namespace C_fetch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //reading the os version and build from the registry and setting them to strings to be called later.
            //this is important as microsoft set the NT version to be "6.2.9200.0" sometime in windows 8.1 development.
            string GETHKLMVERSION = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion";
            string OSVersion = Registry.GetValue(GETHKLMVERSION, "productName", "").ToString();
            string Build = Registry.GetValue(GETHKLMVERSION, "CurrentBuildNumber", "").ToString();

            //using Environment.Is64BitOperatingSystem to pre set a string to be called later.
            string bits = Environment.Is64BitOperatingSystem ? "64" : "32";
            
            //reading the cpu model from the registry, kinda hacky but it works.
            string GETHKLMGETCPU = @"HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0";
            string CPU = Registry.GetValue(GETHKLMGETCPU, "ProcessorNameString", "").ToString();



            Console.WriteLine(Environment.MachineName);
            Console.WriteLine("-----------");
            Console.WriteLine("OS: " + OSVersion + " " + bits + "-Bit ");
            Console.WriteLine("CPU: " + CPU);

            Console.ReadKey();
        }
    }
}
