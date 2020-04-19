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
        public static void RunPy()
        {
            ProcessStartInfo pythonInfo = new ProcessStartInfo();
            Process python;
            pythonInfo.FileName = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\Scrapers\FacebookS\scraper.py";
            //pythonInfo.Arguments = string.Format("{0} {1}", cmd, args);//
            pythonInfo.CreateNoWindow = false;
            pythonInfo.UseShellExecute = true;

            python = Process.Start(pythonInfo);
            python.WaitForExit();
            python.Close();
        }
    }
}