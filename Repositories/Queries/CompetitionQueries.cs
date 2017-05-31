using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Queries
{
    static class CompetitionQueries
    {
        public static string GetCompetitions()
        {
            return $"SELECT id, race_or_quali, track_id, [datetime], [name], lapcount FROM Competition ORDER BY [datetime]";
        }

        public static string GetCompetition(int id)
        {
            return $"SELECT id, race_or_quali, track_id, [datetime], [name], lapcount FROM Competition WHERE id = {id}";
        }

        public static string GetCircuit(int id)
        {
            return $"SELECT id, [name], [location], nationality_id, [name], laprecord FROM Track WHERE id = {id}";
        }

        public static string GetNationality(int id)
        {
            return $"SELECT [id], [name], [imagepath] FROM Nationality WHERE id = {id}";
        }

        internal static string GetUpcomingCompetitions()
        {
            return $"SELECT id, race_or_quali, track_id, [datetime], [name], lapcount FROM Competition WHERE [datetime] > GETDATE() ORDER BY [datetime]";
        }

        internal static string GetDriverIDFromDriverNumber(int id)
        {
            return $"SELECT id FROM [Driver] WHERE driverNumber = {id}";
        }

        internal static string GetCompetitionIDFromRoundNumber(int roundNumber)
        {
            return $"SELECT id FROM [Competition] WHERE [roundNumber] = {roundNumber}";
        }

        internal static string InsertResult(int competition_id, int driver_id, int points, int position, bool fastest)
        {
            return $"INSERT INTO Competition_Driver (driver_id, competition_id, points, position, fastest) VALUES ({driver_id}, {competition_id}, {points}, {position}, 0)";
        }

        internal static string GetPastCompetitions()
        {
            return $"SELECT id, race_or_quali, track_id, [datetime], [name], lapcount FROM Competition WHERE[datetime] < GETDATE() ORDER BY[datetime]";
        }

        internal static string GetDriversInRace(int id)
        {
            return $"";
        }

        internal static string GetRoundNumberFromCompetitionID(int id)
        {
            return $"SELECT [roundNumber] FROM [Competition] WHERE [id] = {id}";
        }

        internal static string GetResultsFromRace(int id)
        {
            return $"SELECT * FROM Competition_Driver WHERE competition_id = {id}";
        }

        internal static string GetDriver(int id)
        {
            return $"SELECT * FROM [Driver] WHERE id = {id}";
        }

        internal static string GetDrivers()
        {
            return $"SELECT * FROM [Driver]";
        }
    }
}
