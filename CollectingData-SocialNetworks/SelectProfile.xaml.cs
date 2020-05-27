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
    /// Interaction logic for SelectProfile.xaml
    /// </summary>
    public partial class SelectProfile : Window
    {
        private List<Picture> ImageList = new List<Picture>();

        public SelectProfile()
        {
            InitializeComponent();
            int SumOfResult = 0;
            string[] lineName = Directory.GetFiles(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Scrapers\\SearchApi\\pages").Select(System.IO.Path.GetFileName).ToArray();

            if (Directory.Exists(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Scrapers\\SearchApi\\imagesP")) { 
                string[] lineJPG = Directory.GetFiles(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Scrapers\\SearchApi\\imagesP");
            SumOfResult = lineJPG.Length;

            for (int i = 0; i < SumOfResult; i++)
            {
                ImageList.Add(new Picture() { Name = lineName[i], Image = lineJPG[i] });
            }
            ListViewImag.ItemsSource = ImageList;
        }
        }


    }
}
