using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramServerStatusBot.Exceptions
{
    internal class ConvertValueTypeExcepions : Exception
    {
        public ConvertValueTypeExcepions(string message) : base(message) { }
    }
}
