using Gilded_Rose.Models;

namespace Gilded_Rose.Interfaces
{
    public interface IItemStrategy
    {
        public int UpdateQuility(Item item);

        public int UpdateSellIn(Item item);
    }
}
