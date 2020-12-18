using System;
using System.Collections.Generic;
using ClaimsDepartment_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimsDepartment_Tests
{
    [TestClass]
    public class ClaimsDepartmentRepositoryTesting
    {
        private ClaimsDepartmentRepository _repo;
        private ClaimItems _item;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimsDepartmentRepository();
            _item = new ClaimItems(1, TypeOfClaim.Car, "Car accident on 465", 400.00, DateTime.Parse("04/25/20"), DateTime.Parse("04 / 27 / 20"), true);
            _repo.AddClaimToQueue(_item);
        }
        //VIEW ALL CLAIMS
        [TestMethod]
        public void ViewAllClaims_NoNullAllowed()
        {
            ClaimsDepartmentRepository repository = new ClaimsDepartmentRepository();
            ClaimItems test = new ClaimItems(1, TypeOfClaim.Car, "Car accident on 465", 400.00, DateTime.Parse("04/25/20"), DateTime.Parse("04 / 27 / 20"), true);
            repository.AddClaimToQueue(test);
            var testing = repository.ReadClaimsQueue();
            Assert.IsNotNull(testing);
        }
        //TAKE CARE OF CLAIM
        [TestMethod]
        public void PeekAtClaim_ShouldReturnNotNull()
        {
            ClaimItems item = new ClaimItems();
            item.ClaimID = 1;
            ClaimsDepartmentRepository repository = new ClaimsDepartmentRepository();

            repository.AddClaimToQueue(item);
            ClaimItems itemsFromQueue = repository.TakeCareOfClaim();
            Assert.IsNotNull(itemsFromQueue);
        }

        //CREATE CLAIM
        [TestMethod]
        public void AddClaimToQueue_NoNullAllowed()
        {
            ClaimItems item = new ClaimItems();
            item.ClaimID = 1;
            ClaimsDepartmentRepository repository = new ClaimsDepartmentRepository();

            repository.AddClaimToQueue(item);
            ClaimItems itemsFromQueue = repository._ClaimsQueue.Peek();
            Assert.IsNotNull(itemsFromQueue);

        }
    }
}
