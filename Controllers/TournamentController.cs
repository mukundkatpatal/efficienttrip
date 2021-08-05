using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class TournamentController : Controller
    {
        private readonly IConfiguration _configuration;
        public TournamentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("TournamentAppCon"));

            var dbList = dbClient.GetDatabase("Tournament").GetCollection<Tournament>("TournamentDetails").AsQueryable();

            return new JsonResult(dbList);
        }
        [HttpPost]

        public JsonResult Post([FromBody] Tournament tou)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("TournamentAppCon"));

            int LastTournamentId = dbClient.GetDatabase("Tournament").GetCollection<Tournament>("TournamentDetails").AsQueryable().Count();
            tou.TournamentId = LastTournamentId + 1;

            dbClient.GetDatabase("Tournament").GetCollection<Tournament>("TournamentDetails").InsertOne(tou);

            return new JsonResult("Added Successfully");
        }


        [HttpPut]
        public JsonResult Put([FromBody] Tournament tou)
        {

            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("TournamentAppCon"));

            var filter = Builders<Tournament>.Filter.Eq("TournamentId", tou.TournamentId);

            var update = Builders<Tournament>.Update.Set("TournamentName", tou.TournamentName)
                                                     .Set("Place", tou.Place)
                                                     .Set("StartDate", tou.StartDate)
                                                     .Set("EndDate", tou.EndDate)
                                                     .Set("Rounds", tou.Rounds)
                                                     .Set("Category", tou.Category)
                                                     .Set("Website", tou.Website);



            dbClient.GetDatabase("Tournament").GetCollection<Tournament>("TournamentDetails").UpdateOne(filter, update);


            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("TournamentAppCon"));

            var filter = Builders<Tournament>.Filter.Eq("TournamentId", id);


            dbClient.GetDatabase("Tournament").GetCollection<Tournament>("TournamentDetails").DeleteOne(filter);

            return new JsonResult("Deleted Successfully");
        }


    }
}
