using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ScriptInterface
{
    class Program
    {
        public static void Run()//run exe facbook scraper
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName+@"\Scrapers\Facebook\scraper.exe");
            p.Start();
            p.WaitForExit();
        }
    }
}