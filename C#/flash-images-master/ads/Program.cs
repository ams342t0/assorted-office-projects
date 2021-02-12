using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ads
{
    static class Program
    {
        public static Form1 xform;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            xform = new Form1();
            Application.Run(xform);
        }
    }
}
