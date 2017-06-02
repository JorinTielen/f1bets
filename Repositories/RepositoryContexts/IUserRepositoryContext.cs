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
        User GetUser(int id);
        List<User> GetAcceptedFriends(int id);
        List<UserFriend> GetPendingUserFriends(int id);
        List<UserFriend> GetWaitingUserFriends(int id);
        void AcceptUserFriend(User u, int? friend_id);
        void AddFriend(User u, int? id);
        void DeleteUserFriend(User u, int? id);
    }
}
