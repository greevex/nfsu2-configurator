using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

            int[] map = new int[191]{1,

                /////первое колесо
                //первая строка
                289,290,291,292, //1-4

                293,294,295,296, //5-8

                297,298,299,300, //9-12

                //вторая строка
                305,306,307,308, //13-16

                309,310,311,312, //17-20

                313,314,315,316, //21-24

                317,318,319,320, //25-28

                //третья строка
                321,322,323,324, //29-32

                //// второе колесо
                
                //первая строка
                337,338,339,340, //33-36

                341,342,343,344, //37-40

                345,346,347,348, //41-44

                //вторая строка
                353,354,355,356, //45-48

                357,358,359,360, //49-52

                361,362,363,364, //53-56

                365,366,367,368, //57-60

                //третья строка
                369,370,371,372, //61-64

                ////// Третье колесо

                //первая строка
                385, 386, 387, 388, //65-68

                389, 390, 391, 392, //69-72

                393, 394, 395, 396, //73-76

                //вторая строка
                401, 402, 403, 404, //77-80

                405, 406, 407, 408, //81-84

                409, 410, 411, 412, //85-88

                413, 414, 415, 416, //89-92

                //третья строка
                417, 418, 419, 420, //93-96

                ////// Четвертое колесо

                //первая строка
                433, 434, 435, 436, //97-100

                437, 438, 439, 440, //101-104

                441, 442, 443, 444, //105-108

                //вторая строка
                449, 450, 451, 452, //109-112

                453, 454, 455, 456, //113-116

                457, 458, 459, 460, //117-120

                461, 462, 463, 464, //121-124

                //третья строка
                465, 466, 467, 468, //125-128

                ////// Управление

                545, 546, 547, 548, //129-132

                549, 550, 551, 552, //133-136

                553, 554, 555, 556, //137-140

                557, 558, 559, 560, //141-144

                561, 562, 563, 564, //145-148

                ////// Движок
                771, 772, 775, 776, 779, 780, //149-154

                ////// ЭКУ
                785, 786, 787, 788, 789, 780, 781, 782, 783, //155-163
                784, 785, 786, 787, 788, 789, 790, 791, 792, //164-172

                ////// ТУРБО
                833, 834, 835, 836, 837, 838, 839, 840, 841, //173-181
                842, 843, 844, 845, 846, 847, 848, 849, 850  //182-190
            };

            p.setMap(map, pos);

            p.parse();

            string[] s = p.getResult();



            /* Обороты */

            textBox3.Text = s[149]; // Нейтралка
            textBox2.Text = s[151]; // Переключение
            textBox1.Text = s[153]; // Максимально

            /* ЭКУ */

            textBox4.Text = s[156]; // 1
            textBox5.Text = s[158]; // 2
            textBox6.Text = s[160]; // 3
            textBox7.Text = s[162]; // 4
            textBox8.Text = s[164]; // 5
            textBox9.Text = s[166]; // 6
            textBox10.Text = s[168]; // 7
            textBox11.Text = s[170]; // 8
            textBox12.Text = s[172]; // 9

            /* Турбо */

            textBox13.Text = ""; // 1
            textBox14.Text = ""; // 2
            textBox15.Text = ""; // 3
            textBox16.Text = ""; // 4
            textBox17.Text = ""; // 5
            textBox18.Text = ""; // 6
            textBox19.Text = ""; // 7
            textBox20.Text = ""; // 8
            textBox21.Text = ""; // 9

            /* Подвеска */

            textBox22.Text = ""; // Передняя левая
            textBox25.Text = ""; // Передняя правая
            textBox23.Text = ""; // Задняя левая
            textBox24.Text = ""; // Задняя правая

            textBox27.Text = ""; // Глобальная
        }
    }
}
