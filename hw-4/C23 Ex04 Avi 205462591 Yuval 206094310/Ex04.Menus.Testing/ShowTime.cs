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
            Console.WriteLine("The Hour is now: {0}", DateTime.Now.ToString("hh:mm:ss"));
        }
    }
}
