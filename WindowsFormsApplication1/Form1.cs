//#define ENABLE_AUTH;
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
using System.Runtime.InteropServices;
namespace NFSU2CH
{
    public partial class Form1 : Form
    {
        private int[] s, minis = null;
        private Parser p;
        private Thread t1;
        private int currentCar, res_w=640, res_h=480;
        OpenFileDialog openFileDialog2 = new OpenFileDialog();
        ResourceManager resourceManager;
        MemoryFreeze mf;
        Process[] gameproc;
        U2cfg u2c = new U2cfg();
        List<TrackBar> tracks = new List<TrackBar>();
        List<int> tracks_v = new List<int>();

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

#if ENABLE_AUTH
        private FormAuth fa;
        private string LOGIN = "GreeveX";
        private string PASSWORD = "";
        private bool authbuttonclick = false;
#endif

        public Form1()
        {
            if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ru" && File.Exists(".\\ru\\U2CarHacker.resources.dll"))
                this.resourceManager = lang_ru.ResourceManager;
            else
            {
                this.resourceManager = lang_eng.ResourceManager;
            }
            InitializeComponent();
            openFileDialog2.FileOk += new CancelEventHandler(openFileDialog2_FileOk);
        }

        private void adval(System.Windows.Forms.ComboBox cb, int val)
        {
            cb.Items.Clear();
            if (val == 0)
            {
                //val = 62;
                //cb.DropDownStyle = ComboBoxStyle.DropDown;
                cb.Items.AddRange(new object[1] { val });
            } else
            cb.Items.AddRange(new object[3] { val - 1, val, val + 1 });
            cb.Text = val.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.loadCnf(Properti.CARS[0]);
        }

        private void loadCnf(int pos)
        {
            /* Загрузка */
            this.currentCar = pos;
            this.s = p.parse(pos);
            AddValToForm();
            // Теперь можно сохранять и загружать
            сохранитьНастройкуТекущейМашиныToolStripMenuItem.Enabled = true;
            загрузитьНастройкуДляТекущейМашиныToolStripMenuItem.Enabled = true;
        }

        public int maxt = 0, mint = 0;
        private void addToTrack(TrackBar t, int val1, int val2) {
            int val = Convert.ToInt32("0x" + val2.ToString("X2") + val1.ToString("X2"), 16);
            if (val > 0 && val < this.mint)
                this.mint = val;
            else if (val > this.maxt)
                this.maxt = val;
            t.Maximum = val;
            t.Value = val;
            // добавление трекбара в коллекцию.
            this.tracks.Add(t);
        }

        public void setTrackbarsMinMax()
        {
            int i = 0;
            foreach (TrackBar tt in this.tracks)
            {
                tt.Maximum = this.maxt;
                tt.Minimum = this.mint;
                i++;
            }
        }

        private bool AddValToForm()
        {
            try
            {
                #region добавление значений в гуй

                /* Обороты */

                TextBox3.Text = s[770].ToString(); // Нейтралка
                adval(comboBox24, s[771]);

                TextBox1.Text = s[778].ToString(); // Максимально
                adval(comboBox22, s[779]);

                TextBox2.Text = s[774].ToString(); // Переключение
                adval(comboBox23, s[775]);

                /* ЭКУ */

                // 1
                addToTrack(trackBar7, s[786], s[787]);

                // 2
                addToTrack(trackBar8, s[790], s[791]);

                // 3
                addToTrack(trackBar9, s[794], s[795]);

                // 4
                addToTrack(trackBar10, s[798], s[799]);

                // 5
                addToTrack(trackBar11, s[802], s[803]);

                // 6
                addToTrack(trackBar12, s[806], s[807]);

                // 7
                addToTrack(trackBar13, s[810], s[811]);

                // 8
                addToTrack(trackBar14, s[814], s[815]);

                // 9
                addToTrack(trackBar15, s[818], s[819]);

                /* Турбо */

                // 1
                addToTrack(trackBar16, s[834], s[835]);

                // 2
                addToTrack(trackBar17, s[838], s[839]);

                // 3
                addToTrack(trackBar18, s[842], s[843]);

                // 4
                addToTrack(trackBar19, s[846], s[847]);

                // 5
                addToTrack(trackBar20, s[850], s[851]);

                // 6
                addToTrack(trackBar21, s[854], s[855]);

                // 7
                addToTrack(trackBar22, s[858], s[859]);

                // 8
                addToTrack(trackBar23, s[862], s[863]);

                // 9
                addToTrack(trackBar24, s[866], s[867]);

                /* Подвеска */
                maskedTextBox1.Text = s[298].ToString();
                trackBar25.Value = s[299];
                label63.Text = trackBar25.Value.ToString();
                maskedTextBox2.Text = s[394].ToString();
                trackBar26.Value = s[395];
                label66.Text = trackBar26.Value.ToString();

                /* Управление */

                trackBar29.Value = s[546];
                label80.Text = s[546].ToString();
                adval(comboBox26, s[547]);

                trackBar30.Value = s[550];
                label81.Text = s[550].ToString();
                adval(comboBox27, s[551]);

                trackBar31.Value = s[554];
                label82.Text = s[554].ToString();
                adval(comboBox28, s[555]);

                trackBar32.Value = s[558];
                label83.Text = s[558].ToString();
                adval(comboBox29, s[559]);

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

                #endregion

                setTrackbarsMinMax();

                return true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("!!!!!!!!!" + e.Message);
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
            label14.Text = trackBar2 .Value.ToString();
        }

        private void trackBar25_Scroll(object sender, EventArgs e)
        {
            label63.Text = trackBar25.Value.ToString();
        }

        private void trackBar26_Scroll(object sender, EventArgs e)
        {
            label66.Text = trackBar26.Value.ToString();
        }

        private void trackBar27_Scroll(object sender, EventArgs e)
        {
            label72.Text = trackBar27.Value.ToString(); ;
        }

        private void trackBar28_Scroll(object sender, EventArgs e)
        {
            label70.Text = trackBar28.Value.ToString();
        }

        private void trackBar29_Scroll(object sender, EventArgs e)
        {
            label80.Text = trackBar29.Value.ToString();
        }

        private void trackBar30_Scroll(object sender, EventArgs e)
        {
            label81.Text = trackBar30.Value.ToString();
        }

        private void trackBar31_Scroll(object sender, EventArgs e)
        {
            label82.Text = trackBar31.Value.ToString();
        }

        private void trackBar32_Scroll(object sender, EventArgs e)
        {
            label83.Text = trackBar32.Value.ToString();
        }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            if (label54.Visible) label54.Visible = false;
            if (p.main == null)
            {
                this.toolStripStatusLabel1.Text = (resourceManager.GetString("nothingToSave"));
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

        private void saveT()
        {
            if (this.p.save(this.currentCar, this.s))
            {
                this.Invoke((MethodInvoker)(()=> this.toolStripStatusLabel1.Text = (resourceManager.GetString("saveOk"))));
            }
            else
               this.Invoke((MethodInvoker)(() => this.toolStripStatusLabel1.Text =(resourceManager.GetString("saveError"))));
            this.Invoke((MethodInvoker)(() => this.Activate()));
        }

        void prgs()
        {
            this.Invoke((MethodInvoker)(() => this.Enabled = false));
            while (t1.IsAlive)
            {
                progressBar1.ProgressBar.Invoke((MethodInvoker)(() => progressBar1.Value = this.p.Current));
                Thread.Sleep(10);
            }
            this.Invoke((MethodInvoker)(() => this.Enabled = true));
        }
        #region авторизация
        private void Form1_Load(object sender, EventArgs e)
        {
#if ENABLE_AUTH
            this.Enabled = false;
            this.fa = new FormAuth();
            fa.button1.Click +=new EventHandler(authclick);
            fa.FormClosed += new FormClosedEventHandler(fa_FormClosed);
            //
            fa.Show();
            fa.Activate();
#endif
        }
#if ENABLE_AUTH
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
#endif
        #endregion
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
                this.Close();
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
                else
                {
                    this.toolStripStatusLabel1.Text = (resourceManager.GetString("fileLoadOk"));
                    this.p = new Parser(this.textBox26.Text);
                    p.filename = filename;
                    startWindowedToolStripMenuItem.Enabled = true;
                    button3.Enabled = true;
                    comboBox1.Enabled = true;
                    tabControl1.Enabled = true;
                    openMainFileToolStripMenuItem.Enabled = false;
                }
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
            if (comboBox25.Text != null) comboBox25.Text = null;
            if (!button4.Enabled) button4.Enabled = true;
            if (!button2.Enabled) button2.Enabled = true;
            int pos = Properti.getPosition(this.comboBox1.Text);
            this.loadCnf(pos);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Parser p2 = new Parser(p.filename);
            this.minis = p2.parse(Properti.getPosition(this.comboBox2.Text));
            if (this.minis == null)
                return;

            trackBar29.Value = minis[546];
            label80.Text = minis[546].ToString();
            comboBox26.Text = minis[547].ToString();

            trackBar30.Value = minis[550];
            label81.Text = minis[550].ToString();
            comboBox27.Text = minis[551].ToString();

            trackBar31.Value = minis[554];
            label82.Text = minis[554].ToString();
            comboBox28.Text = minis[555].ToString();

            trackBar32.Value = minis[558];
            label83.Text = minis[558].ToString();
            comboBox29.Text = minis[559].ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            trackBar29.Value = p.main[546];
            label80.Text = p.main[546].ToString();
            adval(comboBox26, p.main[547]);

            trackBar30.Value = p.main[550];
            label81.Text = p.main[550].ToString();
            adval(comboBox27, p.main[551]);

            trackBar31.Value = p.main[554];
            label82.Text = p.main[554].ToString();
            adval(comboBox28, p.main[555]);

            trackBar32.Value = p.main[558];
            label83.Text = p.main[558].ToString();
            adval(comboBox29, p.main[559]);

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox26.Text == "")
            {
                this.toolStripStatusLabel1.Text = (resourceManager.GetString("fileNotSelected"));
                return;
            }
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
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                getUserConfigForCurrentCar();
                p.saveConfig(this.saveFileDialog1.FileName, this.s, this.currentCar);
                this.toolStripStatusLabel1.Text = (resourceManager.GetString("file") + " " + saveFileDialog1.FileName + " " + resourceManager.GetString("saved"));
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
                s[338] = s[290];
                s[386] = trackBar2.Value;
                s[434] = s[386];
                s[354] = trackBar27.Value;
                s[306] = trackBar27.Value;
                s[450] = trackBar28.Value;
                s[402] = trackBar28.Value;

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
                s[546] = trackBar29.Value;
                s[547] = Int32.Parse(comboBox26.Text);

                s[550] = trackBar30.Value;
                s[551] = Int32.Parse(comboBox27.Text);

                s[554] = trackBar31.Value;
                s[555] = Int32.Parse(comboBox28.Text);

                s[558] = trackBar32.Value;
                s[559] = Int32.Parse(comboBox29.Text);

                /* Обороты */
                s[770] = Int32.Parse(TextBox3.Text); // Нейтралка
                s[771] = Int32.Parse(comboBox24.Text);

                s[778] = Int32.Parse(TextBox1.Text); // Максимально
                s[779] = Int32.Parse(comboBox22.Text);

                s[774] = Int32.Parse(TextBox2.Text); // Переключение
                s[775] = Int32.Parse(comboBox23.Text);

                /* ЭКУ */
                s[786] = trackBar7.Value; // 1
                s[787] = Int32.Parse(comboBox3.Text);
                s[790] = trackBar8.Value; // 2
                s[791] = Int32.Parse(comboBox5.Text);
                s[794] = trackBar9.Value; // 3
                s[795] = Int32.Parse(comboBox6.Text);
                s[798] = trackBar10.Value;// 4
                s[799] = Int32.Parse(comboBox7.Text);
                s[802] = trackBar11.Value;// 5
                s[803] = Int32.Parse(comboBox8.Text);
                s[806] = trackBar12.Value;// 6
                s[807] = Int32.Parse(comboBox9.Text);
                s[810] = trackBar13.Value;// 7
                s[811] = Int32.Parse(comboBox10.Text);
                s[814] = trackBar14.Value;// 8
                s[815] = Int32.Parse(comboBox11.Text);
                s[818] = trackBar15.Value;// 9
                s[819] = Int32.Parse(comboBox12.Text);

                /* Турбо */
                s[834] = trackBar16.Value;// 1
                s[835] = Int32.Parse(comboBox13.Text);
                s[838] = trackBar17.Value;// 2
                s[839] = Int32.Parse(comboBox14.Text);
                s[842] = trackBar18.Value;// 3
                s[843] = Int32.Parse(comboBox15.Text);
                s[846] = trackBar19.Value;// 4
                s[847] = Int32.Parse(comboBox16.Text);
                s[850] = trackBar20.Value;// 5
                s[851] = Int32.Parse(comboBox17.Text);
                s[854] = trackBar21.Value;// 6
                s[855] = Int32.Parse(comboBox18.Text);
                s[858] = trackBar22.Value;// 7
                s[859] = Int32.Parse(comboBox19.Text);
                s[862] = trackBar23.Value;// 8
                s[863] = Int32.Parse(comboBox20.Text);
                s[866] = trackBar24.Value;// 9
                s[867] = Int32.Parse(comboBox21.Text);
            #endregion
        }

        private void изФайлаНастроекcarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog2.Title = resourceManager.GetString("carFileOpen");
            openFileDialog2.Filter = resourceManager.GetString("FileDialogFilter");
            openFileDialog2.ShowDialog();
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            if(Path.GetExtension(openFileDialog2.FileName).ToLower() == ".car")
                this.s = p.loadConfig(openFileDialog2.FileName, this.currentCar);
            else
            {
                u2c.load(openFileDialog2.FileName);
                this.s = u2c.convert();
            }
            AddValToForm();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Directory.GetParent(Directory.GetParent(p.filename).FullName).FullName + "\\speed2.exe");
        }

        private void startWindowedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Directory.GetParent(Directory.GetParent(p.filename).FullName).FullName + "\\Launcher.exe");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setResolution();
        }

        private void setResolution()
        {
            try
            {
                this.mf.StopFreezing();
            }
            catch { }
            this.mf = null;
            string[] res = comboBox30.Text.Split('x');
            this.res_w = Int32.Parse(res[0]);
            this.res_h = Int32.Parse(res[1]);
            gameproc = Process.GetProcessesByName("speed2");
            while (gameproc.Length != 1)
            {
                return;
            }
            this.mf = new MemoryFreeze(Process.GetProcessesByName("speed2")[0]);
            this.mf.AddMemoryAddress(0x00870980, res_w);
            this.mf.AddMemoryAddress(0x00870984, res_h);
            this.mf.AddMemoryAddress(0x0086F870, res_w);
            this.mf.AddMemoryAddress(0x0086F874, res_h);
            this.mf.StartFreezing(10);
        }

        private void comboBox30_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!button1.Enabled) button1.Enabled = true;
        }

        private void label38_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
        }

        private void openMainFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openNewFileAndCheckIt();
        }

        private void проверитьОбновленияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://nfsu2.googlecode.com");
        }

        private void comboBox25_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch(comboBox25.SelectedIndex) {
                    case 0:
                        assignArray(Properti.fwd, 960);
                    break;
                    case 1:
                        assignArray(Properti.allwd, 960);
                    break;
                    case 2:
                        assignArray(Properti.rwd, 960);
                    break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int[] createArray(int[] array, int from, int to)
        {
            int[] ret = new int[to - from + 1];
            int i = 0;
            foreach(int r in ret) {
                ret[i] = array[from];
                from++;
                i++;
            }
            return ret;
        }

        private bool assignArray(int[] array, int from)
        {
            try
            {
                foreach (int a in array)
                {
                    this.s[from] = a;
                    from++;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            StreamWriter s = new StreamWriter(textBox4.Text);
            int[] array = createArray(p.main, Int32.Parse(textBox6.Text), Int32.Parse(textBox7.Text));
            s.Write("int[] " + textBox5.Text + " = new int[" + array.Length + "] {\n");
            int c = 0;
            foreach (int z in array)
            {
                s.Write(z);
                c++;
                if (c != array.Length)
                {
                    s.Write(", ");
                }
            }
            s.Write("\n};");
            s.Close();
            MessageBox.Show(textBox4.Text + " with name " + textBox5.Text + " saved!");
        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            groupBox13.Visible = true;
        }
    }
}
