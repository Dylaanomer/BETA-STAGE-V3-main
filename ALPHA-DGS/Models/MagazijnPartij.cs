using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ALPHA_DGS.Models
{
    public class MagazijnPartij
    {
        [Key]
        public int Id { get; set; }

        public int Pvan { get; set; }

        public int Ptot { get; set; }

        [StringLength(50)]
        public string PHerk { get; set; }

        [ForeignKey("Stadium")]
        public int Pstadid { get; set; }

        [StringLength(50)]
        public string VpNaam { get; set; }

        [ForeignKey("Magazijn")]
        public int MlokId { get; set; }

        public bool Uitserie { get; set; }

        public int AantFust { get; set; }

        [StringLength(20)]
        public string Naam { get; set; }
    }
}
