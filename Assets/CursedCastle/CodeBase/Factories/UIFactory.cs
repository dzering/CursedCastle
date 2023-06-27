using CursedCastle.CodeBase.InventorySystem;
using CursedCastle.CodeBase.Loot;
using CursedCastle.CodeBase.StaticData;
using UnityEngine;

namespace CursedCastle.CodeBase.Factories
{
    public class UIFactory : IUIFactory
    {
        private readonly IStaticDataService _staticDataService;
        private Transform _uiRoot;
        private const string INVENTORY_PATH = "UI/Inventory";
        private const string UI_ROOT_PATH = "UI/UiRoot";
        private const string ITEM_PATH = "UI/Item";

        public UIFactory(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public void CreateUiRoot()
        {
            GameObject uiRootPref = Resources.Load<GameObject>(UI_ROOT_PATH);
            _uiRoot = Object.Instantiate(uiRootPref).transform;
        }

        public void CreateInventoryItem(LootTypeID lootTypeID, Transform placeFor)
        {
            LootStaticData loot = _staticDataService.ForLoot(lootTypeID);
            GameObject itemPref = Resources.Load<GameObject>(ITEM_PATH);
            GameObject item = GameObject.Instantiate(itemPref, placeFor);
            InventoryItem inventoryItem = item.GetComponent<InventoryItem>();
            inventoryItem.Construct(loot.LootID, loot.Sprite);
        }
        

        public GameObject CreateInventory()
        {
            GameObject inventory = Resources.Load<GameObject>(INVENTORY_PATH);
            return Object.Instantiate(inventory, _uiRoot);
        }
    }
}