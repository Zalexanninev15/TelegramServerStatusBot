using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramServerStatusBot.AppSettings
{
    public class TelegramInfo
    {
        private string _botToken;
        public string BotToken 
        {
            get {
                return _botToken;
            }
            set 
            {
                _botToken = value;
                if (!String.IsNullOrEmpty(value))
                {
                    Console.WriteLine($"Token: {value}");
                }
            }
        }

        private string _userID;
        public string UserID 
        {
            get
            {
                return _userID;
            }
            set
            {
                _userID = value;
                if (!String.IsNullOrEmpty(value))
                {
                    Console.WriteLine($"UserID: {value}");
                }
            }
        }
    }
}
