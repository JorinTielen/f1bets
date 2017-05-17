using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Repositories.RepositoryContexts
{
    public interface IUserRepositoryContext
    {
        string GetPassword(string username);
        int GetID(string username);
        void CreateUser(string username, string password, string email);
        void EditUser(int id, string username, string password, string email);
        User GetUser(string username);
    }
}
