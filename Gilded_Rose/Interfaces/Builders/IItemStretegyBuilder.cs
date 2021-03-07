using Gilded_Rose.Models;

namespace Gilded_Rose.Interfaces.Builders
{
    public interface IItemStretegyBuilder
    {
        IItemStrategy Build(Item item);
    }
}
