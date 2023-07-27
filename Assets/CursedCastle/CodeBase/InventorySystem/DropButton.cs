using UnityEngine;
using UnityEngine.UI;

namespace CursedCastle.CodeBase.InventorySystem
{
    public class DropButton : MonoBehaviour
    {
        [SerializeField] private Button dropbutton;
        private Inventory _inventory;

        public void Construct(Inventory inventory)
        {
            _inventory = inventory;
            OnAwake();
        }

        private void OnAwake() => 
            dropbutton.onClick.AddListener(RemoveItem);
        
        private void RemoveItem() => 
            _inventory.RemoveItem();
    }
}