using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Testing
{
    public class ShowTime : IInvoker
    {
        public void Invoke()
        {
            ShowCurrentTime();
        }

        public static void ShowCurrentTime()
        {
            Console.WriteLine(DateTime.Now.ToString("hh:mm:ss"));
        }
    }
}
