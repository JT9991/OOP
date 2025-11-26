using System;
using System.Windows.Forms;

namespace toDoList
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());   // <<< VERY IMPORTANT
        }
    }
}
