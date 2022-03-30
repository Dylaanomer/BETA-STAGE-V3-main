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

        public int PserId { get; set; }
        [ForeignKey("PserId")]

        public Partijserie Partijserie { get; set; }

        public int Pvan { get; set; }

        public int Ptot { get; set; }

        [StringLength(50)]
        public string PHerk { get; set; }

        [ForeignKey("MagazijnId")]
        public Magazijn Magazijn { get; set; }

        [InverseProperty("MagazijnPartij")]
        public List<Magazijn> Magazijns { get; set; }

        public int MagazijnId { get; set; }


        [StringLength(50)]
        public string VpNaam { get; set; }

        public Stadium Stadium { get; set; }

        public int StadiumId { get; set; }

        public bool Uitserie { get; set; }

        public int AantFust { get; set; }

        [StringLength(20)]
        public string Naam { get; set; }
    }
}
