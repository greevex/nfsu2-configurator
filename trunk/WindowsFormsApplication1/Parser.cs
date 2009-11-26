using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NFSU2CH
{
    class Parser
    {
        io io;
        int[] map;
        private string[] result = null;

        public Parser(string filename)
        {
            this.io = new io(filename);
        }

        public void setMap(int[] map)
        {
            this.map = map;
        }

        public bool parse()
        {
            this.result = new string[map.Count()];
            int i = 0;
            int key = 0;
            while (i < map[map.Count() - 1] + 1)
            {
                if (i == map[key])
                {
                    MessageBox.Show(key.ToString() + "й байт");
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
            return false;
        }

        public string[] getResult()
        {
            return this.result;
        }
    }
}
