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
    /// Interaction logic for SelectProfileAll.xaml
    /// </summary>
    public partial class SelectProfileAll : Window
    {
        private List<Picture> ImageListF = new List<Picture>();
        private List<Picture> ImageListT = new List<Picture>();


        public SelectProfileAll()
        {
            InitializeComponent();
            string[] lineNameF = Directory.GetFiles(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Scrapers\\SearchApi\\pages").Select(System.IO.Path.GetFileName).ToArray();

            if (Directory.Exists(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Scrapers\\SearchApi\\imagesP"))
            {
                string[] lineJPG = Directory.GetFiles(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Scrapers\\SearchApi\\imagesP");
                int SumOfResultF = lineJPG.Length;

                for (int i = 0; i < SumOfResultF; i++)
                {
                    ImageListF.Add(new Picture() { Name = lineNameF[i], Image = lineJPG[i] });
                }
                ListViewFacebook.ItemsSource = ImageListF;
            }
            int SumOfResult = 0;
            string[] lineNameT = Directory.GetFiles(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Scrapers\\SearchApi\\imagesTwitter").Select(System.IO.Path.GetFileName).ToArray();

            if (Directory.Exists(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Scrapers\\SearchApi\\imagesTwitter"))
            {
                string[] lineJPG = Directory.GetFiles(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Scrapers\\SearchApi\\imagesTwitter");
                SumOfResult = lineJPG.Length;

                for (int i = 0; i < SumOfResult; i++)
                {
                    ImageListT.Add(new Picture() { Name = lineNameT[i], Image = lineJPG[i] });
                }
                ListViewTwitter.ItemsSource = ImageListT;
            }


        }
    }
}
