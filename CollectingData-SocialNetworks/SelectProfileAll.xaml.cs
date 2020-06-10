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
    /// Interaction logic for SelectProfileAll.xaml
    /// </summary>
    public partial class SelectProfileAll : Window
    {
        private List<Picture> ImageListF = new List<Picture>();
        private List<Picture> ImageListT = new List<Picture>();
        private bool flagF = false;
        private bool flagT = false;
        private bool resultF = false;
        private bool resultT = false;


        public SelectProfileAll()
        {
            InitializeComponent();
            string[] lineNameF = Directory.GetFiles(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Scrapers\\SearchApi\\pages").Select(System.IO.Path.GetFileName).ToArray();

            if (Directory.Exists(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Scrapers\\SearchApi\\imagesP"))
            {
                resultF = true;
                string[] lineJPG = Directory.GetFiles(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Scrapers\\SearchApi\\imagesP");
                int SumOfResultF = lineJPG.Length;

                for (int i = 0; i < SumOfResultF; i++)
                {
                    ImageListF.Add(new Picture() { Name = lineNameF[i], Image = lineJPG[i] });
                }
                ListViewFacebook.ItemsSource = ImageListF;
            }

            int SumOfResult = 0;

            if (Directory.Exists(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Scrapers\\SearchApi\\imagesTwitter"))
            {
                resultT = true;
                string[] lineNameT = Directory.GetFiles(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Scrapers\\SearchApi\\imagesTwitter").Select(System.IO.Path.GetFileName).ToArray();
                string[] lineJPG = Directory.GetFiles(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Scrapers\\SearchApi\\imagesTwitter");
                SumOfResult = lineJPG.Length;

                for (int i = 0; i < SumOfResult; i++)
                {
                    ImageListT.Add(new Picture() { Name = lineNameT[i], Image = lineJPG[i] });
                }
                ListViewTwitter.ItemsSource = ImageListT;
            }
            if (!resultT) flagT = true;
            if (!resultF) flagF = true;
        }
        private void ButtonProfileF_Click(object sender, RoutedEventArgs e)
        {
            string name = Regex.Split(((System.Windows.Controls.ContentControl)sender).Content.ToString(), ".jpg")[0];
            if (name.Contains("@.txt")) { name = name.Split('@')[0]; }
            else if (name.Contains("$.txt")) { name = name.Split('$')[0]; }
            else { name = Regex.Split(name, ".txt")[0]; }
            //Facebook
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\Scrapers\FacebookS\input.txt";
            System.IO.File.WriteAllText(path, @"https://www.facebook.com/" + name);
            flagF=true;
            if(flagF&&flagT) this.Hide();
        }
        private void ButtonProfileT_Click(object sender, RoutedEventArgs e)
        {
            string name = Regex.Split(((System.Windows.Controls.ContentControl)sender).Content.ToString(), ".jpg")[0];
            if (name.Contains("@.txt")) { name = name.Split('@')[0]; }
            else if (name.Contains("$.txt")) { name = name.Split('$')[0]; }
            else { name = Regex.Split(name, ".txt")[0]; }
            //Twitter
            App.nameProfile = name;
            flagT = true;
            if (flagF && flagT) this.Hide();
        }
    }
}
