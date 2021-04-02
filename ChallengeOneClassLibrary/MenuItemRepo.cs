using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    public class MenuItemRepo
    {
        protected readonly List<MenuItem> _menuItems = new List<MenuItem>();
        public bool AddMenuItemToMenu(MenuItem item)
        {
            int itemCount = _menuItems.Count;
            _menuItems.Add(item);
            bool wasAdded = (_menuItems.Count > itemCount) ? true : false;
            return wasAdded;
        }
        public List<MenuItem> GetMenuItems()
        {
            return _menuItems;
        }
       public bool DeleteMenuItem(MenuItem existingMenuItem)
        {
            bool deleteResult = _menuItems.Remove(existingMenuItem);
            return deleteResult;
        }
    }
}
