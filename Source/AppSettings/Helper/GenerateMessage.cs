using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TelegramServerStatusBot.AppSettings.Helper
{
    public static class GenerateMessage
    {
        private static ManagementObjectSearcher cpuMonitor = new ManagementObjectSearcher("SELECT LoadPercentage  FROM Win32_Processor");
        public static string GetMessage(AppInfo appInfo)
        {
            string text = "";

            text = "PC Status:";
            if (appInfo.PCInfo.Name)
            {
                text += "\nName: " + Dns.GetHostName();
            }
            if (appInfo.PCInfo.IP)
            {
                try { text += "\nIP: " + Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString(); } catch { Console.WriteLine("\nError, problem in IP"); }
            }
            if (appInfo.PCInfo.PublicIP)
            {
                using (WebClient c = new WebClient())
                {
                    try { text += "\nPublic IP: " + c.DownloadString("https://icanhazip.com"); } catch { Console.WriteLine("\nError, problem in Public IP"); }
                }
            }
            if (appInfo.PCInfo.CPU)
            {
                int cpus = 0;
                foreach (ManagementObject objcpu in cpuMonitor.Get()) { text += "CPU" + cpus + " Usage: " + Convert.ToString(objcpu["LoadPercentage"]) + "%"; cpus = cpus + 1; }
            }
            if (appInfo.PCInfo.MbFreeRAM)
            {
                text += "\nFree RAM: " + Memory.GetPhysicalAvailableMemoryInMiB() + " Mb";
            }
            if (appInfo.PCInfo.MbBusyRAM)
            {
                text += "\nBusy RAM: " + Convert.ToString(Convert.ToInt32(Memory.GetTotalMemoryInMiB()) - Convert.ToInt32(Memory.GetPhysicalAvailableMemoryInMiB())) + " Mb";
            }
            if (appInfo.PCInfo.Date)
            {
                text += "\nDate: " + DateTime.Now.ToString("dd MMMM yyyy");
            }
            if (appInfo.PCInfo.Time)
            {
                text += "\nTime: " + DateTime.Now.ToString("HH:mm:ss");
            }
            return text;
        }
    }
}
