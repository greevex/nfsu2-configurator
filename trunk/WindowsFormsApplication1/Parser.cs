using System;
using System.IO;

namespace NFSU2CH
{
    public class Parser
    {
        private int _total = 8008064;
        private int _curr = 0;
        public int Total
        { 
            get { return _total; }
        }
        public int Current
        {
            get { return _curr; }
        }
        public Parser()
        {
        }

        public int[] parse(string filename, int startblock)
        {
            try
            {
                //открываем поток
                Stream stream;
                stream = new StreamReader(filename).BaseStream;
                stream.Position = startblock;
                byte[] result = new byte[2192];
                int[] r = new int[2192];
                stream.Read(result, 0, result.Length);
                stream.Close();
                int i = 0;
                foreach (byte b in result)
                {
                    r[i] = Convert.ToInt32(b);
                    i++;
                }
                stream = null;
                result = null;
                return r;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return null;
            }
        }

        public bool saveConfig(string filename, int[] config)
        {
            try
            {
                Stream streamw = new StreamWriter(filename).BaseStream;
                foreach ( int b in config ) {
                    streamw.WriteByte((byte)b);
                }
                streamw.Close();
                return true;
            }            
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return false;
            }
        }

        public int[] mapCreate(int start, int end)
        {
            int len = end - start + 1;
            int[] map = new int[len];
            int i = 0;
            foreach (int x in map)
            {
                map[i] = start;
                start++;
                i++;
            }
            return map;
        }

        public int[] mapAssign(int[] main, int[] values, int start)
        {
            int i=0;
            foreach (int x in values)
            {
                main[start] = values[i];
                start++;
                i++;
            }
            return main;
        }

        public bool save(string filename, int[] newconf, int position)
        {
            try
            {
                string temp = filename + ".tmp";
                if (File.Exists(temp))
                {
                    File.Delete(temp);
                }
                int i = 0;
                byte[] conf = new byte[newconf.Length];
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
