using System;
using System.Linq;
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
       
        public string[] parse(string filename, int[] map, int startblock)
        {
            try
            {
                //открываем поток
                Stream stream = new StreamReader(filename).BaseStream;
                //устанавливаем позицию чтения
                stream.Position = startblock;
                string[] result = new string[map.Count()];
                int i = 0;
                int key = 0;
                
                while (i < (map[map.Count() - 1] + 1))
                {
                    if (i == map[key])
                    {
                        string s = stream.ReadByte().ToString("X");
                        if (s == null)
                        {
                            stream.Close();
                            return null;
                        }
                        result[key] = s;
                        key++;
                    }
                    else
                    {
                        stream.ReadByte();
                    }
                    i++;
                }
                stream.Close();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool save(string filename, int[] map, string[] newconf, int position)
        {
            string temp = filename+".tmp";
            if (File.Exists(temp))
            {
                File.Delete(temp);
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
                if (this._curr >= position)
                {
                    int j = 0;
                    foreach (int k in map)
                    {
                        if (this._curr - position == k)
                        {
                            byt = Convert.ToInt32(newconf[j], 16);
                            break;
                        }
                        j++;
                    }
                }
                streamw.WriteByte((byte)byt);
                this._curr++;
                
            }
            streamr.Close();
            streamw.Close();
            File.Delete(filename);
            File.Move(temp, filename);
            this._curr = 0;
            return true;
        }
    }
}
