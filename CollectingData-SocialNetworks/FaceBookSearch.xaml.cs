using ScriptInterface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CollectingData_SocialNetworks
{
    /// <summary>
    /// Interaction logic for FaceBookSearch.xaml
    /// </summary>
    public partial class FaceBookSearch : Page
    {

        public FaceBookSearch()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            SelectAll(true);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            SelectAll(false);
        }

        private void CheckBox_checkNotAll(object sender, RoutedEventArgs e)
        {
            if(all.IsChecked==true)
                all.IsChecked = false;
        }

        private void SelectAll(bool select)
        {
            if (select)
            {
                pictuers.IsChecked = true;
                posts.IsChecked = true;
                friends.IsChecked = true;
            }
            else
            {
                pictuers.IsChecked = false;
                posts.IsChecked = false;
                friends.IsChecked = false;
            }
        }

        private void SearchF(object sender, RoutedEventArgs e)//run exe facbook scraper from ScriptInterface class
        {
            string name = search_bar.Text;
            if (!name.Equals("") & CheckO())
            {
                ScriptInterface.Program.RunPy(@"\Scrapers\SearchApi\Runing.py",name);
                var selectP = new SelectProfile();
                selectP.Show();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No Name entered or No Option selected", "Error Search",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool CheckO()
        {
            int flag = 0;
            if (pictuers.IsChecked == true) flag = 1;
            if (posts.IsChecked == true) flag = 1;
            if (friends.IsChecked == true) flag = 1;
            if (all.IsChecked == true) flag = 1;
            if (flag != 0) return true;
            else return false;
        }
    }
}
