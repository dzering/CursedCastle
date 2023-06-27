using CursedCastle.CodeBase.Infrastructure;
using CursedCastle.CodeBase.Loot;
using UnityEngine;

namespace CursedCastle.CodeBase.Factories
{
    public interface IUIFactory : IService
    {
        GameObject CreateInventory();
        void CreateUiRoot();
        void CreateInventoryItem(LootTypeID lootTypeID, Transform placeFor);
    }
}