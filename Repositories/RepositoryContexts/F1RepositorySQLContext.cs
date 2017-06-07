using System;
using System.Collections.Generic;
using System.Text;
using Models;
using System.Data.SqlClient;
using Repositories.Queries;

namespace Repositories.RepositoryContexts
{
    public class F1RepositorySQLContext : IF1RepositoryContext
    {
        private static readonly string connectionString = @"Server= 192.168.19.12;Persist Security Info=False;User ID=frietpan;Password=frietpan;Database=f1bets_dev;";

        public Driver GetDriver(int? id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(F1Queries.GetDriver(id), connection);
                connection.Open();
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Driver d = new Driver();
                        while (reader.Read())
                        {
                            d.ID = (int)reader["id"];
                            d.DriverNumber = (int)reader["driverNumber"];
                            d.Name = (string)reader["name"];
                            d.SurName = (string)reader["surname"];
                            d.Nationality = GetNationality((int)reader["nationality_id"]);
                            d.TotalStarts = (int)reader["totalstarts"];
                            d.TotalPodiums = (int)reader["totalpodiums"];
                            d.TotalWins = (int)reader["totalwins"];
                            d.TotalPolepositions = (int)reader["totalpolepositions"];
                            d.TotalWDC = (int)reader["totalwdc"];
                            d.TotalPoints = (int)reader["totalpoints"];
                        }
                        return d;
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }
        }

        public List<Result> GetDriverResults(int? id)
        {
            return new List<Result>();
        }

        public List<Driver> GetDrivers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(CompetitionQueries.GetDrivers(), connection);
                connection.Open();
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Driver> drivers = new List<Driver>();
                        while (reader.Read())
                        {
                            Driver d = new Driver();
                            d.ID = (int)reader["id"];
                            d.DriverNumber = (int)reader["driverNumber"];
                            d.Name = (string)reader["name"];
                            d.SurName = (string)reader["surname"];
                            d.Nationality = GetNationality((int)reader["nationality_id"]);
                            d.TotalStarts = (int)reader["totalstarts"];
                            d.TotalPodiums = (int)reader["totalpodiums"];
                            d.TotalWins = (int)reader["totalwins"];
                            d.TotalPolepositions = (int)reader["totalpolepositions"];
                            d.TotalWDC = (int)reader["totalwdc"];
                            d.TotalPoints = (int)reader["totalpoints"];
                            drivers.Add(d);
                        }
                        return drivers;
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }
        }

        public Team GetTeam(int? id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(F1Queries.GetTeam(id), connection);
                connection.Open();
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Team t = new Team();
                        while (reader.Read())
                        {
                            
                            t.ID = (int)reader["id"];
                            t.Name = (string)reader["name"];
                            t.Chassis = (string)reader["chassis"];
                            t.Nationality = GetNationality((int)reader["nationality_id"]);
                            t.TotalPodiums = (int)reader["totalpodiums"];
                            t.TotalWins = (int)reader["totalwins"];
                            t.TotalWCC = (int)reader["totalwcc"];
                            t.TotalPoints = (int)reader["totalpoints"];

                            t.Drivers = GetDriversFromTeam(t.ID);
                        }
                        return t;
                    }
                    
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }
        }

        public List<Team> GetTeams()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(F1Queries.GetTeams(), connection);
                connection.Open();
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Team> teams = new List<Team>();
                        while (reader.Read())
                        {
                            Team t = new Team();
                            t.ID = (int)reader["id"];
                            t.Name = (string)reader["name"];
                            t.Chassis = (string)reader["chassis"];
                            t.Nationality = GetNationality((int)reader["nationality_id"]);
                            t.TotalPodiums = (int)reader["totalpodiums"];
                            t.TotalWins = (int)reader["totalwins"];
                            t.TotalWCC = (int)reader["totalwcc"];
                            t.TotalPoints = (int)reader["totalpoints"];

                            t.Drivers = GetDriversFromTeam(t.ID);
                            teams.Add(t);
                        }
                        return teams;
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }

        }

        private List<Driver> GetDriversFromTeam(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(F1Queries.GetDriversFromTeam(id), connection);
                connection.Open();
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Driver> drivers = new List<Driver>();
                        while (reader.Read())
                        {
                            Driver d = new Driver();
                            d.ID = (int)reader["id"];
                            d.DriverNumber = (int)reader["driverNumber"];
                            d.Name = (string)reader["name"];
                            d.SurName = (string)reader["surname"];
                            d.Nationality = GetNationality((int)reader["nationality_id"]);
                            d.TotalStarts = (int)reader["totalstarts"];
                            d.TotalPodiums = (int)reader["totalpodiums"];
                            d.TotalWins = (int)reader["totalwins"];
                            d.TotalPolepositions = (int)reader["totalpolepositions"];
                            d.TotalWDC = (int)reader["totalwdc"];
                            d.TotalPoints = (int)reader["totalpoints"];
                            drivers.Add(d);
                        }
                        return drivers;
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }
        }

        private Nationality GetNationality(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(CompetitionQueries.GetNationality(id), connection);
                connection.Open();
                try
                {
                    Nationality n = new Nationality();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            n.ID = (int)reader["id"];
                            n.Name = (string)reader["name"];
                            n.ImagePath = (string)reader["imagepath"];
                        }
                    }
                    return n;
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }
        }
    }
}
