using System;
using Repositories.RepositoryContexts;

namespace Repositories
{
    public class UserRepository
    {
        private IUserRepositoryContext context;

        public UserRepository(IUserRepositoryContext context)
        {
            this.context = context;
        }

        public string GetPassword(string username)
        {
            return context.GetPassword(username);
        }
    }
}
