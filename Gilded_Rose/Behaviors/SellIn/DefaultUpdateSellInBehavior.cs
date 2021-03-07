using Gilded_Rose.Constants;
using Gilded_Rose.Interfaces.Behaviors;
using Gilded_Rose.Models;

namespace Gilded_Rose.Behaviors.SellIn
{
    public class DefaultUpdateSellInBehavior : IUpdateSellInBehavior
    {
        public int Execute(Item item)
        {
            return item.SellIn - ItemConstant.DefaultIteratorValue;
        }
    }
}
