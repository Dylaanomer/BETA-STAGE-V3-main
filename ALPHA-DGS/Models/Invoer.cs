using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;

namespace ALPHA_DGS.Models
{
    public class Invoer
    {


        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string Voornaam { get; set; }

        [StringLength(40)]
        public string Achternaam { get; set; }

        [StringLength(40)]
        public string Type { get; set; }

        public string Land { get; set; }

    }
}
