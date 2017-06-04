using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;
using Repositories.RepositoryContexts;
using Models;

namespace UnitTests
{
    [TestClass]
    public class UserUnitTest
    {
        [TestMethod]
        public void TestRegister()
        {
            UserRepository repo = new UserRepository(new UserRepositoryLocalContext());

            repo.CreateUser("UnitTest", "UnitTestPassword", "Unit@Test.com");
            User test = repo.GetUser("UnitTest");

            Assert.AreEqual("UnitTest", test.Username);
            Assert.AreEqual("UnitTestPassword", test.Password);
            Assert.AreEqual("Unit@Test.com", test.Email);
        }

        [TestMethod]
        public void TestSettings()
        {
            UserRepository repo = new UserRepository(new UserRepositoryLocalContext());

            repo.CreateUser("UnitTest", "UnitTestPassword", "Unit@Test.com");
            int id = repo.GetID("UnitTest");

            repo.EditUser(id, "UnitTest2", "UnitTestPassword2", "Unit@Test2.com");

            User test = repo.GetUser(id);

            Assert.AreEqual("UnitTest2", test.Username);
            Assert.AreEqual("UnitTestPassword2", test.Password);
            Assert.AreEqual("Unit@Test2.com", test.Email);
        }
    }
}
