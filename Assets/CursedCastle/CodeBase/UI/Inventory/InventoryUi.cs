using System.Collections.Generic;
using UnityEngine;

namespace CursedCastle.CodeBase.UI.Inventory
{
    public class InventoryUi : MonoBehaviour, IInventoryUi
    {
        public List<InventoryItemUI> _items = new List<InventoryItemUI>();
        public Transform PlaceForItems;
        public InventoryItemUI SelectedItem { get; set; }
        
        public void SelectItem(InventoryItemUI itemUI) => 
            SelectedItem = itemUI;

        public void DeselectItems()
        {
            foreach (InventoryItemUI item in _items) 
                item.DeselectItem();
        }

        public void AddItem(InventoryItemUI inventoryItemUI) => 
            _items.Add(inventoryItemUI);

        public void RemoveItem(InventoryItemUI itemUI)
        {
            _items.Remove(itemUI);
        }
    }
}
