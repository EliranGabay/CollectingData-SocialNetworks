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
    }
}