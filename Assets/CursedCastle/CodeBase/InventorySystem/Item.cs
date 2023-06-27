using CursedCastle.CodeBase.Loot;
using UnityEngine;

namespace CursedCastle.CodeBase.InventorySystem
{
    public class Item : IItem
    {
        public LootTypeID LootTypeID { get; }

        public Item(LootTypeID lootTypeID)
        {
            LootTypeID = lootTypeID;
        }
    }
}