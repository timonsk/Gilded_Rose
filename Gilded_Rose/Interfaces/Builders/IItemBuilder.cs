using Gilded_Rose.Models;

namespace Gilded_Rose.Interfaces.Builders
{
    public interface IItemBuilder
    {
        Item Build(string name, int sellIn, int quality);
    }
}
