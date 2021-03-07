using Gilded_Rose.Models;

namespace Gilded_Rose.Interfaces.Builders
{
    public interface IItemFactory
    {
        public Item Create(string name);
    }
}
