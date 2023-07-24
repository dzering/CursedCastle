using CursedCastle.CodeBase.Loot;

namespace CursedCastle.CodeBase.InventorySystem
{
    public interface IItem
    {
        LootTypeID LootTypeID { get; }
        bool IsSelected { get; set; }
        bool ItTaken { get; set; }
    }
}