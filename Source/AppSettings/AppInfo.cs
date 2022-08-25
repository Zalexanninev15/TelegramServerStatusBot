using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramServerStatusBot.AppSettings
{
    public class AppInfo
    {
        public bool ShowTelegramInfo { get; set; }
        public bool SSl { get; set; }
        public bool Proxy { get; set; }
        public int WaitMillisecondsTime { get; set; }
        public int WaitMillisecondsTimeError { get; set; }

        public PCInfo PCInfo { get; set; }
        public ProxyInfo ProxyInfo { get; set; }
        public TelegramInfo TelegramInfo { get; set; }
    }
}
