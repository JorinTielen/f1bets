using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Queries
{
    public static class F1Queries
    {
        public static string GetDriver(int? id)
        {
            return $"SELECT * FROM [Driver] WHERE id = {(int)id}";
        }

        public static string GetNationality(int id)
        {
            return $"SELECT [id], [name], [imagepath] FROM Nationality WHERE id = {id}";
        }

        internal static string GetTeams()
        {
            return $"SELECT t.id, t.[name], t.[chassis], t.[nationality_id], t.totalpodiums, t.totalpoints, t.totalwcc, t.totalwins FROM Team t";
        }

        internal static string GetDriversFromTeam(int id)
        {
            return $"SELECT * FROM [Driver] d JOIN Driver_Team dt ON dt.driver_id = d.id WHERE dt.team_id = {id}";
        }

        internal static string GetTeam(int? id)
        {
            return $"SELECT t.id, t.[name], t.[chassis], t.[nationality_id], t.totalpodiums, t.totalpoints, t.totalwcc, t.totalwins FROM Team t WHERE t.id = {(int)id}";
        }
    }
}
