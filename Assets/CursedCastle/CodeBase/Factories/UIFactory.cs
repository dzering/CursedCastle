using CursedCastle.CodeBase.InventorySystem;
using CursedCastle.CodeBase.StaticData;
using CursedCastle.CodeBase.UI.Inventory;
using UnityEngine;

namespace CursedCastle.CodeBase.Factories
{
    public class UIFactory : IUIFactory
    {
        private readonly IStaticDataService _staticDataService;
        private Transform _uiRoot;
        private const string UI_HUD = "UI/HUD";
        private const string INVENTORY_PATH = "UI/Inventory";
        private const string UI_ROOT_PATH = "UI/UiRoot";
        private const string ITEM_PATH = "UI/Item";

        public UIFactory(IStaticDataService staticDataService) => 
            _staticDataService = staticDataService;

        public void CreateUiRoot()
        {
            GameObject uiRootPref = Resources.Load<GameObject>(UI_ROOT_PATH);
            _uiRoot = Object.Instantiate(uiRootPref, _uiRoot).transform;
        }

        public GameObject CreateHUD()
        {
            GameObject uiHUDPref = Resources.Load<GameObject>(UI_HUD);
            return Object.Instantiate(uiHUDPref);
           
        }

        public void CreateInventoryItem(IItem item, InventoryUi inventoryUi)
        {
            LootStaticData loot = _staticDataService.ForLoot(item.LootTypeID);
            GameObject itemPref = Resources.Load<GameObject>(ITEM_PATH);
            GameObject instantiate = Object.Instantiate(itemPref, inventoryUi.PlaceForItems);
            InventoryItemUI inventoryItemUI = instantiate.GetComponentInParent<InventoryItemUI>();
            inventoryItemUI.Construct(item, loot.Sprite, inventoryUi);
        }
        
        public GameObject CreateInventory(InventoryService inventoryService)
        {
            GameObject inventoryPref = Resources.Load<GameObject>(INVENTORY_PATH);
            GameObject inventoryGo = Object.Instantiate(inventoryPref, _uiRoot);

            DropButton dropButton = inventoryGo.GetComponentInChildren<DropButton>();
            dropButton.Construct(inventoryService);

            UseButton useButton = inventoryGo.GetComponentInChildren<UseButton>();
            useButton.Construct(inventoryService);
            
            return inventoryGo;
        }
    }
}