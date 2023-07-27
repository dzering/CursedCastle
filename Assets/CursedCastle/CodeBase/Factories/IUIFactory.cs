using CursedCastle.CodeBase.Infrastructure;
using CursedCastle.CodeBase.InventorySystem;
using CursedCastle.CodeBase.UI.InventoryUI;
using UnityEngine;

namespace CursedCastle.CodeBase.Factories
{
    public interface IUIFactory : IService
    {
        GameObject CreateInventory(Inventory inventory);
        void CreateUiRoot();
        InventoryItemUI CreateInventoryItem(IItem item, Transform placeForItemUI);
        GameObject CreateHUD();
    }
}