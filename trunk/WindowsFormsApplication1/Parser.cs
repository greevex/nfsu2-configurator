using System;
using System.IO;

namespace NFSU2CH
{
    public class Parser
    {
        private int _total = 8008064;
        private int _curr = 0;
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
        public bool saveConfig(string file, int[] conf)
        {
            try
            {
                byte[] b = new byte[conf.Length];
                int i = 0;
                foreach (byte a in b)
                {
                    b[i] = (byte)conf[i];
                    i++;
                }
                conf = null;
                Stream streamw = new StreamWriter(file).BaseStream;
                streamw.Write(b, 0, b.Length);
                streamw.Close();
                return true;
            }            
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return false;
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
