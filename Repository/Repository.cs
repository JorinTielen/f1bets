using System;
using Repository.RepositoryContexts;

namespace Repository
{
    public class Repository
    {
        private IRepositoryContext context;

        public Repository(IRepositoryContext context)
        {
            this.context = context;
        }
    }
}
