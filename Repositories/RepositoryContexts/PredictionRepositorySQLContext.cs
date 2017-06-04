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
