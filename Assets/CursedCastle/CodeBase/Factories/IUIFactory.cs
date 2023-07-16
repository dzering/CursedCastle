using CursedCastle.CodeBase.Infrastructure;
using CursedCastle.CodeBase.InventorySystem;
using CursedCastle.CodeBase.UI.Inventory;
using UnityEngine;

namespace CursedCastle.CodeBase.Factories
{
    public interface IUIFactory : IService
    {
        GameObject CreateInventory(InventoryService inventoryService);
        void CreateUiRoot();
        void CreateInventoryItem(IItem item, InventoryUi inventoryUi);
        GameObject CreateHUD();
    }
}