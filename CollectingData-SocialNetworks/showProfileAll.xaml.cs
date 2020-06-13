using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CollectingData_SocialNetworks
{
    /// <summary>
    /// Interaction logic for showProfileAll.xaml
    /// </summary>
    public partial class showProfileAll : Window
    {
        public showProfileAll()
        {
            InitializeComponent();
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\Scrapers\FacebookS\input.txt";
            string[] line = System.IO.File.ReadAllLines(path);
            UserName.Text = App.nameProfileF + ", "+App.nameProfileT;

            string[] listJPGT = Directory.GetFiles(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Scrapers\\SearchApi\\imagesTwitter");
            int SumOfLIstJPJT = listJPGT.Length;
            for (int i = 0; i < SumOfLIstJPJT; i++)
            {
                if (listJPGT[i].Contains(App.nameProfileT + ".jpg"))
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(listJPGT[i]);
                    bitmap.EndInit();
                    profileImageT.Source = bitmap;
                    break;
                }

            }

            string[] listJPGF = Directory.GetFiles(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Scrapers\\SearchApi\\imagesP");
            int SumOfLIstJPJF = listJPGF.Length;
            for (int i = 0; i < SumOfLIstJPJF; i++)
            {
                if (listJPGF[i].Contains(App.nameProfileF + ".jpg"))
                {
                    BitmapImage BitmapF = new BitmapImage();
                    BitmapF.BeginInit();
                    BitmapF.UriSource = new Uri(listJPGF[i]);
                    BitmapF.EndInit();
                    profileImageF.Source = BitmapF;
                    break;
                }

            }

            UpdateListTwitter();
            UpdateListFacebook();
        }

        private void UpdateListFacebook()
        {
            TextBlock[] textB = { F_R, DAbout, W_E };
            string[] textF = { "Family and Relationships", "Details About", "Work and Education" };
            for (int i = 0; i < textB.Length; i++)
            {
                string filePath = App.DownloadPath + @"\data\" + App.nameProfileF + @"\" + textF[i] + ".txt";
                string[] lines = System.IO.File.ReadAllLines(filePath);
                string info = "";
                for (int j = 0; j < lines.Length; j++)
                {
                    info += lines[j] + "\n";

                }
                textB[i].Text = info;
            }
            string filePathC_B = App.DownloadPath + @"\data\" + App.nameProfileF + @"\Contact and Basic Info.txt";
            string[] linesC_B = System.IO.File.ReadAllLines(filePathC_B);
            for (int j = 0; j < linesC_B.Length; j++)
            {
                BasicInfo.Text += linesC_B[j] + "\n";
            }
            string filePathP_L = App.DownloadPath + @"\data\" + App.nameProfileF + @"\Places Lived.txt";
            string[] linesP_L = System.IO.File.ReadAllLines(filePathP_L);
            if (Places.Text[1].ToString() == "\n") Places.Text = "";
            for (int j = 0; j < linesP_L.Length; j++)
            {
                Places.Text += linesP_L[j] + "\n";
            }
        }

        private void UpdateListTwitter()
        {
            string filePath = App.DownloadPath + @"\data\" + App.nameProfileT + @"\" + App.nameProfileT + @".txt";
            string[] lines = System.IO.File.ReadAllLines(filePath);
            int SumOfLins = lines.Length;
            int flagType = 0;
            //init textbox
            BasicInfo.Text = "";
            Places.Text = "";
            BIOGRAPHY.Text = "";
            BIOGRAPHY.Text = "";
            //fill textbox
            for (int x = 2; x < SumOfLins; x++)
            {
               if(x >= 2 && x < 6)//name and birthday
                {
                    BasicInfo.Text += lines[x] + "\n";
                }
               if(x >= 6 && x < 8)//location
                {
                    Places.Text += lines[x] + "\n";
                }
               if(x == 9 || flagType == 1)//biography
                {
                    flagType = 1;
                    if (lines[x] != "Tweets Amount:")
                        BIOGRAPHY.Text += lines[x] + "\n";
                    else
                        flagType = 2;
                }
               if(flagType == 2)//Amount TWEETS, FOLLOWER, FOLLOWING
                {
                    ACCOUNT.Text += lines[x] + "\n";
                }
            }
            if (BIOGRAPHY.Text.Length == 1)
                BIOGRAPHY.Text = "None";
            if (ACCOUNT.Text.Length == 1)
                ACCOUNT.Text = "None";
        }

    }
}
