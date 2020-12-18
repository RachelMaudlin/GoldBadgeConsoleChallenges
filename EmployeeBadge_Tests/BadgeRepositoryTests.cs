using System;
using System.Collections.Generic;
using EmployeeBadge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeBadge_Tests
{
    [TestClass]
    public class BadgeRepositoryTests
    {
        private EmployeeBadgeRepository _repo;
        private EmployeeBadge _badge;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new EmployeeBadgeRepository();
            _badge = new EmployeeBadge(12345, new List<string> {"A7"});

            _repo.AddNewBadge(_badge.BadgeID, _badge);
        }

        //CREATE
        [TestMethod]
        public void AddToDictionary_NoNullAllowed()
        {
            //ARRANGE
            EmployeeBadge employeeBadge = new EmployeeBadge();
            int badgeID = employeeBadge.BadgeID;
            EmployeeBadgeRepository repository = new EmployeeBadgeRepository();
            //ACT
            repository.AddNewBadge(badgeID, employeeBadge);
            EmployeeBadge conentFromDictionary = repository.GetBadgeByID(badgeID);
            //ASSERT
            Assert.IsNotNull(conentFromDictionary);
        }

        //SHOW LIST OF ALL ITEMS 
        [TestMethod]
        public void ShowListOfItems_NoNullAllowed()
        {
            Dictionary<int, EmployeeBadge> keyValuePairs = _repo.GetEmployeeDictionary();
            Assert.IsNotNull(keyValuePairs);
        }

        //ADD ACCES TO DOOR
        [TestMethod]
        public void AddAccessToDoor_ShouldReturnTrue()
        {
            //ARRANGE
            //TestInit
            EmployeeBadge newBadge = new EmployeeBadge(12346, new List<string> { "A7", "A4", "B1" });
            _repo.AddNewBadge(newBadge.BadgeID, newBadge);
            //ACT
            bool updateResult = _repo.AddDoorToExistingBadge(12346, "B6");
            bool updateResult1 = _repo.AddDoorToExistingBadge(12345, "B6");
            //ASSERT
            Assert.IsTrue(updateResult);
            Assert.IsTrue(updateResult1);
        }
        //REMOVE ACCES TO DOOR
        [TestMethod]
        public void RemoveAccessToDoor_ShouldReturnTrue()
        {
            EmployeeBadge newBadge = new EmployeeBadge(12346, new List<string> { "A7", "A4", "B1" });
            _repo.AddNewBadge(newBadge.BadgeID, newBadge);

            bool updateResult = _repo.RemoveDoorFromExistingItem(12346, "B1");
            bool updateResult1 = _repo.RemoveDoorFromExistingItem(12345, "A1");

            Assert.IsTrue(updateResult);
            Assert.IsFalse(updateResult1);
        }
        
    }
}
