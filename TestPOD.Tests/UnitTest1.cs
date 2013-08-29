using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ninject;
using TestPOD.Core;
using TestPOD.Entities;
using TestPOD.Repositories;

namespace TestPOD.Tests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestGetInitialItemStatus()
        {
            var mock = new Mock<IOrderStatusRepository>();
            mock.Setup(s => s.GetInitialItemStatus()).Returns(new ItemStatus()
            {
                Code = "IN",
                Description = "New"
            });

            OrderStatusBLO bo = new OrderStatusBLO(mock.Object);
            ItemStatus status = bo.GetInitialItemStatus();
            Assert.IsNotNull(status);
        }

        [TestMethod]
        public void TestGetAvailableItemStatus()
        {
            ItemStatus CurrentItemStatus = new ItemStatus()
            {
                Code = "IN",
                Description = "New"
            };
            OrderStatus CurrentOrderStatus = new OrderStatus()
            {
                Code = "CO",
                Description = "New"
            };
            Product Item = new Product()
            {
                StyleNumber = ""
            };

            List<ItemStatus> statuses = new List<ItemStatus>();
            statuses.Add(new ItemStatus()
            {
                Code = "IV",
                Description = "Cancelled"
            });
            statuses.Add(new ItemStatus()
            {
                Code = "IZP",
                Description = "Ship"
            });
            statuses.Add(new ItemStatus()
            {
                Code = "IX",
                Description = "Not Available"
            });

            var mock = new Mock<IOrderStatusRepository>();
            mock.Setup(s => s.GetAvailableItemStatuses(CurrentItemStatus, CurrentOrderStatus, Item)).Returns(statuses);


            OrderStatusBLO bo = new OrderStatusBLO(mock.Object);
            List<ItemStatus> retVal = bo.GetAvailableItemStatus(CurrentItemStatus, CurrentOrderStatus, Item);
            Assert.IsTrue(retVal.Count > 0);
            Assert.IsTrue(retVal.FindAll(s => s.Code == "IZP").Count > 0);
        }
    }
}
