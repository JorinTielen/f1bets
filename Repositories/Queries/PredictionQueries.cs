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
    }
}
