using System.Collections.Generic;
using CursedCastle.CodeBase.Factories;
using CursedCastle.CodeBase.InventorySystem;
using UnityEngine;

namespace CursedCastle.CodeBase.UI.InventoryUI
{
    public class InventoryUi : MonoBehaviour, IInventoryUi
    {
        public List<InventoryItemUI> _items = new List<InventoryItemUI>();
        public Transform PlaceForItems;
        private Inventory _inventory;
        private IUIFactory _uiFactory;
        public InventoryItemUI SelectedItem { get; set; }

        public void Construct(Inventory inventory, IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
            _inventory = inventory;
        }

        public void AddItem(InventoryItemUI itemUI)
        {
            itemUI.OnSelect += SelectItem;
            itemUI.OnDeselect += DeselectItem;
            _items.Add(itemUI);
        }

        public void SelectItem(InventoryItemUI itemUI)
        {
            DeselectItems();
            SelectedItem = itemUI;
            
            _inventory.SelectedItem = itemUI.Item;
            _inventory.UseItem(itemUI.Item);
        }

        private void DeselectItem(InventoryItemUI itemUI)
        {
            SelectedItem = null;
            
            _inventory.SelectedItem = null;
            _inventory.CancelUseItem();
        }

        public void RemoveItem(InventoryItemUI itemUI)
        {
            itemUI.OnSelect -= SelectItem;
            itemUI.OnDeselect -= DeselectItem;
            _items.Remove(itemUI);
            Destroy(itemUI);
        }

        private void DeselectItems()
        {
            foreach (InventoryItemUI item in _items) 
                item.DeselectItem();
        }

        public void UpdateUI(IInventoryRepository repository)
        {
            DestroyAll();
            CreateAll(repository.Items);
        }

        private void CreateAll(IEnumerable<IItem> repository)
        {
            foreach (var item in repository)
            {
                InventoryItemUI itemUI = _uiFactory.CreateInventoryItem(item, PlaceForItems);
                itemUI.OnSelect += SelectItem;
                itemUI.OnDeselect += DeselectItem;
                _items.Add(itemUI);
            }
        }

        private void DestroyAll()
        {
            foreach (InventoryItemUI itemUI in _items)
            {
                itemUI.OnSelect -= SelectItem;
                itemUI.OnDeselect -= DeselectItem;
                Destroy(itemUI.gameObject);
            }
        }
    }
}
