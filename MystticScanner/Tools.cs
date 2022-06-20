using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MystticScanner
{
    public static class Tools
    {
        private static string CmdInteractive(string arguments)
        {
            Process process = new Process();
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = @"/C vt.exe " + arguments; //DIR C:\";
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
                Console.WriteLine(q);
            }
            return q;
        }
        public static class VTInteractive
        {
            public static string GetAnalysis(string key) => CmdInteractive(" analysis " + key);
            public static string ScanFile(string arguments) => CmdInteractive("scan file " + "\"" + arguments + "\"");
            public static string ScanURL(string arguments) => CmdInteractive("url " + arguments);
        }
        public static class Colors
        {
            public static void ColorAllRichTextBoxFragment(ref RichTextBox richTextBox)
            {
                foreach (string key in ResultsColors.Keys)
                    ColorRichTextBoxFragment(ref richTextBox,key);
            }
            public static void ColorRichTextBoxFragment(ref RichTextBox richTextBox, string fragment)
            {
                int index = 0;
                int i = 0;
                do
                {
                    int lastindex = index;
                    index = richTextBox.Text.IndexOf(fragment, index + 1);
                    if (index == -1)
                        break;
                    if (index != lastindex)
                    {
                        richTextBox.Select(index, fragment.Length);
                        richTextBox.SelectionColor = ResultsColors[fragment];
                    }
                    else
                        break;
                    i++;

                } while (index < richTextBox.Text.Length || i > 500);

            }

            private readonly static Dictionary<string, Color> ResultsColors = new Dictionary<string, Color>
            {
                { "confirmed-timeout",Color.Blue },
                { "timeout", Color.Blue },
                { "failure", Color.Orange },
                { "type-unsupported", Color.Orange },
                { "harmless", Color.Red },
                { "malicious", Color.Red },
                { "suspicious", Color.Red },
                { "undetected", Color.Green }
            };
        }

    }
}
