using UnityEngine;
using UnityEngine.UI;

namespace CursedCastle.CodeBase.InventorySystem
{
    public class CloseButton : MonoBehaviour
    {
        [SerializeField] private Button closeButton;
        private InventoryService _inventoryService;

        public void Construct(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
            OnAwake();
        }

        private void OnAwake() => 
            closeButton.onClick.AddListener(Close);

        private void Close() => 
            _inventoryService.Close();
    }
}