using UnityEngine;
using UnityEngine.Serialization;

namespace CursedCastle.CodeBase.InventorySystem
{
    public class InventoryUi : MonoBehaviour, IInventoryUi
    { 
        public Transform PlaceForItems;
        public InventoryItemUI SelectedItem { get; set; }
        
        public void SelectItem(InventoryItemUI itemUI) => 
            SelectedItem = itemUI;
        
        //Сделать кнопку отдельным компонентом и повесить на UI инвентаря. Кнопка выбросить и кнопка взять.
       // Кномка на старте получает из родителей компонент InventarUi. И далее манипулирует элементом selectedItem
    }
}
