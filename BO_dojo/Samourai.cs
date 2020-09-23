using System.Collections.Generic;

namespace BO
{
    public class Samourai : EntityDb
    {
        public int Force { get; set; }
        public virtual Arme Arme { get; set; }

        public virtual List<ArtMartial> ArtMartials { get; set; }
    }
}
