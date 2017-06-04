using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Repositories.RepositoryContexts
{
    public interface IPredictionRepositoryContext
    {
        void Place(Prediction p);
    }
}
