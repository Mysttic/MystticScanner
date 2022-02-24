using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsConsole
{
    public static class Tools
    {
        private static string CmdInteractive(string arguments)
        {
            Process process = new Process();
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = @"/C vt.exe "+arguments; //DIR C:\";
            //process.StartInfo.Arguments = @"/C vt.exe scan file " + "\"" + file + "\""; //DIR C:\";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.Start();
            string q = "";
            while (!process.HasExited)
            {
                q += process.StandardOutput.ReadToEnd();
            }
            return q;
        }
        public static class VTInteractive
        {
            public static string GetAnalysis(string key) => CmdInteractive(" analysis " + key);
            public static string ScanFile(string arguments) => CmdInteractive("scan file " + "\"" + arguments + "\"");

            public static string ScanURL(string arguments) => CmdInteractive("url " + arguments);
        }
    }
}
