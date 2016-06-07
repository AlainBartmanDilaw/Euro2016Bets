using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Euro2016.Models
{
    public class Entity
    {
        public int Idt { get; set; }
    }

    public class Team : Entity
    {
        public string Name { get; set; }
        public string Flag { get; set; }
        public string Score { get; set; }
    }

    public class MatchResult : Entity
    {
        public int Number { get; set; }
        public string Group { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string Phase { get; set; }
        public string Stade { get; set; }
        public string Town { get; set; }
        public Team Home { get; set; }
        public Team Away { get; set; }
    }

}