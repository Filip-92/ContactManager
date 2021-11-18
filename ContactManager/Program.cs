using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;
using System.Windows.Forms;

namespace ContactManager
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            //Application.SetHighDpiMode(HighDpiMode.SystemAware); - disabling scaling 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // display the main form if the login from dialog result = OK
            Login_Register_Form fLogin = new Login_Register_Form();
            if(fLogin.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MainForm());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
