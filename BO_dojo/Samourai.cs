namespace BO
{
    public class Samourai : EntityDb
    {
        public int Force { get; set; }
        public virtual Arme Arme { get; set; }

        public virtual ArtMartial ArtMartial { get; set; }
    }
}
