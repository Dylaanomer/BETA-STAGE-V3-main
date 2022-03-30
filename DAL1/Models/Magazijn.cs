using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ALPHA_DGS.Models
{
    public class Magazijn
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Instructor")]
        public int ParentMloId { get; set; }

        public int LokatieType { get; set; }

        [StringLength(50)]
        public string Naam { get; set; }

        [ForeignKey("MagazijnPartijId")]
        public MagazijnPartij MagazijnPartij { get; set; }

        public int Sequence { get; set; }

        public bool Bezet { get; set; }

        public int MaxAanFust { get; set; }

        [InverseProperty("MagazijnPartij")]
        public List<MagazijnPartij> MagazijnPartijsLijst { get; set; }

    }
}
