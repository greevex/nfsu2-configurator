using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NFSU2CH
{
    public delegate void MyDelegate();   // delegate declaration
    public interface I 
    {
        event MyDelegate MyEvent;
        void FireAway();
    }


    public class Parser : I
    {
        public event MyDelegate MyEvent;
        public void FireAway()
        {
            MyEvent();
        }

        io io;
        int[] map;
        int startblock;
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
        private string[] result = null;
        public Parser(string filename)
        {
            this.map = null;
            this.startblock = 0;
            this.result = null;
            this.io = new io(filename);
            
        }
        public void setMap(int[] map, int startblock)
        {
            this.map = map;
            this.startblock = startblock;
        }
       
        public bool parse()
        {
            try
            {
                this.result = new string[map.Count()];
                int i = 0;
                int key = 0;
                this.io.setPosition(this.startblock);
                while (i < (map[map.Count() - 1] + 1))
                {
                    if (i == map[key])
                    {
                        
                        string s = this.io.getHexByte(); ///
                        if (s == null)
                            return false;
                        this.result[key] = s;

                        key++;
                    }
                    else
                    {
                        this.io.getHexByte();
                    }
                    i++;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool save(string filename, string[] newconf)
        {
            if (System.IO.File.Exists(filename))
            {
                System.IO.File.Delete(filename);
            }
            this.io.setPosition(0);
            this.io.openWrite(filename);
            while (true)
            {
                string byt = this.io.getHexByte();
                if (byt == null)
                    break;
                if (this._curr >= this.startblock)
                {
                    int j = 0;
                    foreach (int k in this.map)
                    {
                        if (this._curr - this.startblock == k)
                        {
                            byt = newconf[j];
                            break;
                        }
                        j++;
                    }
                }
                this.io.writeByte(Convert.ToInt32(byt, 16));
                this._curr++;
                
            }
            this.io.closeWrite();
            this._curr = 0;
            return true;
        }
        public string[] getResult()
        {
            return this.result;
        }
    }
}
