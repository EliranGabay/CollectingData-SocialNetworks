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
    /// Interaction logic for showProfileF.xaml
    /// </summary>
    public partial class showProfileF : Window
    {

        public showProfileF()
        {
            InitializeComponent();
            userName.Text = App.nameProfileF;
            string[] listJPG = Directory.GetFiles(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Scrapers\\SearchApi\\imagesP");

            int SumOfLIstJPJ = listJPG.Length;
            for (int i = 0; i < SumOfLIstJPJ; i++)
            {
                if (listJPG[i].Contains(App.nameProfileF+".jpg")){
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(listJPG[i]);
                    bitmap.EndInit();
                    profileImage.Source = bitmap;
                    break;
                }

            }
            UpdateList();

        }
        private void UpdateList()
        {
            TextBlock[] textB = { BasicInfo, Places, F_R, DAbout, W_E };
            string[] textF = { "Contact and Basic Info", "Places Lived", "Family and Relationships", "Details About", "Work and Education" };
            for (int i = 0; i < textB.Length; i++)
            {
                string filePath = App.DownloadPath + @"\data\" + App.nameProfileF + @"\" + textF[i] + ".txt"; 
                string[] lines = System.IO.File.ReadAllLines(filePath);
                string info = "";
                for (int j = 0; j < lines.Length; j++)
                {
                    info += lines[j]+"\n";

                }
                textB[i].Text = info;

            }
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
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
