using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Repositories.Queries
{
    public static class PredictionQueries
    {
        public static string Place(Prediction p)
        {
            return $"EXEC spPlacePrediction @competition_id = {p.Competition.ID}, @user_id = {p.User.ID}, @driver1_id = {p.Components[0].Driver_id}, @driver2_id = {p.Components[1].Driver_id}, @driver3_id = {p.Components[2].Driver_id}";
        }

        internal static string GetAllPredictions(User u)
        {
            return $"SELECT cp.competition_id, p.id AS prediction_id, p.name FROM Prediction p JOIN Competition_Prediction cp ON cp.prediction_id = p.id JOIN User_Prediction up ON up.prediction_id = p.id WHERE up.[user_id] = {u.ID}";
        }

        internal static string GetPredictionComponents(int prediction_id)
        {
            return $"SELECT pd.ID, driver_id, position FROM Prediction_Driver pd JOIN Prediction p ON p.id = pd.prediction_id WHERE p.id = {prediction_id}";
        }
    }
}
