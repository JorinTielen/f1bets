using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using Models;
using Repositories.RepositoryContexts;
using System.Net.Http;
using System.Threading.Tasks;

namespace Repositories.API
{
    public class API
    {
        RootObject obj;
        CompetitionRepository repo = new CompetitionRepository(new CompetitionRepositorySQLContext());

        private void ReadJsonFromFile(string path)
        {
            using (StreamReader file = File.OpenText(path))
            {
                string json = file.ReadToEnd();
                obj = JsonConvert.DeserializeObject<RootObject>(json);
            }
        }

        public void GetRaceResultsFromApi(int roundNumber)
        {
            string json;
            try
            {
                using (HttpClient hc = new HttpClient())
                {
                    string url = "http://ergast.com/api/f1/2017/" + roundNumber + "/results.json";
                    if (!url.Contains("Circuit"))
                    {
                        //de api is nog niet geupdate met de resultaten
                        return;
                    }
                    json = hc.GetStringAsync(url).Result;
                    obj = JsonConvert.DeserializeObject<RootObject>(json);
                }
            }
            catch (Exception)
            {
                //the api is offline
                return;
            }

            foreach (Race race in obj.MRData.RaceTable.Races)
            {
                if (Convert.ToInt32(race.round) == roundNumber)
                {
                    foreach (Result result in race.Results)
                    {

                        int driver_id = repo.GetDriverIDFromDriverNumber(Convert.ToInt32(result.Driver.permanentNumber));
                        int competition_id = repo.GetCompetitionIDFromRoundNumber(Convert.ToInt32(race.round));
                        int position = Convert.ToInt32(result.position);
                        int points = Convert.ToInt32(result.points);
                        bool fastest = false;

                        repo.InsertResult(competition_id, driver_id, points, position, fastest);
                    }
                }
            }
        }
    }
}
