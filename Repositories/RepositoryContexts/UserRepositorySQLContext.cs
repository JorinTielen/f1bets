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
        private static readonly string connectionString = @"Server= DESKTOP-FB2QFPO;Database=f1bets_dev;Trusted_Connection=True;";

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
                                (string)reader["email_address"],
                                (bool)reader["admin"]);
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

        public User GetUser(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(UserQueries.GetUser(id), connection);
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
                                (string)reader["email_address"],
                                (bool)reader["admin"]);
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

        public List<User> GetAcceptedFriends(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(UserQueries.GetAcceptedFriends(id), connection);
                connection.Open();
                try
                {
                    List<User> friends = new List<User>();
                    
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            friends.Add(GetUser((int)reader["friend"]));
                        }
                    }
                    return friends;
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }
        }

        public List<UserFriend> GetPendingUserFriends(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(UserQueries.GetPendingFriends(id), connection);
                connection.Open();
                try
                {
                    List<UserFriend> friends = new List<UserFriend>();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UserFriend uf = new UserFriend();
                            uf.User = GetUser((int)reader["friend"]);
                            uf.Pending = (bool)reader["pending"];
                            friends.Add(uf);
                        }
                    }
                    return friends;
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }
        }

        public List<UserFriend> GetWaitingUserFriends(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(UserQueries.GetWatingFriends(id), connection);
                connection.Open();
                try
                {
                    List<UserFriend> friends = new List<UserFriend>();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UserFriend uf = new UserFriend();
                            uf.User = GetUser((int)reader["friend"]);
                            uf.Pending = (bool)reader["pending"];
                            friends.Add(uf);
                        }
                    }
                    return friends;
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }
        }

        public void AcceptUserFriend(User u, int? friend_id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(UserQueries.AcceptUserFriend(u, friend_id), connection);
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
    }
}
