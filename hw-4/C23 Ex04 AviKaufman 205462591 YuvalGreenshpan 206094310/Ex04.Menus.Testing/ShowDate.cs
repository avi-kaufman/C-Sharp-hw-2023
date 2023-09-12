using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus
{
    public class ShowDate : IInvoker
    {
        public void Invoke()
        {
            ShowCurrentDate();
        }

        public static void ShowCurrentDate()
        {
            Console.WriteLine("The date is now: {0}", DateTime.Now.ToString("dddd, MMM dd yyyy", System.Globalization.CultureInfo.InvariantCulture));

        }
    }
}
