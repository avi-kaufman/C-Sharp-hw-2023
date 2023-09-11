namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        protected MenuItem m_MainMenu;

        public MainMenu(MenuItem i_MainMenu)
        {
            m_MainMenu = i_MainMenu;
        }

        public void Show()
        {
            this.m_MainMenu.OpenMenu();
        }
    }
}
