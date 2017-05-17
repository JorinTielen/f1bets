using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Queries
{
    static class UserQueries
    {
        public static string GetPassword(string username)
        {
            return $"SELECT [password] FROM[User] WHERE username = '{username}'";
        }
    }
}
