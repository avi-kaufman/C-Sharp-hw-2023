using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private string m_Title;
        private readonly List<MenuItem> m_ListOfMenuItems;
        private IInvoker m_Invoke;
        private MenuItem m_ParentMenu;

        public MenuItem(string i_Title, IInvoker i_Invoke)
        {
            this.m_Title = i_Title;
            this.m_ListOfMenuItems = new List<MenuItem>();
            this.m_Invoke = i_Invoke;
            this.m_ParentMenu = null;
        }

        public void ShowMenu()
        {
            int counterOfRaws = 1;
            StringBuilder menu = new StringBuilder();
            string alotOfEquals = new string('=', this.m_Title.Length);

            menu.AppendLine(this.m_Title);
            menu.AppendLine(alotOfEquals);

            foreach (MenuItem menuItem in m_ListOfMenuItems)
            {
                menu.AppendLine(String.Format("{0}. {1}", counterOfRaws++, menuItem.m_Title));
            }

            string backOrExit = "Back";

            if (isFirstMenuItem())
            {
                backOrExit = "Exit";
            }

            menu.AppendLine(string.Format("{0}. {1}", 0, backOrExit));
            string range = string.Format("(1-{0} or 0 to {1})", this.m_ListOfMenuItems.Count, backOrExit);
            menu.AppendLine(string.Format("Please enter your choice {0}", range));
            menu.AppendLine(alotOfEquals);
            Console.WriteLine(menu);
        }

        public void AddItemToMenu(MenuItem i_MenuItem)
        {
            i_MenuItem.Parent = this;
            m_ListOfMenuItems.Add(i_MenuItem);
        }

        public void ItemSelect(int i_NumberSelected)
        {
            if (i_NumberSelected > this.m_ListOfMenuItems.Count || i_NumberSelected < 0)
            {
                i_NumberSelected = checksForValidInput(0, m_ListOfMenuItems.Count);
            }

            m_ListOfMenuItems[i_NumberSelected - 1].itemActivator();
        }

        internal void itemActivator()
        {
            if (m_Invoke != null)
            {
                m_Invoke.Invoke();
            }
            else
            {
                OpenMenu();
            }
        }

        public void OpenMenu()
        {
            while (true)
            {
                ShowMenu();
                int numberSelected = checksForValidInput(0, this.m_ListOfMenuItems.Count);

                if (numberSelected == 0)
                {
                    break;
                }

                ItemSelect(numberSelected);
            }
        }

        private bool isFirstMenuItem()
        {
            return this.m_ParentMenu == null;
        }

        public MenuItem Parent
        {
            get { return this.m_ParentMenu; }
            set { this.m_ParentMenu = value; }
        }

        private int checksForValidInput(int i_Min, int i_Max)
        {
            string numberSelected = string.Empty;

            while (true)
            {
                numberSelected = Console.ReadLine();
                try
                {
                    if (int.Parse(numberSelected) > i_Max || int.Parse(numberSelected) < i_Min)
                    {
                        throw new ValueOutOfRangeException(i_Min, i_Max);
                    }

                    return int.Parse(numberSelected);
                }
                catch (ValueOutOfRangeException)
                {
                    Console.WriteLine("The input value was out of range");
                    this.ShowMenu();
                    continue;
                }
                catch (FormatException)
                {
                    Console.WriteLine("ONLY NUMBERS");
                    this.ShowMenu();
                    continue;
                }
            }
        }
    }
}
