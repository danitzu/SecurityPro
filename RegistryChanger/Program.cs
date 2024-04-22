using System;
using System.Windows.Forms;

namespace Tools
{
    static class Form1
    {
        [STAThread]
        static void Program()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form());
        }
    }
}
