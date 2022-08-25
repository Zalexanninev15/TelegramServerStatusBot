using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramServerStatusBot.AppSettings
{
    public class PCInfo
    {
        public bool Date { get; set; }
        public bool Time { get; set; }
        public bool Name { get; set; }
        public bool IP { get; set; }
        public bool PublicIP { get; set; }
        public bool CPU { get; set; }
        public bool MbFreeRAM { get; set; }
        public bool MbBusyRAM { get; set; }
    }
}
