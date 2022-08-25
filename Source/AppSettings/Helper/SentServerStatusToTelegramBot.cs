using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TelegramServerStatusBot.AppSettings.Helper
{
    internal static class SentServerStatusToTelegramBot
    {
        public static void SentStatus(AppInfo appInfo)
        {
            string text, response = "";
            using (WebClient c = new WebClient())
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                if (appInfo.Proxy)
                {
                    try
                    {
                        var sproxy = new WebProxy(appInfo.ProxyInfo.IP, appInfo.ProxyInfo.Port);
                        c.Proxy = sproxy;
                    }
                    catch
                    {
                        Console.WriteLine("\nError, problem in Proxy");
                    }
                }

                while (true)
                {
                    Console.WriteLine("\nData to send is generate...");
                    text = GenerateMessage.GetMessage(appInfo);
                    Console.WriteLine("\nSending status...");

                    try
                    {
                        if (appInfo.SSl)
                        {
                            string url = "https://api.telegram.org/bot" + appInfo.TelegramInfo.BotToken + "/sendMessage" + "?chat_id=" + appInfo.TelegramInfo.UserID + "&text=" + text;
                            response = c.DownloadString(url);
                        }
                        else
                        {
                            response = c.DownloadString("http://api.telegram.org/bot" + appInfo.TelegramInfo.BotToken + "/sendMessage" + "?chat_id=" + appInfo.TelegramInfo.UserID + "&text=" + text);
                        }
                        Console.WriteLine("\nStatus has been successfully sent! (" + DateTime.Now.ToString("dd MMMM yyyy") + " " + DateTime.Now.ToString("HH:mm:ss") + ")\nWaiting " + appInfo.WaitMillisecondsTime + " milliseconds...");
                        Thread.Sleep(appInfo.WaitMillisecondsTime);
                    }
                    catch
                    {
                        Console.WriteLine("\nError sending status! (" + DateTime.Now.ToString("dd MMMM yyyy") + " " + DateTime.Now.ToString("HH:mm:ss") + ")\nAttempt will be repeated in " + appInfo.WaitMillisecondsTimeError + " milliseconds...");
                        Thread.Sleep(appInfo.WaitMillisecondsTimeError);
                    }
                }
            }
        }
    }
}
