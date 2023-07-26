using CursedCastle.CodeBase.InventorySystem;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace CursedCastle.CodeBase.UI.Inventory
{
    public class InventoryItemUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public IItem Item;
        [SerializeField] private Image _background;
        [SerializeField] private Image _itemImage;
        [SerializeField] private Image _hovered;

        [SerializeField] private Color _defaultColor;

        [SerializeField] private Color _selectedColor;

        private InventoryUi _inventoryUi;
        private InventoryService _service;

        public void Construct(IItem item, Sprite sprite, InventoryUi inventoryUi, InventoryService service)
        {
            Item = item;
            _itemImage.sprite = sprite;
            _inventoryUi = inventoryUi;
            _service = service;

            CheckSelection();
        }

        public void OnPointerEnter(PointerEventData eventData) => 
            _hovered.gameObject.SetActive(true);

        public void OnPointerExit(PointerEventData eventData) => 
            _hovered.gameObject.SetActive(false);

        public void OnPointerClick(PointerEventData eventData) => 
            SelectItem();

        private void CheckSelection()
        {
            _hovered.gameObject.SetActive(false);
            _background.color = _defaultColor;
            
            if (Item.IsSelected)
                _background.color = _selectedColor;
        }

        private void SelectItem()
        {
            if (Item.IsSelected)
            {
                DeselectItem();
                return;
            }
            
            _inventoryUi.DeselectItems();
            _service.SelectedItem = Item;
            _service.UseItem(Item);
            SetBackgroundColor(_selectedColor);
            Item.IsSelected = true;
        }

        public void DeselectItem()
        {
            Item.IsSelected = false;
            SetBackgroundColor(_defaultColor);
            _service.SelectedItem = null;
            _service.UnUseItem();
        }

        private void SetBackgroundColor(Color color) => 
            _background.color = color;
    }
}