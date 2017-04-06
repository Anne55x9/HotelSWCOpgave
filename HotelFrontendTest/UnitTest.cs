using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using HotelFrontend.ViewModel;
using HotelFrontend.Models;
using HotelFrontend.Connection;

namespace HotelFrontendTest
{
    [TestClass]
    public class UnitTest1
    {
        public Singleton singleton
        {
            get { return Singleton.Instance; }
            set { /* nothing */ }
        }

        [TestMethod]
        public void TestGetAllGuests()
        {
            Facade facade = new Facade();
            singleton.GuestList = facade.GetAllGuests().Result;
            Assert.AreNotEqual(0, singleton.GuestList.Count);
            CollectionAssert.AllItemsAreNotNull(singleton.GuestList);
        }
    }
}
