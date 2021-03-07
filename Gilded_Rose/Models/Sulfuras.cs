namespace Gilded_Rose.Models
{
    public class Sulfuras : ItemBase
    {
        public const int DefaultQuality = 80;

        public Sulfuras()
        {
            Quality = DefaultQuality;
        }

        public Sulfuras(string name) : base(name)
        {
            Quality = DefaultQuality;
        }
    }
}
