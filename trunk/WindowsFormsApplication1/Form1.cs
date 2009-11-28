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
        private int[] s;
        private Parser p;
        private Thread t1;
        private int currentCar;

        public Form1()
        {
            InitializeComponent();
        }

        private void adval(System.Windows.Forms.ComboBox cb, int val)
        {
            if (val < 1)
            {
                cb.Items.AddRange(new object[1] { val });
            }
            else
            {
                cb.Items.AddRange(new object[3] { val - 1, val, val + 1 });
            }
            cb.Text = val.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.FileName = "GlobalB.lzc";
            this.openFileDialog1.Filter = "Файл настроек NFSU2|GlobalB.lzc";
            openFileDialog1.ShowDialog();
            textBox26.Text = openFileDialog1.FileName.ToString();
            comboBox1.Text = "Теперь выберите машину...";
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
            this.currentCar = pos;
            this.p = new Parser();
            this.s = p.parse(this.textBox26.Text, Properti.map, pos);
            #region добавление в текстбоксы
            /* Обороты */

            textBox3.Text = s[149].ToString(); // Нейтралка
            adval(comboBox24, s[150]);

            textBox1.Text = s[153].ToString(); // Максимально
            adval(comboBox22, s[154]);

            textBox2.Text = s[151].ToString(); // Переключение
            adval(comboBox23, s[152]);

            /* ЭКУ */

            textBox4.Text = s[155].ToString(); // 1
            trackBar7.Value = s[155];

            adval(comboBox3, s[156]);
            textBox6.Text = s[157].ToString(); // 2
            trackBar8.Value = s[157];

            adval(comboBox5, s[158]);
            textBox8.Text = s[159].ToString(); // 3
            trackBar9.Value = s[159];

            adval(comboBox6, s[160]);
            textBox10.Text = s[161].ToString();// 4
            trackBar10.Value = s[161];

            adval(comboBox7, s[162]);
            textBox12.Text = s[163].ToString();// 5
            trackBar11.Value = s[163];

            adval(comboBox8, s[164]);
            textBox31.Text = s[165].ToString();// 6
            trackBar12.Value = s[165];

            adval(comboBox9, s[166]);
            textBox33.Text = s[167].ToString();// 7
            trackBar13.Value = s[167];

            adval(comboBox10, s[168]);
            textBox35.Text = s[169].ToString();// 8
            trackBar14.Value = s[169];

            adval(comboBox11, s[170]);
            textBox37.Text = s[171].ToString();// 9
            trackBar15.Value = s[171];

            adval(comboBox12, s[172]);

            /* Турбо */

            textBox13.Text = s[173].ToString();// 1
            trackBar16.Value = s[173];

            adval(comboBox13, s[174]);
            textBox15.Text = s[175].ToString();// 2
            trackBar17.Value = s[175];

            adval(comboBox14, s[176]);
            textBox17.Text = s[177].ToString();// 3
            trackBar18.Value = s[177];

            adval(comboBox15, s[178]);
            textBox19.Text = s[179].ToString();// 4
            trackBar19.Value = s[179];

            adval(comboBox16, s[180]);
            textBox21.Text = s[181].ToString();// 5
            trackBar20.Value = s[181];

            adval(comboBox17, s[182]);
            textBox46.Text = s[183].ToString();// 6
            trackBar21.Value = s[183];

            adval(comboBox18, s[184]);
            textBox40.Text = s[185].ToString();// 7
            trackBar22.Value = s[185];

            adval(comboBox19, s[186]);
            textBox41.Text = s[187].ToString();// 8
            trackBar23.Value = s[187];

            adval(comboBox20, s[188]);
            textBox45.Text = s[189].ToString();// 9
            trackBar24.Value = s[189];

            adval(comboBox21, s[190]);

            /* Подвеска */

            textBox22.Text = ""; // Передняя левая
            textBox25.Text = ""; // Передняя правая
            textBox23.Text = ""; // Задняя левая
            textBox24.Text = ""; // Задняя правая

            textBox27.Text = ""; // Глобальная

            /* Управление */

            trackBar4.Value = s[91];
            label10.Text = s[91].ToString();

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
            s[149] = Int32.Parse(textBox3.Text); // Нейтралка
            s[150] = Int32.Parse(comboBox24.Text);

            s[153] = Int32.Parse(textBox1.Text); // Максимально
            s[154] = Int32.Parse(comboBox22.Text);

            s[151] = Int32.Parse(textBox2.Text); // Переключение
            s[152] = Int32.Parse(comboBox23.Text);

            /* ЭКУ */

            s[155] = Int32.Parse(textBox4.Text); // 1
            s[156] = Int32.Parse(comboBox3.Text);
            s[157] = Int32.Parse(textBox6.Text); // 2
            s[158] = Int32.Parse(comboBox5.Text);
            s[159] = Int32.Parse(textBox8.Text); // 3
            s[160] = Int32.Parse(comboBox6.Text);
            s[161] = Int32.Parse(textBox10.Text);// 4
            s[162] = Int32.Parse(comboBox7.Text);
            s[163] = Int32.Parse(textBox12.Text);// 5
            s[164] = Int32.Parse(comboBox8.Text);
            s[165] = Int32.Parse(textBox31.Text);// 6
            s[166] = Int32.Parse(comboBox9.Text);
            s[167] = Int32.Parse(textBox33.Text);// 7
            s[168] = Int32.Parse(comboBox10.Text);
            s[169] = Int32.Parse(textBox35.Text);// 8
            s[170] = Int32.Parse(comboBox11.Text);
            s[171] = Int32.Parse(textBox37.Text);// 9
            s[172] = Int32.Parse(comboBox12.Text);

            /* Турбо */

            s[173] = Int32.Parse(textBox13.Text);// 1
            s[174] = Int32.Parse(comboBox13.Text);
            s[175] = Int32.Parse(textBox15.Text);// 2
            s[176] = Int32.Parse(comboBox14.Text);
            s[177] = Int32.Parse(textBox17.Text);// 3
            s[178] = Int32.Parse(comboBox15.Text);
            s[179] = Int32.Parse(textBox19.Text);// 4
            s[180] = Int32.Parse(comboBox16.Text);
            s[181] = Int32.Parse(textBox21.Text);// 5
            s[182] = Int32.Parse(comboBox17.Text);
            s[183] = Int32.Parse(textBox46.Text);// 6
            s[184] = Int32.Parse(comboBox18.Text);
            s[185] = Int32.Parse(textBox40.Text);// 7
            s[186] = Int32.Parse(comboBox19.Text);
            s[187] = Int32.Parse(textBox41.Text);// 8
            s[188] = Int32.Parse(comboBox20.Text);
            s[189] = Int32.Parse(textBox45.Text);// 9
            s[190] = Int32.Parse(comboBox21.Text);

            this.p.save(this.textBox26.Text, Properti.map, this.s, this.currentCar);
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

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            textBox4.Text = trackBar7.Value.ToString();
        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            textBox6.Text = trackBar8.Value.ToString();
        }

        private void trackBar9_Scroll(object sender, EventArgs e)
        {
            textBox8.Text = trackBar9.Value.ToString();
        }

        private void trackBar10_Scroll(object sender, EventArgs e)
        {
            textBox10.Text = trackBar10.Value.ToString();
        }

        private void trackBar11_Scroll(object sender, EventArgs e)
        {
            textBox12.Text = trackBar11.Value.ToString();
        }

        private void trackBar12_Scroll(object sender, EventArgs e)
        {
            textBox31.Text = trackBar12.Value.ToString();
        }

        private void trackBar13_Scroll(object sender, EventArgs e)
        {
            textBox33.Text = trackBar13.Value.ToString();
        }

        private void trackBar14_Scroll(object sender, EventArgs e)
        {
            textBox35.Text = trackBar14.Value.ToString();
        }

        private void trackBar15_Scroll(object sender, EventArgs e)
        {
            textBox37.Text = trackBar15.Value.ToString();
        }

        private void trackBar16_Scroll(object sender, EventArgs e)
        {
            textBox13.Text = trackBar16.Value.ToString();
        }

        private void trackBar17_Scroll(object sender, EventArgs e)
        {
            textBox15.Text = trackBar17.Value.ToString();
        }

        private void trackBar18_Scroll(object sender, EventArgs e)
        {
            textBox17.Text = trackBar18.Value.ToString();
        }

        private void trackBar19_Scroll(object sender, EventArgs e)
        {
            textBox19.Text = trackBar19.Value.ToString();
        }

        private void trackBar20_Scroll(object sender, EventArgs e)
        {
            textBox21.Text = trackBar20.Value.ToString();
        }

        private void trackBar21_Scroll(object sender, EventArgs e)
        {
            textBox46.Text = trackBar21.Value.ToString();
        }

        private void trackBar22_Scroll(object sender, EventArgs e)
        {
            textBox40.Text = trackBar22.Value.ToString();
        }

        private void trackBar23_Scroll(object sender, EventArgs e)
        {
            textBox41.Text = trackBar23.Value.ToString();
        }

        private void trackBar24_Scroll(object sender, EventArgs e)
        {
            textBox45.Text = trackBar24.Value.ToString();
        }

    }
}
