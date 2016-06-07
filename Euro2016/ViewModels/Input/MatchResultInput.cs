using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Euro2016.Models;

namespace Euro2016.ViewModels.Input
{
    public class MatchResultInput
    {
        public int? Idt { get; set; }

        [Required]
        public int Number { get; set; }

        public string Group { get; set; }
        [Required]
        public DateTime ScheduleDate { get; set; }
        [Required]
        public string Phase { get; set; }
        [Required]
        public string Stade { get; set; }
        [Required]
        public string Town { get; set; }
        [Required]
        public Team Home { get; set; }
        [Required]
        public Team Away { get; set; }

    }

}