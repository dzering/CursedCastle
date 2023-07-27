using UnityEngine;
using UnityEngine.UI;

namespace CursedCastle.CodeBase.InventorySystem
{
    public class CloseButton : MonoBehaviour
    {
        [SerializeField] private Button closeButton;
        private Inventory _inventory;

        public void Construct(Inventory inventory)
        {
            _inventory = inventory;
            OnAwake();
        }

        private void OnAwake() => 
            closeButton.onClick.AddListener(Close);

        private void Close() => 
            _inventory.Close();
    }
}