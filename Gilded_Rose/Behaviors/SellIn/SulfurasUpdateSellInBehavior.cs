using Gilded_Rose.Interfaces.Behaviors;
using Gilded_Rose.Models;

namespace Gilded_Rose.Behaviors.SellIn
{
    public class SulfurasUpdateSellInBehavior : IUpdateSellInBehavior
    {
        public int Execute(Item item)
        {
            return item.SellIn;
        }
    }
}
