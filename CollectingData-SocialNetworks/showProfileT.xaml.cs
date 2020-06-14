using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
    /// Interaction logic for showProfileT.xaml
    /// </summary>
    public partial class showProfileT : Window
    {
        public showProfileT()
        {
            InitializeComponent();
            userName.Text = App.nameProfileT;
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
            UpdateListT();
        }
        private void UpdateListT() 
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
                if (x >= 2 && x < 6)//name and birthday
                {
                    BasicInfo.Text += lines[x] + "\n";
                }
                if (x >= 6 && x < 8)//location
                {
                    Places.Text += lines[x] + "\n";
                }
                if (x == 9 || flagType == 1)//biography
                {
                    flagType = 1;
                    if (lines[x] != "Tweets Amount:")
                        BIOGRAPHY.Text += lines[x] + "\n";
                    else
                        flagType = 2;
                }
                if (flagType == 2)//Amount TWEETS, FOLLOWER, FOLLOWING
                {
                    ACCOUNT.Text += lines[x] + "\n";
                }
            }
            if (BIOGRAPHY.Text.Length == 1)
                BIOGRAPHY.Text = "None";
            if (ACCOUNT.Text.Length == 1)
                ACCOUNT.Text = "None";

        }
        private void Open_Folder(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = App.DownloadPath + @"\data\" + App.nameProfileT,
                UseShellExecute = true,
                Verb = "open"
            });
        }


    }
}
