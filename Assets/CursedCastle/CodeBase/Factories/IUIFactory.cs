using CursedCastle.CodeBase.Infrastructure;
using CursedCastle.CodeBase.InventorySystem;
using CursedCastle.CodeBase.Loot;
using UnityEngine;

namespace CursedCastle.CodeBase.Factories
{
    public interface IUIFactory : IService
    {
        GameObject CreateInventory(InventoryService inventoryService);
        void CreateUiRoot();
        void CreateInventoryItem(LootTypeID lootTypeID, InventoryUi inventoryUi);
    }
}