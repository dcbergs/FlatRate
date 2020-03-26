using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlatRate
{
    static class Program
    {
        public static float STANDARD_RATE;
        public static float PREMIUM_RATE;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            STANDARD_RATE = 160.0f;
            PREMIUM_RATE = 180.0f;
            Application.Run(new Form1());
        }
    }
}
