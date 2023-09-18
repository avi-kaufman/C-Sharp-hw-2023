using System.Windows.Forms;

namespace Ex05
{
    public class Program
    {
        public static void Main()
        {
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormSettings());
            }
        }
    }
}
