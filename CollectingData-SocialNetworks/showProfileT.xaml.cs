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
            userName.Text = App.nameProfile;
            string[] listJPGT = Directory.GetFiles(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Scrapers\\SearchApi\\imagesTwitter");
            int SumOfLIstJPJT = listJPGT.Length;
            for (int i = 0; i < SumOfLIstJPJT; i++)
            {
                if (listJPGT[i].Contains(App.nameProfile + ".jpg"))
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
        private void UpdateListT() {
            string filePath = App.DownloadPath + @"\data\" + App.nameProfile+ @"\"+ App.nameProfile + @".txt";
            string[] lines = System.IO.File.ReadAllLines(filePath);
            int SumOfLins = lines.Length;
            string Basic = "";
            for (int j = 2; j < 6; j++)
            {
                Basic += lines[j] + "\n";

            }
            BasicInfo.Text = Basic;
            string place = "";
            for (int j =7; j < 8; j++)
            {
                place += lines[j] + "\n";

            }
            Places.Text = place;
            int i = 9;
            string bio = "";
            while(lines[i]!= "TWEETSC:")
            {
               bio += lines[i] + "\n";
               i++;

            }
            BIOGRAPHY.Text= bio;
            string Accou = "";

            while ( i < SumOfLins)
            {
                Accou+=lines[i] + "\n";
                i++;
            }
            ACCOUNT.Text = Accou;

        }



    }
}
