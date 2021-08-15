using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hera
{
    public class HeraMenu
    {
        internal List<MenuEntry> MenuEntries = new List<MenuEntry>();

        internal int currentCursorIndex = 0;
        internal string menuHeader = string.Empty;

        public HeraMenu(string header)
        {
            menuHeader = header;
        }

        public void AddHeraMenu(string Name)
        {
            MenuEntries.Add(new MenuEntry() { MenuName = Name });
        }

        public string GetMenuAsStringWithSeperatedLines()
        {
            string result = "";

            result = result + menuHeader + System.Environment.NewLine;

            for(int menuIndex = 0; menuIndex < MenuEntries.Count; menuIndex++)
            {
                if (MenuEntries[menuIndex].IsLocked)
                    result = result + menuIndex + ". (#) " + MenuEntries[menuIndex].MenuName + System.Environment.NewLine;
                else if (currentCursorIndex == menuIndex)
                    result = result + menuIndex + ". (X) " + MenuEntries[menuIndex].MenuName + System.Environment.NewLine;
                else
                    result = result + menuIndex + ". ( ) " + MenuEntries[menuIndex].MenuName + System.Environment.NewLine;
            }

            return result;
        }

        public void MenuIndexUp()
        {
            if (currentCursorIndex <= 0)
                currentCursorIndex = MenuEntries.Count-1;
            else
                currentCursorIndex--;
        }

        public void MenuIndexLock()
        {
            MenuEntries[currentCursorIndex].IsLocked = !MenuEntries[currentCursorIndex].IsLocked;
        }

        public void MenuIndexDown()
        {
            if (currentCursorIndex >= MenuEntries.Count)
                currentCursorIndex = 0;
            else
                currentCursorIndex++;
        }

        public List<int> GetHackIndex()
        {
            List<int> hackIndexes = new List<int>();

            for(int i = 0; i < MenuEntries.Count; i++)
            {
                if (MenuEntries[i].IsLocked)
                    hackIndexes.Add(i);
            }

            return hackIndexes;
        }

        public int GetCurrentMenuCursorIndex()
        {
            return currentCursorIndex;
        }
    }
}
