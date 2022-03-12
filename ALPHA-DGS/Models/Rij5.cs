using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;

namespace ALPHA_DGS.Models
{
    public class Rij5
    {


        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string Naam { get; set; }

    }
}
