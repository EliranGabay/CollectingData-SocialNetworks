﻿using System;
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
            userName.Text = App.nameProfile;
            string[] listJPG = Directory.GetFiles(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Scrapers\\SearchApi\\imagesP");
            int SumOfLIstJPJ = listJPG.Length;
            for (int i = 0; i < SumOfLIstJPJ; i++)
            {
                if (listJPG[i].Contains(App.nameProfile+".jpg")){
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(listJPG[i]);
                    bitmap.EndInit();
                    profileImage.Source = bitmap;
                    break;
                }
            }

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
