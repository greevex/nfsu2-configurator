using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.IO;
using System.Resources;

namespace NFSU2CH
{
    public partial class Form1 : Form
    {
        private int[] s, minis = null;
        private int[] loaded = new int[Properti.map.Length];
        private Parser p, minip;
        private Thread t1;
        private string LOGIN = "GreeveX";
        private string PASSWORD = "";
        private FormAuth fa;
        private int currentCar;
        private bool authbuttonclick = false;
        OpenFileDialog openFileDialog2 = new OpenFileDialog();
        ResourceManager resourceManager = new ResourceManager(typeof(Form1));

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
                MessageBox.Show(resourceManager.GetString("fileNotSelected"));
                return;
            }
            this.s = p.parse(file, Properti.map, pos);
            if (this.s == null)
                return;
            loadCfg(s);
            // Теперь можно сохранять и загружать
            сохранитьНастройкуТекущейМашиныToolStripMenuItem.Enabled = true;
            загрузитьНастройкуДляТекущейМашиныToolStripMenuItem.Enabled = true;


        }

        private bool loadCfg(int[] cfLoad)
        {
            try
            {
                #region добавление в текстбоксы
                /* Колеса */

                //// Расположение колес
                //Передние
                trackBar3.Value = cfLoad[27];
                label12.Text = trackBar3.Value.ToString();
                //Задние
                trackBar5.Value = cfLoad[91];
                label29.Text = trackBar5.Value.ToString();

                //// Ширина колеса
                //Передние
                trackBar4.Value = cfLoad[19];
                label10.Text = trackBar4.Value.ToString();
                //Задние
                trackBar6.Value = cfLoad[83];
                label36.Text = trackBar6.Value.ToString();



                /* Обороты */

                TextBox3.Text = cfLoad[149].ToString(); // Нейтралка
                adval(comboBox24, cfLoad[150]);

                TextBox1.Text = cfLoad[153].ToString(); // Максимально
                adval(comboBox22, cfLoad[154]);

                TextBox2.Text = cfLoad[151].ToString(); // Переключение
                adval(comboBox23, cfLoad[152]);

                /* ЭКУ */

                textBox4.Text = cfLoad[155].ToString(); // 1
                trackBar7.Value = cfLoad[155];

                adval(comboBox3, cfLoad[156]);
                textBox6.Text = cfLoad[157].ToString(); // 2
                trackBar8.Value = cfLoad[157];

                adval(comboBox5, cfLoad[158]);
                textBox8.Text = cfLoad[159].ToString(); // 3
                trackBar9.Value = cfLoad[159];

                adval(comboBox6, cfLoad[160]);
                textBox10.Text = cfLoad[161].ToString();// 4
                trackBar10.Value = cfLoad[161];

                adval(comboBox7, cfLoad[162]);
                textBox12.Text = cfLoad[163].ToString();// 5
                trackBar11.Value = cfLoad[163];

                adval(comboBox8, cfLoad[164]);
                textBox31.Text = cfLoad[165].ToString();// 6
                trackBar12.Value = cfLoad[165];

                adval(comboBox9, cfLoad[166]);
                textBox33.Text = cfLoad[167].ToString();// 7
                trackBar13.Value = cfLoad[167];

                adval(comboBox10, cfLoad[168]);
                textBox35.Text = cfLoad[169].ToString();// 8
                trackBar14.Value = cfLoad[169];

                adval(comboBox11, cfLoad[170]);
                textBox37.Text = cfLoad[171].ToString();// 9
                trackBar15.Value = cfLoad[171];

                adval(comboBox12, cfLoad[172]);

                /* Турбо */

                textBox13.Text = cfLoad[173].ToString();// 1
                trackBar16.Value = cfLoad[173];

                adval(comboBox13, cfLoad[174]);
                textBox15.Text = cfLoad[175].ToString();// 2
                trackBar17.Value = cfLoad[175];

                adval(comboBox14, cfLoad[176]);
                textBox17.Text = cfLoad[177].ToString();// 3
                trackBar18.Value = cfLoad[177];

                adval(comboBox15, cfLoad[178]);
                textBox19.Text = cfLoad[179].ToString();// 4
                trackBar19.Value = cfLoad[179];

                adval(comboBox16, cfLoad[180]);
                textBox21.Text = cfLoad[181].ToString();// 5
                trackBar20.Value = cfLoad[181];

                adval(comboBox17, cfLoad[182]);
                textBox46.Text = cfLoad[183].ToString();// 6
                trackBar21.Value = cfLoad[183];

                adval(comboBox18, cfLoad[184]);
                textBox40.Text = cfLoad[185].ToString();// 7
                trackBar22.Value = cfLoad[185];

                adval(comboBox19, cfLoad[186]);
                textBox41.Text = cfLoad[187].ToString();// 8
                trackBar23.Value = cfLoad[187];

                adval(comboBox20, cfLoad[188]);
                textBox45.Text = cfLoad[189].ToString();// 9
                trackBar24.Value = cfLoad[189];

                adval(comboBox21, cfLoad[190]);

                /* Подвеска */
                maskedTextBox1.Text = cfLoad[11].ToString();
                trackBar25.Value = cfLoad[12];
                label63.Text = trackBar25.Value.ToString();
                maskedTextBox2.Text = cfLoad[75].ToString();
                trackBar26.Value = cfLoad[76];
                label66.Text = trackBar26.Value.ToString();

                /* Управление */

                maskedTextBox3.Text = cfLoad[131].ToString();
                maskedTextBox4.Text = cfLoad[132].ToString();

                maskedTextBox7.Text = cfLoad[135].ToString();
                maskedTextBox8.Text = cfLoad[136].ToString();

                maskedTextBox11.Text = cfLoad[139].ToString();
                maskedTextBox12.Text = cfLoad[140].ToString();

                maskedTextBox15.Text = cfLoad[143].ToString();
                maskedTextBox16.Text = cfLoad[144].ToString();

                #endregion

                return true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return false;
            }
        
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

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            label10.Text = trackBar4.Value.ToString();
        }

        private void trackBar6_Scroll_1(object sender, EventArgs e)
        {
            label36.Text = trackBar6.Value.ToString();
        }

        private void trackBar5_Scroll_1(object sender, EventArgs e)
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
                MessageBox.Show(resourceManager.GetString("nothingToSave"));
                return;
            }

            s = getUserConfigForCurrentCar();

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
            {
                MessageBox.Show(resourceManager.GetString("saveOk"));
            }
            else
                MessageBox.Show(resourceManager.GetString("saveError"));
            this.Invoke((MethodInvoker)(() => this.Activate()));
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
                openNewFileAndCheckIt();
            }
            else
            {
                fa.label3.Text = resourceManager.GetString("authError");
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (s == getUserConfigForCurrentCar())
                this.Close();
            //else MessageBox.Show("Изменения сделаны, но не сохранены, вы уверены, что желаете выйти без сохранения изменений?", "Выход без сохранения изменений", MessageBoxButtons.YesNo);
        }

        private void checkFile(string filename)
        {
            //Проверка файла
            if (File.Exists(filename))
            {
                FileInfo file = new FileInfo(filename);
                if (file.Length < 8008064)
                {
                    if (File.Exists(Directory.GetParent(filename) + "\\GLOBALB.BUN"))
                    {
                        FileInfo file2 = new FileInfo(Directory.GetParent(filename) + "\\GLOBALB.BUN");
                        if (file2.Length < 8008064)
                        {
                            System.Windows.Forms.MessageBox.Show(resourceManager.GetString("badGlobalb"));
                        }
                        else
                        {
                            File.Delete(filename);
                            File.Copy(Directory.GetParent(filename) + "\\GLOBALB.BUN", filename);
                            System.Windows.Forms.MessageBox.Show(resourceManager.GetString("globalbRepaired"));
                        }
                    }
                    else System.Windows.Forms.MessageBox.Show(resourceManager.GetString("badGlobalb"));
                }
                else System.Windows.Forms.MessageBox.Show(resourceManager.GetString("fileLoadOk"));
            }
        }

        private void openNewFileAndCheckIt()
        {
            openFileDialog1.FileName = "GlobalB.lzc";
            openFileDialog1.Filter = resourceManager.GetString("openFileDialogFilter");
            openFileDialog1.FileOk += new CancelEventHandler(openFileDialog1_FileOk);
            openFileDialog1.ShowDialog();
            checkFile(openFileDialog1.FileName);
        }

        private void открытьФайлНатсроекToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openNewFileAndCheckIt();
        }

        void  openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                textBox26.Text = openFileDialog1.FileName.ToString();
                label54.Text = resourceManager.GetString("loadedThenSelectCar");
                comboBox1.Text = resourceManager.GetString("selectCar");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                MessageBox.Show(resourceManager.GetString("fileNotSelected"));
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

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Resources.AboutSoft absoft = new NFSU2CH.Resources.AboutSoft();
            absoft.Show();
        }

        private void создателиИКонтактыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Resources.Contact cont = new NFSU2CH.Resources.Contact();
            cont.Show();
        }

        private void сохранитьНастройкуТекущейМашиныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.DefaultExt = "car";
            saveFileDialog1.FileName = comboBox1.Text + "_" +
                DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
            saveFileDialog1.Filter = resourceManager.GetString("saveFileDialogFilter");
            saveFileDialog1.Title = resourceManager.GetString("saveFileDialogTitle");
            saveFileDialog1.FileOk += new CancelEventHandler(saveFileDialog1_FileOk);
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                Parser pp = new Parser();
                pp.saveConfig(saveFileDialog1.FileName, getUserConfigForCurrentCar());
                MessageBox.Show(resourceManager.GetString("file") + " " + saveFileDialog1.FileName + " " + resourceManager.GetString("saved"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public int[] getUserConfigForCurrentCar()
        {
            #region Проверка данных
            if (TextBox3.Text != "")
            {
                if (Int32.Parse(TextBox3.Text) > 255)
                    TextBox3.Text = "255";
            }
            else TextBox3.Text = "0";

            if (TextBox2.Text != "")
            {
                if (Int32.Parse(TextBox2.Text) > 255)
                    TextBox2.Text = "255";
            }
            else TextBox2.Text = "0";

            if (TextBox1.Text != "")
            {
                if (Int32.Parse(TextBox1.Text) > 255)
                    TextBox1.Text = "255";
            }
            else TextBox1.Text = "0";
            #endregion

            #region получение настроек юзера
            if (s != null)
            {
                int[] cf = s;

                /* Подвеска */
                cf[11] = Int32.Parse(maskedTextBox1.Text);
                cf[12] = trackBar25.Value;
                cf[43] = cf[11];
                cf[44] = cf[12];

                cf[75] = Int32.Parse(maskedTextBox2.Text);
                cf[76] = trackBar26.Value;
                cf[107] = cf[75];
                cf[108] = cf[76];

                /* Колеса */
                //// Расположение
                //Передние
                cf[27] = trackBar3.Value;
                cf[59] = cf[27];
                //Задние
                cf[91] = trackBar5.Value;
                cf[123] = cf[91];

                //// Ширина колеса
                //Передние
                cf[19] = trackBar4.Value;
                cf[51] = cf[19];
                //Задние
                cf[83] = trackBar6.Value;
                cf[115] = cf[83];

                /* Управление */
                //@ToDo: узнать как именно реагируют настройки....
                cf[131] = Int32.Parse(maskedTextBox3.Text);
                cf[132] = Int32.Parse(maskedTextBox4.Text);

                cf[135] = Int32.Parse(maskedTextBox7.Text);
                cf[136] = Int32.Parse(maskedTextBox8.Text);

                cf[139] = Int32.Parse(maskedTextBox11.Text);
                cf[140] = Int32.Parse(maskedTextBox12.Text);

                cf[143] = Int32.Parse(maskedTextBox15.Text);
                cf[144] = Int32.Parse(maskedTextBox16.Text);

                /* Обороты */
                cf[149] = Int32.Parse(TextBox3.Text); // Нейтралка
                cf[150] = Int32.Parse(comboBox24.Text);

                cf[153] = Int32.Parse(TextBox1.Text); // Максимально
                cf[154] = Int32.Parse(comboBox22.Text);

                cf[151] = Int32.Parse(TextBox2.Text); // Переключение
                cf[152] = Int32.Parse(comboBox23.Text);

                /* ЭКУ */

                cf[155] = Int32.Parse(textBox4.Text); // 1
                cf[156] = Int32.Parse(comboBox3.Text);
                cf[157] = Int32.Parse(textBox6.Text); // 2
                cf[158] = Int32.Parse(comboBox5.Text);
                cf[159] = Int32.Parse(textBox8.Text); // 3
                cf[160] = Int32.Parse(comboBox6.Text);
                cf[161] = Int32.Parse(textBox10.Text);// 4
                cf[162] = Int32.Parse(comboBox7.Text);
                cf[163] = Int32.Parse(textBox12.Text);// 5
                cf[164] = Int32.Parse(comboBox8.Text);
                cf[165] = Int32.Parse(textBox31.Text);// 6
                cf[166] = Int32.Parse(comboBox9.Text);
                cf[167] = Int32.Parse(textBox33.Text);// 7
                cf[168] = Int32.Parse(comboBox10.Text);
                cf[169] = Int32.Parse(textBox35.Text);// 8
                cf[170] = Int32.Parse(comboBox11.Text);
                cf[171] = Int32.Parse(textBox37.Text);// 9
                cf[172] = Int32.Parse(comboBox12.Text);

                /* Турбо */

                cf[173] = Int32.Parse(textBox13.Text);// 1
                cf[174] = Int32.Parse(comboBox13.Text);
                cf[175] = Int32.Parse(textBox15.Text);// 2
                cf[176] = Int32.Parse(comboBox14.Text);
                cf[177] = Int32.Parse(textBox17.Text);// 3
                cf[178] = Int32.Parse(comboBox15.Text);
                cf[179] = Int32.Parse(textBox19.Text);// 4
                cf[180] = Int32.Parse(comboBox16.Text);
                cf[181] = Int32.Parse(textBox21.Text);// 5
                cf[182] = Int32.Parse(comboBox17.Text);
                cf[183] = Int32.Parse(textBox46.Text);// 6
                cf[184] = Int32.Parse(comboBox18.Text);
                cf[185] = Int32.Parse(textBox40.Text);// 7
                cf[186] = Int32.Parse(comboBox19.Text);
                cf[187] = Int32.Parse(textBox41.Text);// 8
                cf[188] = Int32.Parse(comboBox20.Text);
                cf[189] = Int32.Parse(textBox45.Text);// 9
                cf[190] = Int32.Parse(comboBox21.Text);

                if (comboBox25.Text == "Задний привод")
                {
                    cf[191] = 0x91;
                    cf[192] = 0xc2;
                    cf[193] = 0x75;
                    cf[194] = 0x3c;
                    cf[195] = 0x57;
                    cf[196] = 0x0e;
                    cf[197] = 0x4d;
                    cf[198] = 0x3f;
                    cf[199] = 0x01;
                    cf[200] = 0x00;
                    cf[201] = 0x00;
                    cf[202] = 0x3e;
                    cf[203] = 0xce;
                    cf[204] = 0xcc;
                    cf[205] = 0x4c;
                    cf[206] = 0x3d;
                }
                else if (comboBox25.Text == "Передний привод")
                {
                    cf[191] = 0x91;
                    cf[192] = 0xc2;
                    cf[193] = 0x75;
                    cf[194] = 0x3c;
                    cf[195] = 0xa9;
                    cf[196] = 0xc6;
                    cf[197] = 0x4b;
                    cf[198] = 0x3e;
                    cf[199] = 0x01;
                    cf[200] = 0x00;
                    cf[201] = 0x00;
                    cf[202] = 0x3e;
                    cf[203] = 0x91;
                    cf[204] = 0xc2;
                    cf[205] = 0x75;
                    cf[206] = 0x3d;
                }
                else
                {
                    cf[191] = 0x91;
                    cf[192] = 0xc2;
                    cf[193] = 0x75;
                    cf[194] = 0x3c;
                    cf[195] = 0x9b;
                    cf[196] = 0x99;
                    cf[197] = 0x19;
                    cf[198] = 0x3f;
                    cf[199] = 0x01;
                    cf[200] = 0x00;
                    cf[201] = 0x00;
                    cf[202] = 0x3e;
                    cf[203] = 0x91;
                    cf[204] = 0xc2;
                    cf[205] = 0x75;
                    cf[206] = 0x3d;
                }

            #endregion
                return cf;
            }
            else return null;
        }

        private void изФайлаНастроекcarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog2.Title = resourceManager.GetString("carFileOpen");
            openFileDialog2.Filter = resourceManager.GetString("saveFileDialogFilter");
            openFileDialog2.FileOk += new CancelEventHandler(openFileDialog2_FileOk);
            openFileDialog2.ShowDialog();
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            int key = 0;
            Stream fr = new StreamReader(openFileDialog2.FileName).BaseStream;
            while (true)
            {
                int rb = fr.ReadByte();
                if (rb == -1)
                    break;
                loaded[key] = rb;
                key++;
            }
            if (!loadCfg(loaded))
                MessageBox.Show(resourceManager.GetString("fileLoadError") + " " + openFileDialog2.FileName + " !");
        }

        private void загрузитьНастройкуДляТекущейМашиныToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
