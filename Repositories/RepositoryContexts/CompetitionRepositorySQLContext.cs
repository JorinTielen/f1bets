using System;
using System.Collections.Generic;
using System.Text;
using Models;
using System.Data.SqlClient;
using Repositories.Queries;

namespace Repositories.RepositoryContexts
{
    public class CompetitionRepositorySQLContext : ICompetitionRepositoryContext
    {
        private static readonly string connectionString = @"Server= DESKTOP-FB2QFPO;Database=f1bets_dev;Trusted_Connection=True;";

        public List<Competition> GetCompetitions()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(CompetitionQueries.GetCompetitions(), connection);
                connection.Open();
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Competition> competitions = new List<Competition>();
                        while (reader.Read())
                        {
                            Competition c = new Competition();
                            c.ID      = (int)reader["id"];
                            c.Name    = (string)reader["name"];
                            c.Race    = (bool)reader["race_or_quali"];
                            c.Date    = (DateTime)reader["datetime"];
                            c.Circuit = GetCircuit((int)reader["track_id"]);
                            competitions.Add(c);
                        }
                        return competitions;
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }
        }

        public List<Competition> GetPastCompetitions()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(CompetitionQueries.GetPastCompetitions(), connection);
                connection.Open();
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Competition> competitions = new List<Competition>();
                        while (reader.Read())
                        {
                            Competition c = new Competition();
                            c.ID = (int)reader["id"];
                            c.Name = (string)reader["name"];
                            c.Race = (bool)reader["race_or_quali"];
                            c.Date = (DateTime)reader["datetime"];
                            c.Circuit = GetCircuit((int)reader["track_id"]);
                            competitions.Add(c);
                        }
                        return competitions;
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }
        }

        public List<Competition> GetUpcomingCompetitions()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(CompetitionQueries.GetUpcomingCompetitions(), connection);
                connection.Open();
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Competition> competitions = new List<Competition>();
                        while (reader.Read())
                        {
                            Competition c = new Competition();
                            c.ID = (int)reader["id"];
                            c.Name = (string)reader["name"];
                            c.Race = (bool)reader["race_or_quali"];
                            c.Date = (DateTime)reader["datetime"];
                            c.Circuit = GetCircuit((int)reader["track_id"]);
                            competitions.Add(c);
                        }
                        return competitions;
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }
        }

        public Circuit GetCircuit(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(CompetitionQueries.GetCircuit(id), connection);
                connection.Open();
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Circuit c = new Circuit();
                            c.ID = (int)reader["id"];
                            c.Name = (string)reader["name"];
                            c.Location = (string)reader["location"];
                            c.Nationality = GetNationality((int)reader["nationality_id"]);
                            c.Laprecord = (TimeSpan)reader["laprecord"];
                            return c;
                        }
                    }
                    return null;
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }
        }

        public Nationality GetNationality(int id)
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

        public Competition GetCompetition(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(CompetitionQueries.GetCompetition(id), connection);
                connection.Open();
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Competition c = new Competition();
                        while (reader.Read())
                        {
                            c.ID = (int)reader["id"];
                            c.Name = (string)reader["name"];
                            c.Race = (bool)reader["race_or_quali"];
                            c.Date = (DateTime)reader["datetime"];
                            c.Circuit = GetCircuit((int)reader["track_id"]);
                        }
                        return c;
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }
        }

        public int GetDriverIDFromDriverNumber(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(CompetitionQueries.GetDriverIDFromDriverNumber(id), connection);
                connection.Open();
                try
                {
                    return (int)command.ExecuteScalar();
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }
        }

        public int GetCompetitionIDFromRoundNumber(int roundNumber)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(CompetitionQueries.GetCompetitionIDFromRoundNumber(roundNumber), connection);
                connection.Open();
                try
                {
                    return (int)command.ExecuteScalar();
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }
        }

        public void InsertResult(int competition_id, int driver_id, int points, int position, bool fastest)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(CompetitionQueries.InsertResult(competition_id, driver_id, points, position, fastest), connection);
                connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }
        }

        public List<Driver> GetDriversInRace(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(CompetitionQueries.GetDriversInRace(id), connection);
                connection.Open();
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Driver> list = new List<Driver>();
                        while (reader.Read())
                        {
                            Driver d = new Driver();
                            d.ID = (int)reader["id"];
                            d.Name = (string)reader["name"];
                            d.SurName = (string)reader["surname"];
                            d.Nationality = GetNationality((int)reader["nationality_id"]);
                            d.TotalStarts = (int)reader["totalstarts"];
                            list.Add(d);
                        }
                        return list;
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }
        }

        public int GetRoundNumberFromCompetitionID(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(CompetitionQueries.GetRoundNumberFromCompetitionID(id), connection);
                connection.Open();
                try
                {
                    return (int)command.ExecuteScalar();
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }
        }

        public List<Result> GetResultsFromRace(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(CompetitionQueries.GetResultsFromRace(id), connection);
                connection.Open();
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Result> results = new List<Result>();
                        while (reader.Read())
                        {
                            Result r = new Result();
                            r.Driver = GetDriver((int)reader["driver_id"]);
                            r.Points = (int)reader["points"];
                            r.Position = (int)reader["position"];
                            results.Add(r);
                        }
                        return results;
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }
        }

        private Driver GetDriver(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(CompetitionQueries.GetDriver(id), connection);
                connection.Open();
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Driver d = new Driver();
                        while (reader.Read())
                        {
                            d.ID            = (int)reader["id"];
                            d.DriverNumber  = (int)reader["driverNumber"];
                            d.Name          = (string)reader["name"];
                            d.SurName       = (string)reader["surname"];
                            d.Nationality   = GetNationality((int)reader["nationality_id"]);
                            d.TotalStarts   = (int)reader["totalstarts"];
                            d.TotalPodiums  = (int)reader["totalpodiums"];
                            d.TotalWins     = (int)reader["totalwins"];
                            d.TotalPolepositions = (int)reader["totalpolepositions"];
                            d.TotalWDC      = (int)reader["totalwdc"];
                            d.TotalPoints   = (int)reader["totalpoints"];
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
    }
}
