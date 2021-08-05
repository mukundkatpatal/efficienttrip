using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace WebApplication1.Models
{
    public class Tournament
    {
        public ObjectId Id { get; set; }

        public int TournamentId { get; set; }

        public string TournamentName { get; set; }

        public string Place { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public int Rounds { get; set; }

        public string Category { get; set; }

        public string Website { get; set; }
    }
}
