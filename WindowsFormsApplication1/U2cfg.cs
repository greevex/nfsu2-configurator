using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NFSU2CH
{
    class U2cfg
    {
        private string filename = null;

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