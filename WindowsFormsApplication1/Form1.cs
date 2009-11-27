using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace NFSU2CH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.FileName = "GlobalB.lzc";
            this.openFileDialog1.Filter = "Файл настроек NFSU2|GlobalB.lzc";
            openFileDialog1.ShowDialog();
            textBox26.Text = openFileDialog1.FileName.ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.loadCnf(Properti.CARS[0]);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            loadCnf(Properti.getPosition(this.comboBox1.Text));
        }

        private void loadCnf(int pos)
        {
            /* Загрузка */
            NFSU2CH.Parser p = new NFSU2CH.Parser(textBox26.Text);

            /**/
            int[] map = new int[191]{1,

                /////первое колесо
                //первая строка
                288,289,290,291, //1-4

                292,293,294,295, //5-8

                296,297,298,299, //9-12

                //вторая строка
                304,305,306,307, //13-16

                308,309,310,311, //17-20

                312,313,314,315, //21-24

                316,317,318,319, //25-28

                //третья строка
                320,321,322,323, //29-32

                //// второе колесо
                
                //первая строка
                336,337,338,339, //33-36

                340,341,342,343, //37-40

                344,345,346,347, //41-44

                //вторая строка
                352,353,354,355, //45-48

                356,357,358,359, //49-52

                360,361,362,363, //53-56

                364,365,366,367, //57-60

                //третья строка
                368,369,370,371, //61-64

                ////// Третье колесо

                //первая строка
                384, 385, 386, 387, //65-68

                388, 389, 390, 391, //69-72

                392, 393, 394, 395, //73-76

                //вторая строка
                400, 401, 402, 403, //77-80

                404, 405, 406, 407, //81-84

                408, 409, 410, 411, //85-88

                412, 413, 414, 415, //89-92

                //третья строка
                416, 417, 418, 419, //93-96

                ////// Четвертое колесо

                //первая строка
                432, 433, 434, 435, //97-100

                436, 437, 438, 439, //101-104

                440, 441, 442, 443, //105-108

                //вторая строка
                448, 449, 450, 451, //109-112

                452, 453, 454, 455, //113-116

                456, 457, 458, 459, //117-120

                460, 461, 462, 463, //121-124

                //третья строка
                464, 465, 466, 467, //125-128

                ////// Управление

                544, 545, 546, 547, //129-132

                548, 549, 550, 551, //133-136

                552, 553, 554, 555, //137-140

                556, 557, 558, 559, //141-144

                560, 561, 562, 563, //145-148

                ////// Движок
                770, 771, 774, 775, 778, 779, //149-154

                ////// ЭКУ
                786, 787, //155
                790, 791, 
                794, 795,
                798, 799, //161
                802, 803,
                806, 807,
                810, 811, //167
                814, 815,
                818, 819, //171

                ////// ТУРБО
                834, 835, //173
                838, 839, 
                842, 843,
                846, 847, //179
                850, 851,
                854, 855,
                858, 859, //185
                862, 863,
                866, 867  //189
            };
            

            p.setMap(map, pos);

            p.parse();

            string[] s = p.getResult();



            /* Обороты */

            textBox3.Text = s[149]; // Нейтралка
            textBox2.Text = s[151]; // Переключение
            textBox1.Text = s[153]; // Максимально
            textBox28.Text = s[150];
            textBox29.Text = s[152];
            textBox48.Text = s[154];

            /* ЭКУ */

            textBox4.Text = s[155]; // 1
            textBox5.Text = s[156];
            textBox6.Text = s[157]; // 2
            textBox7.Text = s[158];
            textBox8.Text = s[159]; // 3
            textBox9.Text = s[160];
            textBox10.Text = s[161];// 4
            textBox11.Text = s[162];
            textBox12.Text = s[163];// 5
            textBox30.Text = s[164];
            textBox31.Text = s[165];// 6
            textBox32.Text = s[166];
            textBox33.Text = s[167];// 7
            textBox34.Text = s[168];
            textBox35.Text = s[169];// 8
            textBox36.Text = s[170];
            textBox37.Text = s[171];// 9
            textBox38.Text = s[172]; 

            /* Турбо */

            textBox13.Text = s[173];// 1
            textBox14.Text = s[174];
            textBox15.Text = s[175];// 2
            textBox16.Text = s[176];
            textBox17.Text = s[177];// 3
            textBox18.Text = s[178];
            textBox19.Text = s[179];// 4
            textBox20.Text = s[180];
            textBox21.Text = s[181];// 5
            textBox44.Text = s[182];
            textBox46.Text = s[183];// 6
            textBox42.Text = s[184];
            textBox40.Text = s[185];// 7
            textBox39.Text = s[186];
            textBox41.Text = s[187];// 8
            textBox43.Text = s[188];
            textBox45.Text = s[189];// 9
            textBox47.Text = s[190];

            /* Подвеска */

            textBox22.Text = ""; // Передняя левая
            textBox25.Text = ""; // Передняя правая
            textBox23.Text = ""; // Задняя левая
            textBox24.Text = ""; // Задняя правая

            textBox27.Text = ""; // Глобальная

            /* Управление */

            trackBar4.Value = Int32.Parse(s[91], NumberStyles.HexNumber);
            label10.Text = trackBar4.Value.ToString();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void trackBar4_Scroll_1(object sender, EventArgs e)
        {
            label10.Text = trackBar4.Value.ToString();
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            label36.Text = trackBar6.Value.ToString();
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            label29.Text = trackBar5.Value.ToString();
        }

        private void trackBar3_Scroll_1(object sender, EventArgs e)
        {
            label12.Text = trackBar3.Value.ToString();
        }

        private void trackBar2_Scroll_1(object sender, EventArgs e)
        {
            label11.Text = trackBar2.Value.ToString();
        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            label13.Text = trackBar1.Value.ToString();
        }
    }
}
