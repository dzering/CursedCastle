using CursedCastle.CodeBase.Loot;

namespace CursedCastle.CodeBase.InventorySystem
{
    public interface IItem
    {
        LootTypeID LootTypeID { get; }
    }
}