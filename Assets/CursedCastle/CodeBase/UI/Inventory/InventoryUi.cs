using UnityEngine;

namespace CursedCastle.CodeBase.UI.Inventory
{
    public class InventoryUi : MonoBehaviour, IInventoryUi      
    { 
        public Transform PlaceForItems;
        public InventoryItemUI SelectedItem { get; set; }
        
        public void SelectItem(InventoryItemUI itemUI) => 
            SelectedItem = itemUI;
    }
}
