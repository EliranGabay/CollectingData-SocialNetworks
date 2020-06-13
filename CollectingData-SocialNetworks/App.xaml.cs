using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace CollectingData_SocialNetworks
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string DownloadPath { get; set; }
        public static string nameProfileF { get; set; }
        public static string nameProfileT { get; set; }
    }
}
