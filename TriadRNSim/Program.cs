using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using TriadRNSim.Forms;

namespace TriadRNSim
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(frmMain.Instance);
            //Application.Run(new frmEditParam(10));
        }
    }
}
