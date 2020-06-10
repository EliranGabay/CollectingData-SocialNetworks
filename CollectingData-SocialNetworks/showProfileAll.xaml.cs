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
            string UserNameFace = Regex.Split(Regex.Split(line[0], @"https://www.facebook.com/")[1], ".txt")[0];
            UserName.Text = UserNameFace + ", "+App.nameProfile;
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
            string[] listJPGF = Directory.GetFiles(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Scrapers\\SearchApi\\imagesP");

            int SumOfLIstJPJF = listJPGF.Length;
            for (int i = 0; i < SumOfLIstJPJF; i++)
            {
                if (listJPGF[i].Contains(UserNameFace + ".jpg"))
                {
                    BitmapImage BitmapF = new BitmapImage();
                    BitmapF.BeginInit();
                    BitmapF.UriSource = new Uri(listJPGF[i]);
                    BitmapF.EndInit();
                    profileImageF.Source = BitmapF;
                    break;
                }

            }
        }
    }
}
