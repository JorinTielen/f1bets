using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.RepositoryContexts
{
    public interface IUserRepositoryContext
    {
        string GetPassword(string username);
    }
}
