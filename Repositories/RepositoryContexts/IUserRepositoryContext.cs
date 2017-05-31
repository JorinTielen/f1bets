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
        List<User> GetAcceptedFriends(int id);
        List<UserFriend> GetPendingUserFriends(int id);
        List<UserFriend> GetWaitingUserFriends(int id);
        void AcceptUserFriend(User u, int? friend_id);
    }
}
