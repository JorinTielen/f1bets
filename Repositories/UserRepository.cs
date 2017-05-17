using System;
using Repositories.RepositoryContexts;
using Models;

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

        public void EditUser(int id, string username, string password, string email)
        {
            context.EditUser(id, username, password, email);
        }

        public User GetUser(string username)
        {
            return context.GetUser(username);
        }
    }
}
