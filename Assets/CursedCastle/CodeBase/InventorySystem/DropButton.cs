using UnityEngine;
using UnityEngine.UI;

namespace CursedCastle.CodeBase.InventorySystem
{
    public class DropButton : MonoBehaviour
    {
        [SerializeField] private Button _dropButton;
        private InventoryService _inventoryService;

        public void Construct(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
            OnAwake();
        }

        private void OnAwake() => 
            _dropButton.onClick.AddListener(_inventoryService.RemoveItem);
    }
}