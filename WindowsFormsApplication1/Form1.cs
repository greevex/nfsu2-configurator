using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace NFSU2CH
{
    public partial class Form1 : Form
    {
        private int[] s,minis = null;
        private Parser p, minip;
        private Thread t1;
        private string LOGIN = "GreeveX";
        private string PASSWORD = "";
        private FormAuth fa;
        private int currentCar;
        private bool authbuttonclick = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void adval(System.Windows.Forms.ComboBox cb, int val)
        {
            cb.Items.Clear();
            if (val == 0)
            {
                cb.Items.AddRange(new object[1] { val });
                cb.DropDownStyle = ComboBoxStyle.DropDown;
            }
            else
            {
                cb.Items.AddRange(new object[3] { val - 1, val, val + 1 });
            }
            cb.Text = val.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.loadCnf(Properti.CARS[0]);
        }

        private void loadCnf(int pos)
        {
            /* Загрузка */
            this.currentCar = pos;
            this.p = new Parser();
            string file = this.textBox26.Text;
            if (file == "")
            {
                MessageBox.Show("Не выбран файл настроек! Выберите файл, нажав пункт Меню -> Открыть файл настроек...!");
                return;
            }
            this.s = p.parse(file, Properti.map, pos);
            if (this.s == null)
                return;
            #region добавление в текстбоксы
            /* Колеса */

            //// Расположение колес
            //Передние
            trackBar3.Value = s[27];
            label12.Text = trackBar3.Value.ToString();
            //Задние
            trackBar5.Value = s[91];
            label29.Text = trackBar5.Value.ToString();

            //// Ширина колеса
            //Передние
            trackBar4.Value = s[19];
            label10.Text = trackBar4.Value.ToString();
            //Задние
            trackBar6.Value = s[83];
            label36.Text = trackBar6.Value.ToString();
            


            /* Обороты */

            TextBox3.Text = s[149].ToString(); // Нейтралка
            adval(comboBox24, s[150]);

            TextBox1.Text = s[153].ToString(); // Максимально
            adval(comboBox22, s[154]);

            TextBox2.Text = s[151].ToString(); // Переключение
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

            trackBar25.Value = s[12];
            label63.Text = trackBar25.Value.ToString();
            trackBar26.Value = s[76];
            label66.Text = trackBar26.Value.ToString();
            
            /* Управление */

            maskedTextBox3.Text = s[131].ToString();
            maskedTextBox4.Text = s[132].ToString();

            maskedTextBox7.Text = s[135].ToString();
            maskedTextBox8.Text = s[136].ToString();

            maskedTextBox11.Text = s[139].ToString();
            maskedTextBox12.Text = s[140].ToString();

            maskedTextBox15.Text = s[143].ToString();
            maskedTextBox16.Text = s[144].ToString();

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

        private void button2_Click(object sender, EventArgs e)
        {
            if (s == null)
            {
                MessageBox.Show("Сохранять нечего!");
                return;
            }

            #region Проверка данных
            if (TextBox3.Text != "")
            {
                if (Int32.Parse(TextBox3.Text) > 255)
                    TextBox3.Text = "255";
            } else TextBox3.Text = "0";

            if (TextBox2.Text != "")
            {
                if (Int32.Parse(TextBox2.Text) > 255)
                    TextBox2.Text = "255";
            } else TextBox2.Text = "0";

            if (TextBox1.Text != "")
            {
                if (Int32.Parse(TextBox1.Text) > 255)
                    TextBox1.Text = "255";
            }
            else TextBox1.Text = "0";
            #endregion

            #region получение настроек юзера

            /* Подвеска */
            s[12] = trackBar25.Value;
            s[44] = s[12];
            s[76] = trackBar26.Value;
            s[108] = s[76];

            /* Колеса */
            //// Расположение
            //Передние
            s[27] = trackBar3.Value;
            s[59] = s[27];
            //Задние
            s[91] = trackBar5.Value;
            s[123] = s[91];

            //// Ширина колеса
            //Передние
            s[19] = trackBar4.Value;
            s[51] = s[19];
            //Задние
            s[83] = trackBar6.Value;
            s[115] = s[83];

            /* Управление */
            //@ToDo: узнать как именно реагируют настройки....
            s[131] = Int32.Parse(maskedTextBox3.Text);
            s[132] = Int32.Parse(maskedTextBox4.Text);

            s[135] = Int32.Parse(maskedTextBox7.Text);
            s[136] = Int32.Parse(maskedTextBox8.Text);

            s[139] = Int32.Parse(maskedTextBox11.Text);
            s[140] = Int32.Parse(maskedTextBox12.Text);

            s[143] = Int32.Parse(maskedTextBox15.Text);
            s[144] = Int32.Parse(maskedTextBox16.Text);

            /* Обороты */
            s[149] = Int32.Parse(TextBox3.Text); // Нейтралка
            s[150] = Int32.Parse(comboBox24.Text);

            s[153] = Int32.Parse(TextBox1.Text); // Максимально
            s[154] = Int32.Parse(comboBox22.Text);

            s[151] = Int32.Parse(TextBox2.Text); // Переключение
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
            #endregion
            this.progressBar1.Maximum = this.p.Total;
            this.progressBar1.Value = 0;
            this.t1 = new Thread(new ThreadStart(saveT));
            Thread t = new Thread(new ThreadStart(this.prgs));
            t1.Start();
            t.Start();
        }
           
        private void saveT()
        {
            if (this.p.save(this.textBox26.Text, Properti.map, this.s, this.currentCar) == true)
                MessageBox.Show("Изменения сохранены!");
            else
                MessageBox.Show("Во время сохранения произошла ошибка. Изменения не сохранены!");
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

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.fa = new FormAuth();
            fa.button1.Click +=new EventHandler(authclick);
            fa.FormClosed += new FormClosedEventHandler(fa_FormClosed);
            //
            fa.Show();
            fa.Activate();
        }

        void fa_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(this.authbuttonclick == false)
                Application.Exit();
        }
        private void authclick(object sender, EventArgs e)
        {
            if (this.LOGIN == fa.textBox2.Text && this.PASSWORD == fa.textBox1.Text)
            {
                this.authbuttonclick = true;
                fa.Close();
                this.Enabled = true;
                this.Activate();
            }
            else
            {
                fa.label3.Text = "Ошибка авторизации!";
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void открытьФайлНатсроекToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.FileName = "GlobalB.lzc";
            this.openFileDialog1.Filter = "Файл настроек NFSU2|GlobalB.lzc";
            openFileDialog1.ShowDialog();
            textBox26.Text = openFileDialog1.FileName.ToString();
            label54.Text = "Файл ОК! Выберите машину!";
            comboBox1.Text = "Теперь выберите машину...";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pos = Properti.getPosition(this.comboBox1.Text);
            this.loadCnf(pos);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            maskedTextBox3.Text = minis[1].ToString();
            maskedTextBox4.Text = minis[2].ToString();

            maskedTextBox7.Text = minis[3].ToString();
            maskedTextBox8.Text = minis[4].ToString();

            maskedTextBox11.Text = minis[5].ToString();
            maskedTextBox12.Text = minis[6].ToString();

            maskedTextBox15.Text = minis[7].ToString();
            maskedTextBox16.Text = minis[8].ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            maskedTextBox3.Text = s[131].ToString();
            maskedTextBox4.Text = s[132].ToString();

            maskedTextBox7.Text = s[135].ToString();
            maskedTextBox8.Text = s[136].ToString();

            maskedTextBox11.Text = s[139].ToString();
            maskedTextBox12.Text = s[140].ToString();

            maskedTextBox15.Text = s[143].ToString();
            maskedTextBox16.Text = s[144].ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.minip = new Parser();
            string file = this.textBox26.Text;
            if (file == "")
            {
                MessageBox.Show("Не выбран файл настроек! Выберите файл, нажав пункт Меню -> Открыть файл настроек...!");
                return;
            }
            this.minis = minip.parse(file, Properti.minimap, Properti.getPosition(this.comboBox2.Text));
            if (this.minis == null)
                return;
        }

        private void trackBar25_Scroll(object sender, EventArgs e)
        {
            label63.Text = trackBar25.Value.ToString();
        }

        private void trackBar26_Scroll(object sender, EventArgs e)
        {
            label66.Text = trackBar26.Value.ToString();
        }

        private void comboBox25_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox25.Text == "Задний привод")
            {
                s[191] = 0x91;
                s[192] = 0xc2;
                s[193] = 0x75;
                s[194] = 0x3c;
                s[195] = 0x57;
                s[196] = 0x0e;
                s[197] = 0x4d;
                s[198] = 0x3f;
                s[199] = 0x01;
                s[200] = 0x00;
                s[201] = 0x00;
                s[202] = 0x3e;
                s[203] = 0xce;
                s[204] = 0xcc;
                s[205] = 0x4c;
                s[206] = 0x3d;
            }
            else if (comboBox25.Text == "Передний привод")
            {
                s[191] = 0x91;
                s[192] = 0xc2;
                s[193] = 0x75;
                s[194] = 0x3c;
                s[195] = 0xa9;
                s[196] = 0xc6;
                s[197] = 0x4b;
                s[198] = 0x3e;
                s[199] = 0x01;
                s[200] = 0x00;
                s[201] = 0x00;
                s[202] = 0x3e;
                s[203] = 0x91;
                s[204] = 0xc2;
                s[205] = 0x75;
                s[206] = 0x3d;
            }
            else
            {
                s[191] = 0x91;
                s[192] = 0xc2;
                s[193] = 0x75;
                s[194] = 0x3c;
                s[195] = 0x9b;
                s[196] = 0x99;
                s[197] = 0x19;
                s[198] = 0x3f;
                s[199] = 0x01;
                s[200] = 0x00;
                s[201] = 0x00;
                s[202] = 0x3e;
                s[203] = 0x91;
                s[204] = 0xc2;
                s[205] = 0x75;
                s[206] = 0x3d;
            }
        }
    }
}
