using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace krekvirus
{
    public partial class Form1 : Form
    {
        public string dataPath = ".krekStartData";
        private int clickNum = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if (File.Exists(dataPath))
            {

                string data = File.ReadAllText(dataPath);
                DateTime time = DateTime.Parse(data, System.Globalization.CultureInfo.InvariantCulture);
                DateTime timeLimit = time.AddDays(4);
                DateTime timeNow = DateTime.Now;

                TimeSpan diffTime = timeLimit.Subtract(timeNow);
                double progress = 100 - (diffTime.TotalSeconds / 3456);
                if (progress < 100)
                {
                    timeLabel.Text = timeSpanToString.toString(diffTime) + " left";
                    progressBar1.Value = (int) progress;

                    switch (diffTime.Days)
                    {
                        case 2:
                            krekPic.Image = krekvirus.Properties.Resources.krekstage2;
                            break;
                        case 1:
                            krekPic.Image = krekvirus.Properties.Resources.krekstage3;
                            break;
                        case 0:
                            krekPic.Image = krekvirus.Properties.Resources.krekstage4;
                            this.Text = "Krek...";
                            timeLabel.ForeColor = Color.FromArgb(175, 0, 0);
                            break;
                        default:
                            krekPic.Image = krekvirus.Properties.Resources.krek;
                            break;
                    }
                } else
                {
                    krekPic.Image = krekvirus.Properties.Resources.krekstage4;
                    this.Text = "Krek...";
                    timeLabel.ForeColor = Color.FromArgb(175, 0, 0);
                    timeLabel.Text = "Times up...";
                    progressBar1.Value = 100;
                }

                

                

            } else
            {

                DateTime time = DateTime.Now;
                File.WriteAllText(dataPath, time.ToString(System.Globalization.CultureInfo.InvariantCulture));
                File.SetAttributes(dataPath, File.GetAttributes(dataPath) | FileAttributes.Hidden);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string data = File.ReadAllText(dataPath);
            DateTime time = DateTime.Parse(data, System.Globalization.CultureInfo.InvariantCulture);

            if (passBox.Text == "I am a noob")
            {
                MessageBox.Show("You guessed the password!");
                time = DateTime.Now;
                File.WriteAllText(dataPath, time.ToString(System.Globalization.CultureInfo.InvariantCulture));
            } else
            {
                MessageBox.Show("no");
                time.AddHours(-2);
                File.WriteAllText(dataPath, time.ToString(System.Globalization.CultureInfo.InvariantCulture));
                Console.WriteLine("nob haha lol");
            }
            passBox.Text = "";

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
            if (clickNum == 3)
            {
                clickNum = 0;
                Form2 form2 = new Form2(this);
                form2.Show();
            } else
            {
                clickNum += 1;
            }

        }

        public void setKrekPic(string krekPicPath)
        {
            krekPic.Image = Image.FromFile(krekPicPath);
        }
    }
}
