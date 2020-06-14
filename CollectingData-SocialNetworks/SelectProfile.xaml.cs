using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace CollectingData_SocialNetworks
{
    /// <summary>
    /// Interaction logic for SelectProfile.xaml
    /// </summary>
    public partial class SelectProfile : Window
    {
        private List<Picture> ImageList = new List<Picture>();
        private int flag;//flag for select search
        public SelectProfile(String DirName)
        {
            InitializeComponent();
            int SumOfResult = 0;
            string[] lineName = Directory.GetFiles(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Scrapers\\SearchApi\\"+DirName).Select(System.IO.Path.GetFileName).ToArray();

            if (Directory.Exists(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Scrapers\\SearchApi\\"+DirName))
            {
                string[] lineJPG = Directory.GetFiles(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Scrapers\\SearchApi\\" + DirName);
                SumOfResult = lineJPG.Length;

                for (int i = 0; i < SumOfResult; i++)
                {
                    ImageList.Add(new Picture() { Name = lineName[i], Image = lineJPG[i] });
                }
                ListViewImag.ItemsSource = ImageList;
            }
            flag = 1;

        }
        public SelectProfile()
        {
            InitializeComponent();
            int SumOfResult = 0;
            string[] lineName = Directory.GetFiles(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Scrapers\\SearchApi\\pages").Select(System.IO.Path.GetFileName).ToArray();

            if (Directory.Exists(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Scrapers\\SearchApi\\imagesP"))
            {
                string[] lineJPG = Directory.GetFiles(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Scrapers\\SearchApi\\imagesP");
                SumOfResult = lineJPG.Length;

                for (int i = 0; i < SumOfResult; i++)
                {
                    ImageList.Add(new Picture() { Name = lineName[i], Image = lineJPG[i] });
                }
                ListViewImag.ItemsSource = ImageList;
            }
            flag = 0;
        }

        private void ButtonProfile_Click(object sender, RoutedEventArgs e)
        {
            string name= Regex.Split(((System.Windows.Controls.ContentControl)sender).Content.ToString(),".jpg")[0];
            if (name.Contains("@.txt")) { name = name.Split('@')[0]; }
            else if (name.Contains("$.txt")) { name = name.Split('$')[0]; }
            else { name = Regex.Split(name, ".txt")[0]; }
            if (flag == 0) {//Facebook
                string path = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\Scrapers\FacebookS\input.txt";
                System.IO.File.WriteAllText(path, @"https://www.facebook.com/" + name);
                App.nameProfileF = name;
                App.flagRun = true;
            }
            else {//Twitter
                App.nameProfileT = name;
                App.flagRun = true;
            }
            this.Hide();
        }
        private void StopSearch(object sender, RoutedEventArgs e)
        {
            App.flagRun = false;
            this.Hide();
        }
    }
}
