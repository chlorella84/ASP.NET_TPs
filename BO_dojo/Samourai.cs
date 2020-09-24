using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BO
{
    public class Samourai : EntityDb
    {
        public int Force { get; set; }
        [DisplayName("Weapon")]
        public virtual Arme Arme { get; set; }
        [DisplayName("Martial Arts")]
        public virtual List<ArtMartial> ArtMartials { get; set; }

        [NotMapped]
        private int potentiel;
        [NotMapped]
        public int Potentiel
        {
            get
            {
                if (this.Arme == null)
                {
                    potentiel = (this.Force) * (this.ArtMartials.Count() + 1);
                }
                else
                {
                    potentiel = (this.Force + this.Arme.Degats) * (this.ArtMartials.Count() + 1);
                }
                return potentiel;
            }
        }
    }
}
