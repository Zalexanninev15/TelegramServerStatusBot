using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramServerStatusBot.AppSettings.Loader
{
    internal interface ISettingLoader
    {
        string FilePath { get; }
        string GetValue(string aSection, string aKey);
    }
}
