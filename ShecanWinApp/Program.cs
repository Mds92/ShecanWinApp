using System;
using System.Windows.Forms;

namespace ShecanWinApp
{
    internal static class Program
    {
        /// <summary>
        /// Written By Mohammad Dayyan
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
