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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CollectingData_SocialNetworks
{
    /// <summary>
    /// Interaction logic for SearchAll.xaml
    /// </summary>
    public partial class SearchAll : Page
    {
        public SearchAll()
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
            if (all.IsChecked == true)
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
        private bool checkCharacters()
        {
            int len = search_bar.Text.Length;
            int countSpace = 0;
            for (int i = 0; i < len; i++)
            {

                if (search_bar.Text[i] == ' ')
                    countSpace += 1;
                if ((Char.IsLetter(search_bar.Text[i]) == false) && (search_bar.Text[i] != ' '))
                    return false;
            }
            if (countSpace >= 1)
                return true;
            return false;

        }


        private void SearchA(object sender, RoutedEventArgs e)//run exe facbook scraper from ScriptInterface class
        {
            string name = search_bar.Text;
            if (!name.Equals(""))
            {
                if (checkCharacters())
                {
                    ScriptInterface.Program.RunPy(@"\Scrapers\SearchApi\Runing.py", name);
                    ScriptInterface.Program.RunPy(@"\Scrapers\SearchApi\RuningTwitter.py", name);
                    if (Directory.Exists(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Scrapers\\SearchApi\\imagesP")|| (Directory.Exists(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Scrapers\\SearchApi\\imagesTwitter")))
                    {
                        var selectP = new SelectProfileAll();//Kליצור דף חדש ולשים את זה במקום
                        selectP.ShowDialog();
                        //run scraper
                        
                        
                      //  string arg = "";
                      //  string path = " -dl " + App.DownloadPath;

                      //  if (pictuers.IsChecked == true) arg += " -dup True";
                      //  if (posts.IsChecked == true) arg += " -pt True";
                       // if (friends.IsChecked == true && pictuers.IsChecked == true) arg += " -dfp True";
                      //  else if (friends.IsChecked == true) arg += " -fs True";
                        //arg += path;

                        //ScriptInterface.Program.RunPy(@"\Scrapers\FacebookS\scraper.py", arg);
                        //System.Windows.Forms.MessageBox.Show("Search Successfully Completed", "Search",
                        //MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //var userProfilw = new showProfileF();
                        //userProfilw.ShowDialog();

                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("No profiles found!", "Error Search",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }

                }
                else
                {

                    System.Windows.Forms.MessageBox.Show("You need to enter a full name andcontains only letters!!", "Error Search",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

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
