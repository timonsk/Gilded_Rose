namespace Gilded_Rose.Models
{
    public abstract class ItemBase : Item
    {
        public ItemBase()
        {
        }

        public ItemBase(string name)
        {
            Name = name;
        }
    }
}
