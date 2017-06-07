using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Repositories.RepositoryContexts
{
    public interface IF1RepositoryContext
    {
        Driver GetDriver(int? id);
        List<Result> GetDriverResults(int? id);
        List<Driver> GetDrivers();
        List<Team> GetTeams();
        Team GetTeam(int? id);
    }
}
