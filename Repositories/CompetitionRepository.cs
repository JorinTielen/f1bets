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

        public List<Competition> GetPastCompetitions()
        {
            return context.GetPastCompetitions();
        }

        public int GetDriverIDFromDriverNumber(int id)
        {
            return context.GetDriverIDFromDriverNumber(id);
        }

        internal int GetCompetitionIDFromRoundNumber(int roundNumber)
        {
            return context.GetCompetitionIDFromRoundNumber(roundNumber);
        }

        public int GetRoundNumberFromRaceID(int id)
        {
            return context.GetRoundNumberFromCompetitionID(id);
        }

        internal void InsertResult(int competition_id, int driver_id, int points, int position, bool fastest)
        {
            context.InsertResult(competition_id, driver_id, points, position, fastest);
        }

        public List<Reaction> GetReactions(int competition_id)
        {
            return context.GetReactions(competition_id);
        }

        public List<Driver> GetDrivers()
        {
            return context.GetDrivers();
        }

        public List<Driver> GetDriversInRace(int id)
        {
            return context.GetDriversInRace(id);
        }

        public List<Result> GetResultsFromRace(int id)
        {
            return context.GetResultsFromRace(id);
        }

        public Driver GetDriver(int id)
        {
            return context.GetDriver(id);
        }

        public void AddReaction(Reaction r)
        {
            context.AddReaction(r);
        }
    }
}
