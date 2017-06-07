using System;
using Repositories.RepositoryContexts;
using Models;
using System.Collections.Generic;

namespace Repositories
{
    public class UserRepository
    {
        private IUserRepositoryContext context;

        public UserRepository(IUserRepositoryContext context)
        {
            this.context = context;
        }

        public string GetPassword(string username)
        {
            return context.GetPassword(username);
        }

        public int GetID(string username)
        {
            return context.GetID(username);
        }

        public void CreateUser(string username, string password, string email)
        {
            context.CreateUser(username, password, email);
        }

        public IEnumerable<string> GetUserNames()
        {
            return context.GetUserNames();
        }

        public void EditUser(int id, string username, string password, string email)
        {
            context.EditUser(id, username, password, email);
        }

        public User GetUser(string username)
        {
            return context.GetUser(username);
        }

        public User GetUser(int id)
        {
            return context.GetUser(id);
        }

        public List<User> GetAcceptedFriends(int id)
        {
            return context.GetAcceptedFriends(id);
        }

        public List<UserFriend> GetPendingUserFriends(int id)
        {
            return context.GetPendingUserFriends(id);
        }

        public List<UserFriend> GetWaitingUserFriends(int id)
        {
            return context.GetWaitingUserFriends(id);
        }

        public void AcceptUserFriend(User u, int? friend_id)
        {
            context.AcceptUserFriend(u, friend_id);
        }

        public void AddFriend(User u, int? id)
        {
            context.AddFriend(u, id);
        }

        public void DeleteUserFriend(User u, int? id)
        {
            context.DeleteUserFriend(u, id);
        }
    }
}
