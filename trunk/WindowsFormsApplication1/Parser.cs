using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NFSU2CH
{
    public class Parser
    {
        io io;
        int[] map;
        int startblock;
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
        public string[] getResult()
        {
            return this.result;
        }
    }
}
