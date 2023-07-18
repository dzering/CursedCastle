using UnityEngine;
using UnityEngine.UI;

namespace CursedCastle.CodeBase.InventorySystem
{
    public class DropButton : MonoBehaviour
    {
        [SerializeField] private Button dropbutton;
        private InventoryService _inventoryService;

        public void Construct(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
            OnAwake();
        }

        private void OnAwake() => 
            dropbutton.onClick.AddListener(RemoveItem);
        
        private void RemoveItem() => 
            _inventoryService.DropItem();
    }
}