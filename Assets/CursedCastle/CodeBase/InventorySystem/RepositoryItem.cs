using CursedCastle.CodeBase.Loot;

namespace CursedCastle.CodeBase.InventorySystem
{
    public class RepositoryItem : IItem
    {
        public LootTypeID LootTypeID { get; }

        public RepositoryItem(LootTypeID lootTypeID)
        {
            LootTypeID = lootTypeID;
        }
    }
}