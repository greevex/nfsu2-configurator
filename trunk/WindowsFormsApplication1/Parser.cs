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
                //this.result = new string[map.Count()];
                this.result = new string[2191];
                int key = 0;
                this.io.setPosition(this.startblock);
                /*foreach (int current in map)
                {
                    io.setPosition(current);
                    string s = this.io.getHexByte(); ///
                    if (s == null)
                        return false;
                    this.result[key] = s;
                    key++;
                }
                return true;*/
                for (int i = 0; i != 2191; i++)
                {
                    string s = this.io.getHexByte(); ///
                    if (s == null)
                        return false;
                    this.result[i] = s;
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
        public string[] getResult()
        {
            return this.result;
        }
    }
}
