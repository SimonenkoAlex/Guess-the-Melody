using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;

namespace Угадай_мелодию
{
    static class Victorina
    {
        static public List<string> list = new List<string>();
        static public int GameDuration = 60; // продолжительность игры
        static public int MusicDuration = 10; // продолжительность одного музыкального трека
        static public bool randomStart = false; // начинать проигрование музыкальной композиции со случайного места
        static public string LastFolder = ""; // предыдущая папка
        static public bool AllDirectores = false; // нужно ли обрабатывать вложенные папки
        static public string answer = " ";

        static public void ReadMusic()
        {
            try
            {
                string[] music_files = Directory.GetFiles(LastFolder, "*.mp3", AllDirectores ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                list.Clear();
                list.AddRange(music_files);
            }
            catch
            {

            }
        }

        static string ReadKeyName = "Software\\SimonenkoAlex\\GuessMelody";

        public static void WriteParam()
        {
            RegistryKey rk = null;
            try
            {
                Registry.CurrentUser.CreateSubKey(ReadKeyName);
                if (rk == null) return;
                rk.SetValue("LastFolder", LastFolder);
                rk.SetValue("randomStart", randomStart);
                rk.SetValue("GameDuration", GameDuration);
                rk.SetValue("MusicDuration", MusicDuration);
                rk.SetValue("AllDirectores", AllDirectores);
            }
            finally
            {
                if (rk != null) rk.Close();
            }
        }

        public static void ReadParam()
        {
            RegistryKey rk = null;
            try
            {
                Registry.CurrentUser.CreateSubKey(ReadKeyName);
                if (rk != null)
                {
                    LastFolder = (string) rk.GetValue("LastFolder");
                    randomStart = Convert.ToBoolean(rk.GetValue("randomStart", false));
                    GameDuration = (int) rk.GetValue("GameDuration");
                    MusicDuration = (int) rk.GetValue("MusicDuration");
                    AllDirectores = Convert.ToBoolean(rk.GetValue("AllDirectores", false));
                }
            }
            finally
            {
                if (rk != null) rk.Close();
            }
        }
    }
}
