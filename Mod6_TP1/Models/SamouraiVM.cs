using BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Mod6_TP1.Models
{
    public class SamouraiVM
    {
        public Samourai Samourai { get; set; }
        [DisplayName("Weapon")]
        public List<Arme> Armes { get; set; }
        [DisplayName("Weapon")]
        public int? IdSelectedArme { get; set; }

        [DisplayName("Martial Arts")]
        public List<ArtMartial> ArtsMartials { get; set; }
        [DisplayName("Martial Arts")]
        public List<int> IdSelectedArtsMartials { get; set; } = new List<int>();
    }
}