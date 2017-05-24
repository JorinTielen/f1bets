using System;
using System.Collections.Generic;
using Repositories.RepositoryContexts;
using Models;

namespace Repositories
{
    public class CompetitionRepository
    {
        private ICompetitionRepositoryContext context;

        public CompetitionRepository(ICompetitionRepositoryContext context)
        {
            this.context = context;
        }

        public List<Competition> GetCompetitions()
        {
            return context.GetCompetitions();
        }

        public List<Competition> GetUpcomingCompetitions()
        {
            return context.GetUpcomingCompetitions();
        }

        public Competition GetCompetition(int id)
        {
            return context.GetCompetition(id);
        }

        public int GetDriverIDFromDriverNumber(int id)
        {
            return context.GetDriverIDFromDriverNumber(id);
        }

        internal int GetCompetitionIDFromRoundNumber(int roundNumber)
        {
            return context.GetCompetitionIDFromRoundNumber(roundNumber);
        }

        internal void InsertResult(int competition_id, int driver_id, int points, int position, bool fastest)
        {
            context.InsertResult(competition_id, driver_id, points, position, fastest);
        }
    }
}
