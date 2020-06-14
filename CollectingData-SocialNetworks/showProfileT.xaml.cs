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
            string filePath = App.DownloadPath + @"\data\" + App.nameProfileT+ @"\"+ App.nameProfileT + @".txt";
            string[] lines = System.IO.File.ReadAllLines(filePath);
            int SumOfLins = lines.Length;
            string Basic = "";
            for (int j = 2; j < 6; j++)
            {
                Basic += lines[j] + "\n";

            }
            if (Basic.Length == 1)
                Basic = "No results";

            BasicInfo.Text = Basic;
            string place = "";
            for (int j =7; j < 8; j++)
            {
                place += lines[j] + "\n";

            }
            if (place.Length==1)
            {
                place = "No results";
            }
            Places.Text = place;
            int i = 9;
            string bio = "";
            while(lines[i]!= "TWEETSC:")
            {
               bio += lines[i] + "\n";
               i++;

            }
            if (bio.Length == 1)
            {
                bio = "No results";
            }
            BIOGRAPHY.Text= bio;
            string Accou = "";

            while ( i < SumOfLins)
            {

                Accou+=lines[i] + "\n";
                i++;
            }
            string after = Accou.Replace("TWEETSC:", "Tweets Account");
            string After = after.Replace("FOLLOWERSC:", "Followers Account");
            string AFter = After.Replace("FOLLOWINGC:", "Following Account");
            string AFTer = AFter.Replace("FOLLOWINGC:", "Following Account");

            ACCOUNT.Text = AFTer;

        }
        private void Open_Folder(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = App.DownloadPath,
                UseShellExecute = true,
                Verb = "open"
            });
        }


    }
}
