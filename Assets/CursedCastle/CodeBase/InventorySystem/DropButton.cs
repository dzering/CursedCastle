using UnityEngine;
using UnityEngine.UI;

namespace CursedCastle.CodeBase.InventorySystem
{
    public class DropButton : MonoBehaviour
    {
        [SerializeField] private Button useButton;
        private InventoryService _inventoryService;

        public void Construct(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
            OnAwake();
        }

        private void OnAwake() => 
            useButton.onClick.AddListener(UseItem);

        private void UseItem() => 
            _inventoryService.UseItem();
    }
}