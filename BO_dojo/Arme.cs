using System.ComponentModel;

namespace BO
{
    public class Arme : EntityDb
    {
        [DisplayName("Damages")]
        public int Degats { get; set; }
    }
}