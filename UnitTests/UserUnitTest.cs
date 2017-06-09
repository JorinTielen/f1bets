using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;
using Repositories.RepositoryContexts;
using Models;
using System.Collections.Generic;
using System.Linq;

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

        [TestMethod]
        public void TestAddFriend()
        {
            UserRepository repo = new UserRepository(new UserRepositoryLocalContext());

            User u = repo.GetUser(2);
            repo.AddFriend(u, 1);

            User u2 = repo.GetUser(1);
            u2.Friends = repo.GetAcceptedFriends(u2.ID);
            Assert.AreEqual(1, u2.Friends.Count);

            Assert.AreEqual(u, u2.Friends[0]);
        }

        [TestMethod]
        public void TestRemoveFriend()
        {
            UserRepository repo = new UserRepository(new UserRepositoryLocalContext());

            User u = repo.GetUser(2);
            repo.AddFriend(u, 1);

            User u2 = repo.GetUser(1);
            u2.Friends = repo.GetAcceptedFriends(u2.ID);

            Assert.AreEqual(u, u2.Friends[0]);
            Assert.AreEqual(1, u2.Friends.Count);

            repo.DeleteUserFriend(u, 1);

            Assert.AreEqual(0, u2.Friends.Count);
        }

        [TestMethod]
        public void TestGetPassword()
        {
            UserRepository repo = new UserRepository(new UserRepositoryLocalContext());

            string pass = repo.GetPassword("admin");

            Assert.AreEqual("adminpassword", pass);
        }

        [TestMethod]
        public void TestGetUsernames()
        {
            UserRepository repo = new UserRepository(new UserRepositoryLocalContext());

            IEnumerable<string> usernames = repo.GetUserNames();

            Assert.AreEqual(2, usernames.Count());
        }
    }
}
