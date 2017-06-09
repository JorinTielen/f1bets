using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;
using Repositories.RepositoryContexts;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class CompetitionUnitTest
    {
        [TestMethod]
        public void TestGetCompetitions()
        {
            CompetitionRepository repo = new CompetitionRepository(new CompetitionRepositoryLocalContext());

            List<Competition> comps = repo.GetUpcomingCompetitions();

            Assert.AreEqual(3, comps.Count);
        }
    }
}
