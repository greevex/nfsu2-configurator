using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace NFSU2CH
{
    public partial class Form1 : Form
    {
        private string[] s;
        private Parser p;
        private Thread t1;
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
            this.p = new Parser(textBox26.Text);
            p.setMap(Properti.map, pos);
            p.parse();
            this.s = p.getResult();
            #region добавление в текстбоксы
            /* Обороты */

            textBox3.Text = s[149]; // Нейтралка
            textBox48.Text = s[150];

            textBox1.Text = s[153]; // Максимально
            textBox28.Text = s[154];

            textBox2.Text = s[151]; // Переключение
            textBox29.Text = s[152];

            /* ЭКУ */

            textBox4.Text = s[155]; // 1
            trackBar7.Value = Int32.Parse(textBox4.Text, NumberStyles.HexNumber);

            textBox5.Text = s[156];
            textBox6.Text = s[157]; // 2
            trackBar8.Value = Int32.Parse(textBox6.Text, NumberStyles.HexNumber);

            textBox7.Text = s[158];
            textBox8.Text = s[159]; // 3
            trackBar9.Value = Int32.Parse(textBox8.Text, NumberStyles.HexNumber);

            textBox9.Text = s[160];
            textBox10.Text = s[161];// 4
            trackBar10.Value = Int32.Parse(textBox10.Text, NumberStyles.HexNumber);

            textBox11.Text = s[162];
            textBox12.Text = s[163];// 5
            trackBar11.Value = Int32.Parse(textBox12.Text, NumberStyles.HexNumber);

            textBox30.Text = s[164];
            textBox31.Text = s[165];// 6
            trackBar12.Value = Int32.Parse(textBox31.Text, NumberStyles.HexNumber);

            textBox32.Text = s[166];
            textBox33.Text = s[167];// 7
            trackBar13.Value = Int32.Parse(textBox33.Text, NumberStyles.HexNumber);

            textBox34.Text = s[168];
            textBox35.Text = s[169];// 8
            trackBar14.Value = Int32.Parse(textBox35.Text, NumberStyles.HexNumber);

            textBox36.Text = s[170];
            textBox37.Text = s[171];// 9
            trackBar15.Value = Int32.Parse(textBox37.Text, NumberStyles.HexNumber);

            textBox38.Text = s[172]; 

            /* Турбо */

            textBox13.Text = s[173];// 1
            trackBar16.Value = Int32.Parse(textBox13.Text, NumberStyles.HexNumber);

            textBox14.Text = s[174];
            textBox15.Text = s[175];// 2
            trackBar17.Value = Int32.Parse(textBox15.Text, NumberStyles.HexNumber);

            textBox16.Text = s[176];
            textBox17.Text = s[177];// 3
            trackBar18.Value = Int32.Parse(textBox17.Text, NumberStyles.HexNumber);

            textBox18.Text = s[178];
            textBox19.Text = s[179];// 4
            trackBar19.Value = Int32.Parse(textBox19.Text, NumberStyles.HexNumber);

            textBox20.Text = s[180];
            textBox21.Text = s[181];// 5
            trackBar20.Value = Int32.Parse(textBox21.Text, NumberStyles.HexNumber);

            textBox44.Text = s[182];
            textBox46.Text = s[183];// 6
            trackBar21.Value = Int32.Parse(textBox46.Text, NumberStyles.HexNumber);

            textBox42.Text = s[184];
            textBox40.Text = s[185];// 7
            trackBar22.Value = Int32.Parse(textBox40.Text, NumberStyles.HexNumber);

            textBox39.Text = s[186];
            textBox41.Text = s[187];// 8
            trackBar23.Value = Int32.Parse(textBox41.Text, NumberStyles.HexNumber);

            textBox43.Text = s[188];
            textBox45.Text = s[189];// 9
            trackBar24.Value = Int32.Parse(textBox45.Text, NumberStyles.HexNumber);

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

            #endregion
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.progressBar1.Maximum = this.p.Total;
            this.progressBar1.Value = 0;
            this.t1 = new Thread(new ThreadStart(saveT));
            Thread t = new Thread(new ThreadStart(this.prgs));
            t1.Start();
            t.Start();
        }
           
        private void saveT()
        {
            s[149] = textBox3.Text; // Нейтралка
            s[150] = textBox48.Text;

            s[153] = textBox1.Text; // Максимально
            s[154] = textBox28.Text;

            s[151] = textBox2.Text; // Переключение
            s[152] = textBox29.Text;

            /* ЭКУ */

            s[155] = textBox4.Text; // 1
            s[156] = textBox5.Text;
            s[157] = textBox6.Text; // 2
            s[158] = textBox7.Text;
            s[159] = textBox8.Text; // 3
            s[160] = textBox9.Text;
            s[161] = textBox10.Text;// 4
            s[162] = textBox11.Text;
            s[163] = textBox12.Text;// 5
            s[164] = textBox30.Text;
            s[165] = textBox31.Text;// 6
            s[166] = textBox32.Text;
            s[167] = textBox33.Text;// 7
            s[168] = textBox34.Text;
            s[169] = textBox35.Text;// 8
            s[170] = textBox36.Text;
            s[171] = textBox37.Text;// 9
            s[172] = textBox38.Text;

            /* Турбо */

            s[173] = textBox13.Text;// 1
            s[174] = textBox14.Text;
            s[175] = textBox15.Text;// 2
            s[176] = textBox16.Text;
            s[177] = textBox17.Text;// 3
            s[178] = textBox18.Text;
            s[179] = textBox19.Text;// 4
            s[180] = textBox20.Text;
            s[181] = textBox21.Text;// 5
            s[182] = textBox44.Text;
            s[183] = textBox46.Text;// 6
            s[184] = textBox42.Text;
            s[185] = textBox40.Text;// 7
            s[186] = textBox39.Text;
            s[187] = textBox41.Text;// 8
            s[188] = textBox43.Text;
            s[189] = textBox45.Text;// 9
            s[190] = textBox47.Text;

            this.p.save(textBox26.Text + ".tmp", this.s);
        }

        void prgs()
        {
            this.Invoke((MethodInvoker)(() => this.Enabled = false));
            while (t1.IsAlive)
            {
                progressBar1.Invoke((MethodInvoker)(() => progressBar1.Value = this.p.Current));
                Thread.Sleep(10);
            }
            this.Invoke((MethodInvoker)(() => this.Enabled = true));
            MessageBox.Show("Изменения сохранены!");
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
