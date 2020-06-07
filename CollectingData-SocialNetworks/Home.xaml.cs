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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        setting S = new setting();
        Help H = new Help();

        public Home()
        {
            InitializeComponent();
            
        }
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void FaceS_Click(object sender, RoutedEventArgs e)
        {
            FaceBookSearch F = new FaceBookSearch();
            WinMain.Content = null;
            WinMain.Content=F;
        }
        private void TwitterS_Click(object sender, RoutedEventArgs e)
        {
            TwitterSearch T = new TwitterSearch();
            WinMain.Content = null;
            WinMain.Content = T;
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            WinMain.Content = null;
        }
        private void Help_Click(object sender, RoutedEventArgs e)
        {
            
            WinMain.Content = null;
            WinMain.Content = H;
        }
        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            WinMain.Content = null;
            WinMain.Content = S;
        }

        private void SearchAll_Click(object sender, RoutedEventArgs e)
        {
            App.nameProfile = "100000494830078";
            var userProfilw = new showProfileF();
            userProfilw.ShowDialog();
        }




    }
}
