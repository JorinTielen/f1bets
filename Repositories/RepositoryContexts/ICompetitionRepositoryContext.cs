﻿using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Repositories.RepositoryContexts
{
    public interface ICompetitionRepositoryContext
    {
        List<Competition> GetCompetitions();
        List<Competition> GetUpcomingCompetitions();
        Competition GetCompetition(int id);
        Circuit GetCircuit(int id);
        Driver GetDriver(int id);
        Nationality GetNationality(int id);
        int GetDriverIDFromDriverNumber(int id);
        int GetCompetitionIDFromRoundNumber(int roundNumber);
        void InsertResult(int competition_id, int driver_id, int points, int position, bool fastest);
        List<Competition> GetPastCompetitions();
        List<Driver> GetDriversInRace(int id);
        int GetRoundNumberFromCompetitionID(int id);
        List<Result> GetResultsFromRace(int id);
        List<Driver> GetDrivers();
        List<Reaction> GetReactions(int competition_id);
        void AddReaction(Reaction r);
        void AddReply(Reaction r, int replyto_id);
    }
}
