using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace TelegramServerStatusBot.AppSettings.Loader
{
    internal sealed class IniFileSettingsLoader : ISettingLoader
    {
        public string FilePath { get; private set; }

        private const int SIZE = 1024;
        private static IniFileSettingsLoader instance = null;

        private IniFileSettingsLoader(string fileName)
        {
            FilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + $"\\{fileName}";
        }

        public static IniFileSettingsLoader GetInstance(string fileName)
        {
            if (instance == null)
            {
                instance = new IniFileSettingsLoader(fileName);
            }
            return instance;
        }

        public string GetValue(string aSection, string aKey)
        {
            StringBuilder buffer = new StringBuilder(SIZE);
            GetPrivateProfileString(aSection, aKey, null, buffer, SIZE, FilePath);
            return buffer.ToString();
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder buffer, int size, string path);
    }
}
