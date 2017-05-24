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
        private static readonly string connectionString = @"Server= DESKTOP-FB2QFPO;Database=f1bets;Trusted_Connection=True;";

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
                            c.Country = GetNationality((int)reader["nationality_id"]);
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

        public string GetNationality(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(CompetitionQueries.GetNationality(id), connection);
                connection.Open();
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return (string)reader["name"];
                        }
                    }
                    return "";
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
    }
}
