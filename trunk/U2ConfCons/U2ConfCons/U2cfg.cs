using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NFSU2CH
{
    class U2cfg
    {
        private string filename = null;
        public int carAddress = -1;
        public void load(string file)
        {
            this.filename = file;
        }

        public int[] convert()
        {
            /*
             * 4 байта фигни
             * 4 байта адреса в перевернутом виде
             * 12 байтов фигни
             * 64 байта заголовка
             * 80 байт Описания
             */
            //открываем поток
            Stream stream;
            stream = new StreamReader(this.filename).BaseStream;
            byte[] hdr = new byte[4];
            stream.Position = 0x04;
            stream.Read(hdr, 0, hdr.Length);
            this.carAddress = Convert.ToInt32("0x" + hdr[3].ToString("X2") + hdr[2].ToString("X2") + hdr[1].ToString("X2") + hdr[0].ToString("X2"), 16);
            stream.Position = 0xD4;
            byte[] result = new byte[2192];
            int[] toreturn = new int[2192];
            stream.Read(result, 0, result.Length);
            stream.Close();
            int i = 0;
            foreach (int b in result)
            {
                toreturn[i] = b;
                i++;
            }
            return toreturn;
        }
    }
}