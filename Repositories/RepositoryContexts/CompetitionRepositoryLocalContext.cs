using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Repositories.RepositoryContexts
{
    public class CompetitionRepositoryLocalContext : ICompetitionRepositoryContext
    {
        private List<Competition> competitions = new List<Competition>()
        {
            new Competition() { ID = 1, Date = DateTime.Today, Name = "Test Grand Prix 1", Race = true},
            new Competition() { ID = 2, Date = DateTime.Today, Name = "Test Grand Prix 2", Race = true},
            new Competition() { ID = 3, Date = DateTime.Today, Name = "Test Grand Prix 3", Race = true}
        };

        public void AddReaction(Reaction r)
        {
            throw new NotImplementedException();
        }

        public void AddReply(Reaction r, int replyto_id)
        {
            throw new NotImplementedException();
        }

        public Circuit GetCircuit(int id)
        {
            throw new NotImplementedException();
        }

        public Competition GetCompetition(int id)
        {
            throw new NotImplementedException();
        }

        public int GetCompetitionIDFromRoundNumber(int roundNumber)
        {
            throw new NotImplementedException();
        }

        public List<Competition> GetCompetitions()
        {
            throw new NotImplementedException();
        }

        public Driver GetDriver(int id)
        {
            throw new NotImplementedException();
        }

        public int GetDriverIDFromDriverNumber(int id)
        {
            throw new NotImplementedException();
        }

        public List<Driver> GetDrivers()
        {
            throw new NotImplementedException();
        }

        public List<Driver> GetDriversInRace(int id)
        {
            throw new NotImplementedException();
        }

        public Nationality GetNationality(int id)
        {
            throw new NotImplementedException();
        }

        public List<Competition> GetPastCompetitions()
        {
            throw new NotImplementedException();
        }

        public List<Reaction> GetReactions(int competition_id)
        {
            throw new NotImplementedException();
        }

        public List<Result> GetResultsFromRace(int id)
        {
            throw new NotImplementedException();
        }

        public int GetRoundNumberFromCompetitionID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Competition> GetUpcomingCompetitions()
        {
            return competitions;
        }

        public void InsertResult(int competition_id, int driver_id, int points, int position, bool fastest)
        {
            throw new NotImplementedException();
        }
    }
}
