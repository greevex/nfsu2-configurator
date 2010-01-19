using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using NFSU2CH;
using System.IO;

namespace U2ConfCons
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("##### U2Configurator Files Installer  #####");
            Console.WriteLine();

            int[] s = null;
            string GAME_PATH = null;
            int position = -1;
            string file = "", error = "FUCK! BAD! VERY BAD! I'm so sorry, but you bitch..", ok = "OK!";
            int currentCar = 0;
            U2cfg u2c = new U2cfg();
            RegistryKey r = Registry.CurrentUser.OpenSubKey("NFSU2Configurator", true);

            Console.Write("Game Path Loading... ");
            GAME_PATH = r.GetValue("GamePath").ToString();
            if (GAME_PATH != null)
                Console.WriteLine(ok);
            else Console.WriteLine(error);

            Console.Write("Crashing Windows...  ");
            Console.WriteLine("Joke ;)");
            Properti prop = new Properti();
            prop.checkFile(GAME_PATH + "\\GLOBAL\\GlobalB.lzc");

            if (args.Length > 0)
            {
                file = args[0];
                Parser p = new Parser(file);
                if (Path.GetExtension(file).ToLower() == ".car")
                {
                    s = p.loadConfig(file, currentCar);
                    position = p.carAddress;
                }
                else if (Path.GetExtension(file).ToLower() == ".u2cfg")
                {
                    u2c.load(file);
                    s = u2c.convert();
                    position = u2c.carAddress;
                }
                else
                {
                    Console.Beep();
                    Console.WriteLine("Bad file extension. *.car or *.u2cfg allowed!");
                    Console.WriteLine();
                    Console.WriteLine("Или по русски говоря разрешено использование только файлов с расширением *.car и *.u2cfg");
                    System.Threading.Thread.CurrentThread.Abort();
                }
                Console.Write("Installing config... ");
                if (p.save(position, s))
                    Console.WriteLine("OK!");
                else
                {
                    Console.WriteLine(error);
                    Console.BackgroundColor = ConsoleColor.Red;
                    System.Threading.Thread.Sleep(5000);
                }
            }
            else
            {
                Console.Beep();
                Console.WriteLine();
                Console.WriteLine("No file detected! Use program like this line: ");
                Console.WriteLine("U2ConfCons.exe \"C:\\GAMES\\NFS Underground 2\\CarData\\VAZ2108-COROLLA.car\"");
                Console.WriteLine();
                Console.WriteLine("Or you can drag and drop file to this program to install file!");
                Console.WriteLine();
                Console.WriteLine("А теперь по русски."); 
                Console.WriteLine("Перетащи файл с расширением .car или .u2cfg на запускной файл");
                Console.WriteLine("программы «U2ConfCons.exe» и файл будет установлен.");
            }
        }
    }
}
