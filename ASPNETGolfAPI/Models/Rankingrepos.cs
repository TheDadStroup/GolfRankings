using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RestSharp;

namespace ASPNETGolfAPI.Models
{
    public class Rankingrepos : Irankingrepos
    {
        public Rankingrepos()
        {
        }

        public IEnumerable<Ranking> GetAllRankings()
        {
            var client = new RestClient("https://golf-leaderboard-data.p.rapidapi.com/world-rankings");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", "ad097d5c45mshbc13e25e0f79185p1231e3jsn175260ba160d");
            request.AddHeader("x-rapidapi-host", "golf-leaderboard-data.p.rapidapi.com");
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);
            var golfRankings = JsonConvert.DeserializeObject<Root>(response.Content);

            var topFifty = golfRankings.results.rankings.OrderByDescending(x => x.num_wins).Take(50);

            var ranking = new Ranking();
            var ranking2 = new Ranking();

           
           return topFifty;

            //foreach (var player in topFifty)
            //{
            //    Console.WriteLine("..................");
            //    Console.WriteLine($"{player.position} {player.player_name} ");

            //}
        }
    }
}
