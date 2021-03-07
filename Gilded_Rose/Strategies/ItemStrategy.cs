using Gilded_Rose.Interfaces;
using Gilded_Rose.Interfaces.Behaviors;
using Gilded_Rose.Models;

namespace Gilded_Rose.Strategies
{
    public class ItemStrategy : IItemStrategy
    {
        private readonly IUpdateQualityBehavior _updateQualityBehaviour;
        private readonly IUpdateSellInBehavior _updateSellInBehaviour;

        public ItemStrategy(
            IUpdateQualityBehavior updateQualityBehaviour,
            IUpdateSellInBehavior updateSellInBehaviour)
        {
            _updateQualityBehaviour = updateQualityBehaviour;
            _updateSellInBehaviour = updateSellInBehaviour;
        }

        public int UpdateQuility(Item item)
        {
            return _updateQualityBehaviour.Execute(item);
        }

        public int UpdateSellIn(Item item)
        {
            return _updateSellInBehaviour.Execute(item);
        }
    }
}
