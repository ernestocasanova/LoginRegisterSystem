using System;
using System.Windows.Forms;

namespace LoginRegisterSystem
{
    internal static class Program
    {
        /// <summary>
        /// Main entry for the appllication
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
