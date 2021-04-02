
using Menu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeOneUnitTest
{
    [TestClass]
    public class MenuItemRepoTest
    {
        [TestMethod]
        public void AddMenuItemToMenuTest()
        {
            MenuItem item = new MenuItem();
            MenuItemRepo repo = new MenuItemRepo();
            bool addResult = repo.AddMenuItemToMenu(item);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetMenuItemsTest()
        {
            MenuItem item = new MenuItem();
            MenuItemRepo repo = new MenuItemRepo();
            repo.AddMenuItemToMenu(item);

            List<MenuItem> listOfItems = repo.GetMenuItems();

            bool menuHasItems = listOfItems.Contains(item);
            Assert.IsTrue(menuHasItems);
        }
        [TestMethod]
        public void DeleteMenuItemTest()
        {
            MenuItem item = new MenuItem();
            MenuItemRepo repo = new MenuItemRepo();
            bool addResult = repo.AddMenuItemToMenu(item);
            Assert.IsTrue(addResult);
            List<MenuItem> listOfItems = repo.GetMenuItems();
            bool menuHasItems = listOfItems.Contains(item);
            if (menuHasItems)
            {
                bool deleteResult = repo.DeleteMenuItem(item);
                Assert.IsTrue(deleteResult);
            }
            
        }
    }
}
