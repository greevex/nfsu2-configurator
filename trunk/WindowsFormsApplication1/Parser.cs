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
       
        public int[] parse(string filename, int[] map, int startblock)
        {
            try
            {
                //открываем поток
                Stream stream = new StreamReader(filename).BaseStream;
                //устанавливаем позицию чтения
                stream.Position = startblock;
                int[] result = new int[191];
                int i = 0;
                int key = 0;
                
                while (i < (map[191 - 1] + 1))
                {
                    if (i == map[key])
                    {
                        int s = stream.ReadByte();
                        if (s == -1)
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
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return null;
            }
        }
        public bool save(string filename, int[] map, int[] newconf, int position)
        {
            try
            {
                string temp = filename + ".tmp";
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
                                byt = newconf[j];
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
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return false;
            }
        }
    }
}
