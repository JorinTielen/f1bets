using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Repositories.Queries;

namespace Repositories.RepositoryContexts
{
    public class UserRepositorySQLContext : IUserRepositoryContext
    {
        private static readonly string connectionString = @"Server= DESKTOP-FB2QFPO;Database=f1bets;Trusted_Connection=True;";

        public string GetPassword(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(UserQueries.GetPassword(username), connection);
                connection.Open();
                try
                {
                    return command.ExecuteScalar().ToString();
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }
        }
    }
}
