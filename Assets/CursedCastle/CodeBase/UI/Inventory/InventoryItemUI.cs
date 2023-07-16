using CursedCastle.CodeBase.InventorySystem;
using UnityEngine;
using UnityEngine.UI;

namespace CursedCastle.CodeBase.UI.Inventory
{
    public class InventoryItemUI : MonoBehaviour
    {
        [HideInInspector] public IItem Item; 
        [SerializeField] private Image _image;
        [SerializeField] private Button _selectButton;
        private InventoryUi _inventoryUi;

        public void Construct(IItem item, Sprite sprite, InventoryUi inventoryUi)
        {
            Item = item;
            _image.sprite = sprite;
            _inventoryUi = inventoryUi;
        }

        private void Start() => 
            _selectButton.onClick.AddListener(ButtonAction);

        private void ButtonAction() => 
            _inventoryUi.SelectItem(this);

        private void OnDestroy() => 
            _selectButton.onClick.RemoveAllListeners();
    }
}
