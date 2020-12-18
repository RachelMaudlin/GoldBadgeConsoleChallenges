using System;
using System.Collections.Generic;
using CafeMenu_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CafeMenu_Tests
{
    [TestClass]
    public class KomodoCafe_RepositoryTests
    {
        private CafeMenuRepository _repo;
        private CafeMenu _item;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new CafeMenuRepository();
            _item = new CafeMenu(6, "Bix's Buffet", "Endless Food", "Access to the whole buffet and unlimited refills", 25.99);
            _repo.AddItemToMenu(_item);
        }

        //ADD METHOD
        [TestMethod]
        public void AddToMenu_ShouldGetNotNull()
        {
            //ARRANGE
            CafeMenu item = new CafeMenu();
            item.MealNumber = 1;
            CafeMenuRepository repository = new CafeMenuRepository();
            //ACT
            repository.AddItemToMenu(item);
            CafeMenu itemFromDirectory = repository.GetItemByNumber(1);
            //ASSERT
            Assert.IsNotNull(itemFromDirectory);
        }
        //UPDATE
        [TestMethod]
        public void UpdateMenuItem_ShouldReturnNotNull()
        {
            //ARRANGE
            //TEST INITIALIZE
            CafeMenu newItem = new CafeMenu(6, "Bix's Bountiful Buffet", "Endless Food For One", "Access to the whole buffet and unlimited refills", 25.99);
            //ACT
            bool updateResult = _repo.UpdateExistingMenu(6, newItem);
            //ASSERT
            Assert.IsTrue(updateResult);
        }

        [DataTestMethod]
        [DataRow(6, true)]
        [DataRow(8, false)]
        public void UpdateMenuItem_ShouldMatchGivenBool(int originalMealNumber, bool shouldUpdate)
        {
            //ARRANGE
            //TEST INITIALIZE
            CafeMenu newItem = new CafeMenu(6, "Bix's Bountiful Buffet", "Endless Food For One", "Access to the whole buffet and unlimited refills", 25.99);
            //ACT
            bool updateResult = _repo.UpdateExistingMenu(originalMealNumber, newItem);
            //ASSERT
            Assert.AreEqual(shouldUpdate, updateResult);
        }

        [TestMethod]
        public void DeleteMenuItem_ShouldReturnTrue()
        {
            //ARRANGE

            //ACT
            bool deleteResult = _repo.RemoveItemFromMenu(_item.MealNumber);
            //ASSERT
            Assert.IsTrue(deleteResult);
        }
        //READ
        [TestMethod]
        public void ShowAllItemsOnMenu_NoNullAllowed()
        {
            List<CafeMenu> wholeMenu = _repo.GetCafeMenu();
            Assert.IsNotNull(wholeMenu);

        }
    }
}
