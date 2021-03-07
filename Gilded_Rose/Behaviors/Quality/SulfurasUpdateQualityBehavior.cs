using Gilded_Rose.Interfaces.Behaviors;
using Gilded_Rose.Models;

namespace Gilded_Rose.Behaviors.Quality
{
    public class SulfurasUpdateQualityBehavior : IUpdateQualityBehavior
    {
        public int Execute(Item item)
        {
            return Sulfuras.DefaultQuality;
        }
    }
}
