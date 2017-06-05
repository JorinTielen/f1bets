using System;
using System.Collections.Generic;
using System.Text;
using Repositories.RepositoryContexts;
using Models;

namespace Repositories
{
    public class PredictionRepository
    {
        private IPredictionRepositoryContext context;

        public PredictionRepository(IPredictionRepositoryContext context)
        {
            this.context = context;
        }

        public void Place(Prediction p)
        {
            context.Place(p);
        }

        public List<Prediction> GetAllPredictions(User u)
        {
            return context.GetAllPredictions(u);
        }
    }
}
