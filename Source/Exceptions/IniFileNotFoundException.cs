using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramServerStatusBot.Exceptions
{
    internal class IniFileNotFoundException : Exception
    {
        public IniFileNotFoundException(string message) : base(message) { }
    }
}
