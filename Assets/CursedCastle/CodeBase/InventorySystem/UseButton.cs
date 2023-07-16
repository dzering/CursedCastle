using UnityEngine;
using UnityEngine.UI;

namespace CursedCastle.CodeBase.InventorySystem
{
    public class UseButton : MonoBehaviour
    {
        [SerializeField] private Button _useButton;
        private InventoryService _inventoryService;

        public void Construct(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
            OnAwake();
        }

        private void OnAwake() => 
            _useButton.onClick.AddListener(UseItem);
        
        private void UseItem() => 
            _inventoryService.UseItem();
    }
}