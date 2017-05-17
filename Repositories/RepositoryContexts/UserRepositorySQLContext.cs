using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Repositories.Queries;
using Models;

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

        public int GetID(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(UserQueries.GetID(username), connection);
                connection.Open();
                try
                {
                    return Convert.ToInt32(command.ExecuteScalar());
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }
        }

        public void CreateUser(string username, string password, string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(UserQueries.CreateUser(username, password, email), connection);
                connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }
        }

        public void EditUser(int id, string username, string password, string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(UserQueries.EditUser(id, username, password, email), connection);
                connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }
        }

        public User GetUser(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(UserQueries.GetUser(username), connection);
                connection.Open();
                try
                {
                    User u = null;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            u = new User(
                                (int)reader["id"],
                                (string)reader["username"],
                                (string)reader["password"],
                                (string)reader["email_address"]);
                        }
                    }
                    return u;
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }
        }
    }
}
