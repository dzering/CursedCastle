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

        public void CreateInventoryItem(LootTypeID lootTypeID, InventoryUi inventoryUi)
        {
            LootStaticData loot = _staticDataService.ForLoot(lootTypeID);
            GameObject itemPref = Resources.Load<GameObject>(ITEM_PATH);
            GameObject item = GameObject.Instantiate(itemPref, inventoryUi.PlaceForItems);
            InventoryItemUI inventoryItemUI = item.GetComponentInParent<InventoryItemUI>();
            inventoryItemUI.Construct(loot.LootID, loot.Sprite, inventoryUi);
        }
        

        public GameObject CreateInventory(InventoryService inventoryService)
        {
            GameObject inventoryPref = Resources.Load<GameObject>(INVENTORY_PATH);
            GameObject inventoryGO = Object.Instantiate(inventoryPref, _uiRoot);

            DropButton dropButton = inventoryGO.GetComponentInChildren<DropButton>();
            dropButton.Construct(inventoryService);
            
            return inventoryGO;
        }
    }
}