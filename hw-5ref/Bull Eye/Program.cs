using System.Windows.Forms;
using Bull_Eye.WindowUI;

namespace Bull_Eye
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
