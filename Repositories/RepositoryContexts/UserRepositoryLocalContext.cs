using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Repositories.RepositoryContexts
{
    public class UserRepositoryLocalContext : IUserRepositoryContext
    {
        private List<User> users = new List<User>()
        {
            new User(1, "admin", "adminpassword", "admin@admin.com", true),
            new User(2, "user", "userpassword", "user@user.com", false),
        };

        public void AcceptUserFriend(User u, int? friend_id)
        {
            throw new NotImplementedException();
        }

        public void AddFriend(User u, int? id)
        {
            foreach (var user in users)
            {
                if (user.ID == (int)id)
                {
                    user.Friends.Add(u);
                }
            }
        }

        public void CreateUser(string username, string password, string email)
        {
            User u = new User();
            u.ID = users.Count + 1;
            u.Username = username;
            u.Password = password;
            u.Email = email;
            users.Add(u);
        }

        public void DeleteUserFriend(User u, int? id)
        {
            foreach (var user in users)
            {
                if (user.ID == (int)id)
                {
                    user.Friends.Remove(u);
                }
            }
        }

        public void EditUser(int id, string username, string password, string email)
        {
            foreach (var user in users)
            {
                if (user.ID == id)
                {
                    user.Username = username;
                    user.Password = password;
                    user.Email = email;
                }
            }
        }

        public List<User> GetAcceptedFriends(int id)
        {
            User u = GetUser(id);
            return u.Friends;
        }

        public int GetID(string username)
        {
            foreach (var user in users)
            {
                if (user.Username == username)
                {
                    return user.ID;
                }
            }
            return -1;
        }

        public string GetPassword(string username)
        {
            foreach (var user in users)
            {
                if (user.Username == username)
                {
                    return user.Password;
                }
            }
            return "";
        }

        public List<UserFriend> GetPendingUserFriends(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string username)
        {
            foreach (var user in users)
            {
                if (user.Username == username)
                {
                    return user;
                }
            }
            return null;
        }

        public User GetUser(int id)
        {
            foreach (var user in users)
            {
                if (user.ID == id)
                {
                    return user;
                }
            }
            return null;
        }

        public IEnumerable<string> GetUserNames()
        {
            List<string> usernames = new List<string>();
            foreach (var user in users)
            {
                usernames.Add(user.Username);
            }
            return usernames;
        }

        public List<UserFriend> GetWaitingUserFriends(int id)
        {
            throw new NotImplementedException();
        }
    }
}
