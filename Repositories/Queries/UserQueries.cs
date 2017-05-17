using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Queries
{
    static class UserQueries
    {
        public static string GetPassword(string username)
        {
            return $"SELECT [password] FROM [User] WHERE username = '{username}'";
        }

        public static string GetID(string username)
        {
            return $"SELECT [id] FROM [User] WHERE username = '{username}'";
        }

        public static string GetUser(string username)
        {
            return $"SELECT id, username, [password], email_address FROM [User] WHERE username = '{username}'";
        }

        public static string CreateUser(string username, string password, string email)
        {
            return $"INSERT INTO [User] (username, password, email_address) VALUES ('{username}','{password}','{email}')";
        }

        public static string EditUser(int id, string username, string password, string email)
        {
            return $"UPDATE [User] SET username = '{username}', [password] = '{password}', email_address = '{email}' WHERE [id] = {id}";
        }
    }
}
