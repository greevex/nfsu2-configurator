using System;
using System.IO;

namespace NFSU2CH
{
    public class Parser
    {
        int _total = 8008064;
        int _curr = 0;
        public string filename = "";
        public int[] main = null;
        public int Total
        { 
            get { return _total; }
        }
        public int Current
        {
            get { return _curr; }
        }
        public Parser(string filename)
        {
            main = new int[2192];
            this.filename = filename;
        }

        public int[] parse(int startblock)
        {
            try
            {
                //открываем поток
                Stream stream;
                stream = new StreamReader(this.filename).BaseStream;
                stream.Position = startblock;
                this._curr = startblock;
                byte[] result = new byte[2192];
                stream.Read(result, 0, result.Length);
                stream.Close();
                int i = 0;
                foreach (byte b in result)
                {
                    this.main[i] = Convert.ToInt32(b);
                    i++;
                }
                stream = null;
                result = null;
                return this.main;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return null;
            }
        }
        public bool saveConfig(string file, int[] conf, int car)
        {
            try
            {
                byte[] b = new byte[conf.Length];
                byte[] cara = new byte[4] { 
                    (byte)((car >> 24) & 0xff),
                    (byte)((car >> 16) & 0xff),
                    (byte)((car >> 8 ) & 0xff),
                    (byte)((car) & 0xff)};
                Stream streamw = new StreamWriter(file).BaseStream;
                streamw.Write(new byte[3] { 0x43, 0x41, 0x52 }, 0, 3); //запись сигнатуры
                streamw.Write(new byte[1] { 0x00 }, 0, 1); //резерв
                streamw.Write(new byte[1] { 0x01 }, 0, 1); //версия конфига
                streamw.Write(cara, 0, 4); //запись "для какой машины"
                streamw.Write(new byte[2] { 0x00, 0x00 }, 0, 2); //резерв
                b = Converter.Encode(conf);
                streamw.Write(b, 0, b.Length); //запись Encode config data
                streamw.Close();
                return true;
            }            
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return false;
            }
        }
        public int[] loadConfig(string filename, int car)
        {
            byte[] cara = new byte[4] { 
                    (byte)((car >> 24) & 0xff),
                    (byte)((car >> 16) & 0xff),
                    (byte)((car >> 8 ) & 0xff),
                    (byte)((car) & 0xff)};
            try
            {
                byte[] hdr = new byte[11]; //хедер файла
                Stream sr = new StreamReader(filename).BaseStream;
                sr.Read(hdr, 0, hdr.Length);
                if (hdr[0] != 0x43 || hdr[1] != 0x41 || hdr[2] != 0x52) //проверка сигнатуры
                {
                    throw new Exception("Не верный *.car Файл");
                }
                if (hdr[4] != 0x01) //версия конфига
                {
                    throw new Exception("Не верная версия *.car файла");
                }
                if (hdr[5] != cara[0] || hdr[6] != cara[1] || hdr[7] != cara[2] || hdr[8] != cara[3]) //проверка для текущей ли машины конфиг
                {
                    throw new Exception("Этот конфиг не для этого автомобиля");
                }
                hdr = null; //он нам больше не нужен хД
                byte[] config = new byte[2192];
                if (sr.Read(config, 0, config.Length) < config.Length)
                {
                    throw new Exception("Bad *.car file");
                }
                int[] conf;
                conf = Converter.Decode(config);
                config = null; //это нам тоже уже не нужно
                cara = null; //и это как не страно тоже не нужно
                return conf;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return null;
            }
        }
        public bool save(int position, int[] newconf)
        {
            try
            {
                string temp = Environment.GetEnvironmentVariable("TEMP") + "/GlobalB.tmp";
                if (File.Exists(temp))
                {
                    File.Delete(temp);
                }
                int i = 0;
                byte[] conf = new byte[this.main.Length];
                foreach (int b in newconf)
                {
                    conf[i] = Convert.ToByte(b);
                    i++;
                }
                Stream streamr = new StreamReader(filename).BaseStream;
                Stream streamw = new StreamWriter(temp).BaseStream;
                streamr.Position = 0;
                this._curr = 0;
                while (true)
                {
                    int byt = streamr.ReadByte();
                    if (byt == -1)
                        break;
                    if (this._curr == position)
                    {
                        streamw.Write(conf, 0, conf.Length);
                        this._curr += conf.Length;
                        streamr.Position = this._curr;
                    }
                    else
                    {
                        streamw.WriteByte((byte)byt);
                        this._curr++;
                    }

                }
                streamr.Close();
                streamw.Close();
                File.Delete(filename);
                File.Move(temp, filename);
                this._curr = 0;
                return true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return false;
            }
        }
    }
}
