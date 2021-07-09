using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETGolfAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPNETGolfAPI.Controllers
{
    public class RankingController : Controller
    {
        private readonly Irankingrepos repo;
        // GET: /<controller>/
        public IActionResult Index()

        {

             //var client = new RestClient("https://golf-leaderboard-data.p.rapidapi.com/world-rankings");
            var client = new RestClient("https://golf-leaderboard-data.p.rapidapi.com/tour-rankings/2/2021");

 
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", "ad097d5c45mshbc13e25e0f79185p1231e3jsn175260ba160d");
            request.AddHeader("x-rapidapi-host", "golf-leaderboard-data.p.rapidapi.com");
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);
            var golfRankings = JsonConvert.DeserializeObject<Root>(response.Content);

            var topFifty = golfRankings.results.rankings.OrderByDescending(x => x.num_wins).Take(50);

           

            return View(topFifty);
        }
    }
}
