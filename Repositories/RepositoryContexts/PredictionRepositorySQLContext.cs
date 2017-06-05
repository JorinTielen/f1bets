using System;
using System.Collections.Generic;
using System.Text;
using Models;
using System.Data.SqlClient;
using Repositories.Queries;

namespace Repositories.RepositoryContexts
{
    public class PredictionRepositorySQLContext : IPredictionRepositoryContext
    {
        private static readonly string connectionString = @"Server= 192.168.19.12;Persist Security Info=False;User ID=frietpan;Password=frietpan;Database=f1bets_dev;";

        public List<Prediction> GetAllPredictions(User u)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(PredictionQueries.GetAllPredictions(u), connection);
                connection.Open();
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        CompetitionRepository compRepo = new CompetitionRepository(new CompetitionRepositorySQLContext());
                        List<Prediction> list = new List<Prediction>();
                        while (reader.Read())
                        {
                            Prediction p = new Prediction();
                            p.ID = (int)reader["prediction_id"];
                            p.Name = (string)reader["name"];

                            p.User = u;
                            p.Competition = compRepo.GetCompetition((int)reader["competition_id"]);
                            p.Components = GetPredictionComponents(p.ID);

                            p.Checked = false;
                            foreach (var component in p.Components)
                            {
                                if (component.Checked == true)
                                {
                                    p.Points = (int)reader["points"];
                                    p.Checked = true;
                                }
                            }

                            list.Add(p);
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

        private List<PredictionComponent> GetPredictionComponents(int prediction_id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(PredictionQueries.GetPredictionComponents(prediction_id), connection);
                connection.Open();
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        CompetitionRepository compRepo = new CompetitionRepository(new CompetitionRepositorySQLContext());
                        List<PredictionComponent> list = new List<PredictionComponent>();
                        while (reader.Read())
                        {
                            PredictionComponent pc = new PredictionComponent();
                            pc.ID = (int)reader["ID"];
                            pc.Driver_id = (int)reader["driver_id"];
                            pc.Driver = compRepo.GetDriver(pc.Driver_id);
                            pc.Position = (int)reader["position"];
                            pc.Checked = (bool)reader["checked"];

                            if (pc.Checked)
                            {
                                pc.Correct = (bool)reader["correct"];
                            }

                            list.Add(pc);
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

        public void Place(Prediction p)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(PredictionQueries.Place(p), connection);
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
