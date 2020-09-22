using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mod6_TP1.Models
{
    public class SamouraiVM
    {
        public Samourai Samourai { get; set; }
        public List<Arme> Armes { get; set; }
        public int? IdSelectedArme { get; set; }
        public List<ArtMartial> ArtsMartials { get; set; }
        public List<int> IdSelectedArtsMartials { get; set; }
    }
}