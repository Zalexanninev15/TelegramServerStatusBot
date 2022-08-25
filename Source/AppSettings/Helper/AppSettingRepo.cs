using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using TelegramServerStatusBot.AppSettings.Loader;
using TelegramServerStatusBot.Exceptions;

namespace TelegramServerStatusBot.AppSettings.Helper
{
    public static class AppSettingRepo
    {
        private static IniFileSettingsLoader loader;
        public static AppInfo GetAppSetting(string fileName)
        {
            loader = IniFileSettingsLoader.GetInstance(fileName);

            AppInfo appInfo = new AppInfo()
            {
                ShowTelegramInfo = GetBoolValue("App", "TelegramInfo"),
                SSl = GetBoolValue("App", "SSl"),
                Proxy = GetBoolValue("App", "Proxy"),
                WaitMillisecondsTime = GetIntValue("App", "WaitMillisecondsTime"),
                WaitMillisecondsTimeError = GetIntValue("App", "WaitMillisecondsTimeError"),
                PCInfo = new PCInfo()
                {
                    Date = GetBoolValue("PC", "Date"),
                    Time = GetBoolValue("PC", "Time"),
                    Name = GetBoolValue("PC", "Name"),
                    IP = GetBoolValue("PC", "IP"),
                    PublicIP = GetBoolValue("PC", "PublicIP"),
                    CPU = GetBoolValue("PC", "CPU"),
                    MbFreeRAM = GetBoolValue("PC", "MbFreeRAM"),
                    MbBusyRAM = GetBoolValue("PC", "MbBusyRAM"),
                },
                ProxyInfo = GetBoolValue("App", "Proxy") ? new ProxyInfo() {
                    IP = GetStringValue("Proxy", "IP"),
                    Port = GetIntValue("Proxy", "Port")
                } : null,
                TelegramInfo = GetBoolValue("App", "TelegramInfo") ? new TelegramInfo()
                {
                    BotToken = GetStringValue("Telegram", "BotToken"),
                    UserID = GetStringValue("Telegram", "UserID")
                } : null
            };

            return appInfo;
        }
        private static bool GetBoolValue(string section, string key)
        {
            var value = loader.GetValue(section, key);
            try
            {
                bool.TryParse(value, out bool result);
                return result;
            } catch
            {
                throw new ConvertValueTypeExcepions($"error when Convert the {key} to bool");
            }
        }

        private static int GetIntValue(string section, string key)
        {
            var value = loader.GetValue(section, key);
            try
            {
                int.TryParse(value, out int result);
                return result;
            } catch
            {
                throw new ConvertValueTypeExcepions($"error when Convert the {key} to int");
            }
        }

        private static string GetStringValue(string section, string key)
        {
            return loader.GetValue(section, key);
        }
    }
}
