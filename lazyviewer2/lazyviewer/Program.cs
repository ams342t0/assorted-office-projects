using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace lazyviewer
{
    static class Program
    {
        public static int v=0;
        public static string f="";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String [] args)
        {
            if (args.Length > 0)
            {
                f = args[0];
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
