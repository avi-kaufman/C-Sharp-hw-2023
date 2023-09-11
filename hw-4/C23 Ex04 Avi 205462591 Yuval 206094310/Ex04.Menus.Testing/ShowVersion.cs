using System;
using Ex04.Menus.Interfaces;


namespace Ex04.Menus.Testing
{
    public class ShowVersion : IInvoker
    {
        public void Invoke()
        {
            ShowCurrentVersion();
        }

        public static void ShowCurrentVersion()
        {
            Console.WriteLine("Version: 23.3.4.9835 ");
        }
    }
}
