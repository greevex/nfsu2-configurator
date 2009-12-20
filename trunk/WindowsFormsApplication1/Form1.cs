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
using System.Diagnostics;

namespace NFSU2CH
{
    public partial class Form1 : Form
    {
        private int[] privod, privodfull, s, minis, rwd = null;
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.loadCnf(Properti.CARS[0]);
        }

        private void loadCnf(int pos)
        {
            /* Загрузка */
            if (this.textBox26.Text == "")
            {
                MessageBox.Show(resourceManager.GetString("fileNotSelected"));
                return;
            }
            this.currentCar = pos;
            this.p = new Parser(this.textBox26.Text);
            this.s = p.parse(pos);
            AddValToForm();
            // Теперь можно сохранять и загружать
            сохранитьНастройкуТекущейМашиныToolStripMenuItem.Enabled = true;
            загрузитьНастройкуДляТекущейМашиныToolStripMenuItem.Enabled = true;
        }

        private bool AddValToForm()
        {
            try
            {
                #region добавление в текстбоксы

                /* Колеса */

                //// Расположение колес
                //Передние
                trackBar3.Value = this.s[318];
                label12.Text = trackBar3.Value.ToString();
                //Задние
                trackBar5.Value = this.s[414];
                label29.Text = trackBar5.Value.ToString();

                //// Ширина колеса
                //Передние
                trackBar4.Value = s[310];
                label10.Text = trackBar4.Value.ToString();
                //Задние
                trackBar6.Value = s[406];
                label36.Text = trackBar6.Value.ToString();

                //// Положение колес (вперед-назад)
                //Передние
                trackBar1.Value = s[290];
                trackBar2.Value = s[386];
                trackBar27.Value = s[354] = s[306];
                label72.Text = trackBar27.Value.ToString();
                trackBar28.Value = s[450] = s[402];
                label70.Text = trackBar28.Value.ToString();

                label13.Text = s[290].ToString();
                label14.Text = s[386].ToString();

                maskedTextBox5.Text = s[320].ToString();
                maskedTextBox6.Text = s[321].ToString();
                maskedTextBox9.Text = s[322].ToString();
                maskedTextBox10.Text = s[323].ToString();

                maskedTextBox19.Text = s[368].ToString();
                maskedTextBox20.Text = s[369].ToString();
                maskedTextBox21.Text = s[370].ToString();
                maskedTextBox22.Text = s[371].ToString();

                maskedTextBox27.Text = s[419].ToString();
                maskedTextBox28.Text = s[432].ToString();
                maskedTextBox29.Text = s[433].ToString();
                maskedTextBox30.Text = s[434].ToString();

                maskedTextBox35.Text = s[464].ToString();
                maskedTextBox36.Text = s[465].ToString();
                maskedTextBox37.Text = s[466].ToString();
                maskedTextBox38.Text = s[467].ToString();


                /* Обороты */

                TextBox3.Text = s[770].ToString(); // Нейтралка
                adval(comboBox24, s[771]);

                TextBox1.Text = s[778].ToString(); // Максимально
                adval(comboBox22, s[779]);

                TextBox2.Text = s[774].ToString(); // Переключение
                adval(comboBox23, s[775]);

                /* ЭКУ */

                textBox4.Text = s[786].ToString(); // 1
                trackBar7.Value = s[786];
                adval(comboBox3, s[787]);

                textBox6.Text = s[790].ToString(); // 2
                trackBar8.Value = s[790];
                adval(comboBox5, s[791]);

                textBox8.Text = s[794].ToString(); // 3
                trackBar9.Value = s[794];
                adval(comboBox6, s[795]);

                textBox10.Text = s[798].ToString();// 4
                trackBar10.Value = s[798];
                adval(comboBox7, s[799]);

                textBox12.Text = s[802].ToString();// 5
                trackBar11.Value = s[802];
                adval(comboBox8, s[803]);

                textBox31.Text = s[806].ToString();// 6
                trackBar12.Value = s[806];
                adval(comboBox9, s[807]);

                textBox33.Text = s[810].ToString();// 7
                trackBar13.Value = s[810];
                adval(comboBox10, s[811]);

                textBox35.Text = s[814].ToString();// 8
                trackBar14.Value = s[814];
                adval(comboBox11, s[815]);

                textBox37.Text = s[818].ToString();// 9
                trackBar15.Value = s[818];
                adval(comboBox12, s[819]);

                /* Турбо */

                textBox13.Text = s[834].ToString();// 1
                trackBar16.Value = s[834];
                adval(comboBox13, s[835]);

                textBox15.Text = s[838].ToString();// 2
                trackBar17.Value = s[838];
                adval(comboBox14, s[839]);

                textBox17.Text = s[842].ToString();// 3
                trackBar18.Value = s[842];
                adval(comboBox15, s[843]);

                textBox19.Text = s[846].ToString();// 4
                trackBar19.Value = s[846];
                adval(comboBox16, s[847]);

                textBox21.Text = s[850].ToString();// 5
                trackBar20.Value = s[850];
                adval(comboBox17, s[851]);

                textBox46.Text = s[854].ToString();// 6
                trackBar21.Value = s[854];
                adval(comboBox18, s[855]);

                textBox40.Text = s[858].ToString();// 7
                trackBar22.Value = s[858];
                adval(comboBox19, s[859]);

                textBox41.Text = s[862].ToString();// 8
                trackBar23.Value = s[862];
                adval(comboBox20, s[863]);

                textBox45.Text = s[866].ToString();// 9
                trackBar24.Value = s[866];
                adval(comboBox21, s[867]);

                /* Подвеска */
                maskedTextBox1.Text = s[298].ToString();
                trackBar25.Value = s[299];
                label63.Text = trackBar25.Value.ToString();
                maskedTextBox2.Text = s[394].ToString();
                trackBar26.Value = s[395];
                label66.Text = trackBar26.Value.ToString();

                /* Управление */

                maskedTextBox3.Text = s[546].ToString();
                maskedTextBox4.Text = s[547].ToString();

                maskedTextBox7.Text = s[550].ToString();
                maskedTextBox8.Text = s[551].ToString();

                maskedTextBox11.Text = s[554].ToString();
                maskedTextBox12.Text = s[555].ToString();

                maskedTextBox15.Text = s[558].ToString();
                maskedTextBox16.Text = s[559].ToString();

                #endregion

                return true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return false;
            }

        }
        #region event handlers
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

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label13.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label14.Text = trackBar1.Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (p.main == null)
            {
                MessageBox.Show(resourceManager.GetString("nothingToSave"));
                return;
            }
            //обновление int[] this.s
            getUserConfigForCurrentCar();

            this.progressBar1.Maximum = this.p.Total;
            this.progressBar1.Value = 0;
            this.t1 = new Thread(new ThreadStart(saveT));
            Thread t = new Thread(new ThreadStart(this.prgs));
            t1.Start();
            t.Start();
        }
        #endregion
        private void saveT()
        {
            if (this.p.save(this.currentCar, this.s))
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
            if (textBox26.Text == "")
            {
                MessageBox.Show(resourceManager.GetString("fileNotSelected"));
                return;
            }
            this.minis = p.parse(Properti.getPosition(this.comboBox2.Text));
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
                getUserConfigForCurrentCar();
                p.saveConfig(this.saveFileDialog1.FileName, this.s);
                MessageBox.Show(resourceManager.GetString("file") + " " + saveFileDialog1.FileName + " " + resourceManager.GetString("saved"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void getUserConfigForCurrentCar()
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

                /* Пыщ! */

                s[290] = trackBar1.Value;
                //s[338] = s[290];
                s[386] = trackBar2.Value;
                //s[434] = s[386];
                s[354] = trackBar27.Value;
                s[306] = trackBar27.Value;
                s[450] = trackBar28.Value;
                s[402] = trackBar28.Value;

                s[320] = Int32.Parse(maskedTextBox5.Text);
                s[321] = Int32.Parse(maskedTextBox6.Text);
                s[322] = Int32.Parse(maskedTextBox9.Text);
                s[323] = Int32.Parse(maskedTextBox10.Text);

                s[368] = Int32.Parse(maskedTextBox19.Text);
                s[369] = Int32.Parse(maskedTextBox20.Text);
                s[370] = Int32.Parse(maskedTextBox21.Text);
                s[371] = Int32.Parse(maskedTextBox22.Text);

                s[419] = Int32.Parse(maskedTextBox27.Text);
                s[420] = Int32.Parse(maskedTextBox28.Text);
                s[421] = Int32.Parse(maskedTextBox29.Text);
                s[422] = Int32.Parse(maskedTextBox30.Text);

                s[464] = Int32.Parse(maskedTextBox35.Text);
                s[465] = Int32.Parse(maskedTextBox36.Text);
                s[466] = Int32.Parse(maskedTextBox37.Text);
                s[467] = Int32.Parse(maskedTextBox38.Text);

                /* Подвеска */
                s[298] = Int32.Parse(maskedTextBox1.Text);
                s[299] = trackBar25.Value;
                s[346] = s[298];
                s[347] = s[299];

                s[394] = Int32.Parse(maskedTextBox2.Text);
                s[395] = trackBar26.Value;
                s[442] = s[394];
                s[443] = s[395];

                /* Колеса */
                //// Расположение
                //Передние
                s[318] = trackBar3.Value;
                s[366] = s[318];
                int cf_temp;
                if (s[318] >= 30)
                {
                    cf_temp = s[318] - 30;
                }
                else cf_temp = s[318];
                s[294] = cf_temp;
                s[342] = cf_temp;
                //Задние
                s[414] = trackBar5.Value;
                s[462] = s[414];
                if (s[414] >= 30)
                {
                    cf_temp = s[414] - 30;
                }
                else cf_temp = s[414];
                s[390] = cf_temp;
                s[438] = cf_temp;

                //// Ширина колеса
                //Передние
                s[310] = trackBar4.Value;
                s[358] = s[310];
                //Задние
                s[406] = trackBar6.Value;
                s[454] = s[406];

                /* Управление */
                //@ToDo: узнать как именно реагируют настройки....
                s[546] = Int32.Parse(maskedTextBox3.Text);
                s[547] = Int32.Parse(maskedTextBox4.Text);

                s[550] = Int32.Parse(maskedTextBox7.Text);
                s[551] = Int32.Parse(maskedTextBox8.Text);

                s[554] = Int32.Parse(maskedTextBox11.Text);
                s[555] = Int32.Parse(maskedTextBox12.Text);

                s[558] = Int32.Parse(maskedTextBox15.Text);
                s[559] = Int32.Parse(maskedTextBox16.Text);

                /* Обороты */
                s[770] = Int32.Parse(TextBox3.Text); // Нейтралка
                s[771] = Int32.Parse(comboBox24.Text);

                s[778] = Int32.Parse(TextBox1.Text); // Максимально
                s[779] = Int32.Parse(comboBox22.Text);

                s[774] = Int32.Parse(TextBox2.Text); // Переключение
                s[775] = Int32.Parse(comboBox23.Text);

                /* ЭКУ */

                s[786] = Int32.Parse(textBox4.Text); // 1
                s[787] = Int32.Parse(comboBox3.Text);
                s[790] = Int32.Parse(textBox6.Text); // 2
                s[791] = Int32.Parse(comboBox5.Text);
                s[794] = Int32.Parse(textBox8.Text); // 3
                s[795] = Int32.Parse(comboBox6.Text);
                s[798] = Int32.Parse(textBox10.Text);// 4
                s[799] = Int32.Parse(comboBox7.Text);
                s[802] = Int32.Parse(textBox12.Text);// 5
                s[803] = Int32.Parse(comboBox8.Text);
                s[806] = Int32.Parse(textBox31.Text);// 6
                s[807] = Int32.Parse(comboBox9.Text);
                s[810] = Int32.Parse(textBox33.Text);// 7
                s[811] = Int32.Parse(comboBox10.Text);
                s[814] = Int32.Parse(textBox35.Text);// 8
                s[815] = Int32.Parse(comboBox11.Text);
                s[818] = Int32.Parse(textBox37.Text);// 9
                s[819] = Int32.Parse(comboBox12.Text);

                /* Турбо */

                s[834] = Int32.Parse(textBox13.Text);// 1
                s[835] = Int32.Parse(comboBox13.Text);
                s[838] = Int32.Parse(textBox15.Text);// 2
                s[839] = Int32.Parse(comboBox14.Text);
                s[842] = Int32.Parse(textBox17.Text);// 3
                s[843] = Int32.Parse(comboBox15.Text);
                s[846] = Int32.Parse(textBox19.Text);// 4
                s[847] = Int32.Parse(comboBox16.Text);
                s[850] = Int32.Parse(textBox21.Text);// 5
                s[851] = Int32.Parse(comboBox17.Text);
                s[854] = Int32.Parse(textBox46.Text);// 6
                s[855] = Int32.Parse(comboBox18.Text);
                s[858] = Int32.Parse(textBox40.Text);// 7
                s[859] = Int32.Parse(comboBox19.Text);
                s[862] = Int32.Parse(textBox41.Text);// 8
                s[863] = Int32.Parse(comboBox20.Text);
                s[866] = Int32.Parse(textBox45.Text);// 9
                s[867] = Int32.Parse(comboBox21.Text);
            #endregion
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
            try
            {
                int key = 0;
                Stream fr = new StreamReader(openFileDialog2.FileName).BaseStream;
                while (true)
                {
                    int rb = fr.ReadByte();
                    if (rb == -1)
                        break;
                    s[key] = rb;
                    key++;
                }
                AddValToForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(resourceManager.GetString("fileLoadError") + " " + openFileDialog2.FileName + " !\n"+ex.Message);
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void trackBar27_Scroll(object sender, EventArgs e)
        {
            label72.Text = trackBar27.Value.ToString(); ;
        }

        private void trackBar28_Scroll(object sender, EventArgs e)
        {
            label70.Text = trackBar28.Value.ToString();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Directory.GetParent(Directory.GetParent(p.filename).FullName).FullName + "\\speed2.exe");
        }

        private void startWindowedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Directory.GetParent(Directory.GetParent(p.filename).FullName).FullName + "\\Launcher.exe");
        }
    }
}
