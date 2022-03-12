using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ALPHA_DGS.Models
{
    public class VakItem
    {


        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Naam { get; set; }

        [StringLength(40)]
        public string Type { get; set; }

        public string Land { get; set; }

        public int InvoerId { get; set; }

        public Invoer Invoer { get; set; }

        public int RijId { get; set; }

        public Rij Rij { get; set; }

        public Rij2 Rij2 { get; set; }

        public Rij3 Rij3 { get; set; }

        public Rij4 Rij4 { get; set; }

        public Rij5 Rij5 { get; set; }

        public Rij6 Rij6 { get; set; }

        public Rij7 Rij7 { get; set; }



        public int RijSetId { get; set; }

        public RijSet RijSet { get; set; }

        public int AfdelingId { get; set; }

        public Afdeling Afdeling { get; set; }





    }
}
