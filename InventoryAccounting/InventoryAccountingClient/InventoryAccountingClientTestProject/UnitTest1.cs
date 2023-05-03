using InventoryAccountingClient.Classes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using InventoryAccountingWebApi.Models;

namespace InventoryAccountingClientTestProject
{
    public class Tests
    {
        int idInventory;
        int idcategory;
        int idrole;
        int iduser;
        [SetUp]
        public void Setup()
        {

            foreach (var item in RequestTasks.GetInventory().Result)
            {
                idInventory = item.Id;
            }
            foreach (var item in RequestTasks.GetCategory().Result)
            {
                idcategory = item.Id;
            }
            foreach (var item in RequestTasks.GetRole().Result)
            {
                idrole = item.Id;
            }
            foreach (var item in RequestTasks.GetUsers().Result)
            {
                iduser = item.Id;
            }




        }

        [Test]
        public void TestGetInventory1()
        {
            //arrange

            //act
            List<InventoryAccountingWebApi.Models.Inventory> actual = RequestTasks.GetInventory().Result;
            //assert
            Assert.NotNull(actual);
        }
        [Test]
        public void TestGetCategory1()
        {
            //arrange

            //act
            List<InventoryAccountingWebApi.Models.Category> actual = RequestTasks.GetCategory().Result;
            //assert
            Assert.NotNull(actual);
        }
        [Test]
        public void TestGetRole1()
        {
            //arrange

            //act
            List<InventoryAccountingWebApi.Models.Role> actual = RequestTasks.GetRole().Result;
            //assert
            Assert.NotNull(actual);
        }
        [Test]
        public void TestGetUsers1()
        {
            //arrange

            //act
            List<InventoryAccountingWebApi.Models.User> actual = RequestTasks.GetUsers().Result;
            //assert
            Assert.NotNull(actual);
        }
        [Test]
        public void TestPostInventory1()
        {
            //arrange
            bool expected = true;

            //act
            bool testPostActual = RequestTasks.PostInventory("TestName", 999, 1).Result;

            //assert
            Assert.That(expected, Is.EqualTo(testPostActual));
        }
        [Test]
        public void TestPostCategory1()
        {
            //arrange
            bool expected = true;

            //act
            bool testPostActual = RequestTasks.PostCategory("TestName").Result;

            //assert
            Assert.That(expected, Is.EqualTo(testPostActual));
        }
        [Test]
        public void TestPostRole1()
        {
            //arrange
            bool expected = true;

            //act
            bool testPostActual = RequestTasks.PostRole("TestName").Result;

            //assert
            Assert.That(expected, Is.EqualTo(testPostActual));
        }
        [Test]
        public void TestPostUsers1()
        {
            //arrange
            bool expected = true;

            //act
            bool testPostActual = RequestTasks.PostUsers("Testlogin", "TestPassword", 1).Result;

            //assert
            Assert.That(expected, Is.EqualTo(testPostActual));
        }
        [Test]
        public void TestPutInventory1()
        {
            //arrange
            //idInventory from SetUp
            bool expected = true;

            //act
            bool testPostActual = RequestTasks.PutInventory(idInventory, "TestName", 999, 1).Result;

            //assert
            Assert.That(expected, Is.EqualTo(testPostActual));
        }
        [Test]
        public void TestPutCategory1()
        {
            //arrange
            //idcategory from SetUp
            bool expected = true;

            //act
            bool testPostActual = RequestTasks.PutCategory(idcategory, "TestName").Result;

            //assert
            Assert.That(expected, Is.EqualTo(testPostActual));
        }
        [Test]
        public void TestPutRole1()
        {
            //arrange
            //idrole from SetUp
            bool expected = true;

            //act
            bool testPostActual = RequestTasks.PutRole(idrole, "TestName").Result;

            //assert
            Assert.That(expected, Is.EqualTo(testPostActual));
        }
        [Test]
        public void TestPutUsers1()
        {
            //arrange
            //iduser from SetUp
            bool expected = true;

            //act
            bool testPostActual = RequestTasks.PutUsers(iduser, "Testlogin", "TestPassword", 1).Result;

            //assert
            Assert.That(expected, Is.EqualTo(testPostActual));
        }
        [Test]
        public void TestDeleteInventory1()
        {
            //arrange
            //idInventory from SetUp

            //act
            var result = RequestTasks.DeleteInventory(idInventory).Result;

            //assert
            Assert.That(result);
        }
        [Test]
        public void TestDeleteCategory1()
        {
            //arrange
            //idcategory from SetUp

            //act
            var result = RequestTasks.DeleteCategory(idcategory).Result;

            //assert
            Assert.That(result);
        }
        [Test]
        public void TestDeleteRole1()
        {
            //arrange
            //idrole from SetUp

            //act
            var result = RequestTasks.DeleteRole(idrole).Result;

            //assert
            Assert.That(result);
        }
        [Test]
        public void TestDeleteUsers1()
        {
            //arrange
            //iduser from SetUp

            //act
            var result = RequestTasks.DeleteUsers(iduser).Result;

            //assert
            Assert.That(result);
        }
    }
}