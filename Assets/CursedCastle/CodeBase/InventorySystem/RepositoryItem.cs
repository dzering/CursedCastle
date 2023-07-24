using CursedCastle.CodeBase.Loot;

namespace CursedCastle.CodeBase.InventorySystem
{
    public class RepositoryItem : IItem
    {
        public LootTypeID LootTypeID { get; }
        public bool IsSelected { get; set; }
        public bool ItTaken { get; set; }

        public RepositoryItem(LootTypeID lootTypeID)
        {
            LootTypeID = lootTypeID;
        }
    }
}