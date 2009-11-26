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
            int[] map = new int[6] { 771, 772, 775, 776, 779, 780 };

            /*
            /////первое колесо
            //первая строка
            289,290,291,292,

            293,294,295,296,

            297,298,299,300,

            //вторая строка
            305,306,307,308,

            309,310,311,312,

            313,314,315,316,

            317,318,319,320,

            //третья строка
            321,322,323,324,

            //// второе колесо
                
            //первая строка
            337,338,339,340,

            341,342,343,344,

            345,346,347,348,

            //вторая строка
            353,354,355,356,

            357,358,359,360,

            361,362,363,364,

            365,366,367,368,

            //третья строка
            369,370,371,372,
            */

            p.setMap(map, pos); ///PEUGOT

            p.parse();

            string[] s = p.getResult();



            /* Обороты */

            textBox1.Text = s[0]; // Максимально
            textBox2.Text = s[2]; // Переключение
            textBox3.Text = s[4]; // Нейтралка

            /* ЭКУ */

            textBox4.Text = ""; // 1
            textBox5.Text = ""; // 2
            textBox6.Text = ""; // 3
            textBox7.Text = ""; // 4
            textBox8.Text = ""; // 5
            textBox9.Text = ""; // 6
            textBox10.Text = ""; // 7
            textBox11.Text = ""; // 8
            textBox12.Text = ""; // 9

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
