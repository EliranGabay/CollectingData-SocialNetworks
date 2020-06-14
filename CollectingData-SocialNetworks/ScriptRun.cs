using CollectingData_SocialNetworks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScriptInterface
{
    class Program
    {
        public static void RunPy(string pathPy,string name)// run file py with argv
        {
            ProcessStartInfo pythonInfo = new ProcessStartInfo();
            Process python;
            pythonInfo.FileName = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + pathPy;
            pythonInfo.Arguments = name;
            pythonInfo.CreateNoWindow = false;
            pythonInfo.UseShellExecute = true;

            python = Process.Start(pythonInfo);
            python.WaitForExit();
            python.Close();
        }

        public static void RunPy(string pathPy)// run file py 
        {
            ProcessStartInfo pythonInfo = new ProcessStartInfo();
            Process python;
            pythonInfo.FileName = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + pathPy;
            pythonInfo.CreateNoWindow = false;
            pythonInfo.UseShellExecute = true;

            python = Process.Start(pythonInfo);
            python.WaitForExit();
            python.Close();
        }

        public static void RunShell(string pathSell,string nameSell, string name)// run file shell with argv
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.WorkingDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + pathSell;
            startInfo.FileName = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + nameSell;
            startInfo.Arguments = name;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            process.Close();
        }
    }
}