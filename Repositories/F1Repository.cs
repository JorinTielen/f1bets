using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Repositories.RepositoryContexts;

namespace Repositories
{
    public class F1Repository
    {
        private IF1RepositoryContext context;

        public F1Repository(IF1RepositoryContext context)
        {
            this.context = context;
        }

        public Driver GetDriver(int? id)
        {
            return context.GetDriver(id);
        }

        public List<Result> GetDriverResults(int? id)
        {
            return context.GetDriverResults(id);
        }

        public List<Driver> GetDrivers()
        {
            return context.GetDrivers();
        }

        public List<Team> GetTeams()
        {
            return context.GetTeams();
        }

        public Team GetTeam(int? id)
        {
            return context.GetTeam(id);
        }
    }
}
