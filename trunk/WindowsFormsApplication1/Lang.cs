using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NFSU2CH
{
    class Lang
    {
        public static string[] getLng()
        {
            return Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "/lng", "*.lng");
        }
        public static string[] getLngStr(string lang)
        {
            StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "/lng/" + lang + ".lng");
            string lng = sr.ReadToEnd();
            return lng.Split('\n');
        }
    }
}
