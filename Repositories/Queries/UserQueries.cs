using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Repositories.Queries
{
    static class UserQueries
    {
        internal static string GetPassword(string username)
        {
            return $"SELECT [password] FROM [User] WHERE username = '{username}'";
        }

        internal static string GetID(string username)
        {
            return $"SELECT [id] FROM [User] WHERE username = '{username}'";
        }

        internal static string GetUser(string username)
        {
            return $"SELECT id, username, [password], email_address, [admin] FROM [User] WHERE username = '{username}'";
        }

        internal static string GetUser(int id)
        {
            return $"SELECT id, username, [password], email_address, [admin] FROM [User] WHERE id = {id}";
        }

        internal static string CreateUser(string username, string password, string email)
        {
            return $"INSERT INTO [User] (username, password, email_address) VALUES ('{username}','{password}','{email}')";
        }

        internal static string EditUser(int id, string username, string password, string email)
        {
            return $"UPDATE [User] SET username = '{username}', [password] = '{password}', email_address = '{email}' WHERE [id] = {id}";
        }

        internal static string GetAcceptedFriends(int id)
        {
            return $"SELECT CASE WHEN sender_user_id = {id} THEN reciever_user_id ELSE sender_user_id END AS friend FROM [dbo].User_Friend WHERE pending = 0 AND (sender_user_id = {id} OR reciever_user_id = {id})";
        }

        internal static string GetPendingFriends(int id)
        {
            return $"SELECT sender_user_id AS friend, pending FROM [dbo].User_Friend WHERE pending = 1 AND reciever_user_id = {id}";
        }

        internal static string GetWatingFriends(int id)
        {
            return $"SELECT reciever_user_id AS friend, pending FROM [dbo].User_Friend WHERE pending = 1 AND sender_user_id = {id}";

        }

        internal static string AcceptUserFriend(User u, int? friend_id)
        {
            return $"UPDATE User_Friend SET pending = 0 WHERE reciever_user_id = {u.ID} AND sender_user_id = {friend_id}";
        }
    }
}
