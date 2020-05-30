using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba8
{

    public class ConsoleMenu : List<MenuEntry>
    {

        public string PrintMenu(char separatorChar = '.', char finalChar = '\n')
        {
            string menu = "";
            ushort numbers = 1;
            foreach (MenuEntry ME in this)
            {
                menu += string.Format("{0}{1} {2}{3}", numbers++, separatorChar, ME.Description, finalChar);
            }
            return menu;
        }

        public bool ExecuteEntry(int MenuIndex)
        {
            if (MenuIndex > this.Count)
            {
                return false;
            }
            this[MenuIndex - 1].ExecuteEntry();
            return true;
        }
    }
}