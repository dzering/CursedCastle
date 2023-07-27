using System;
using CursedCastle.CodeBase.InventorySystem;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CursedCastle.CodeBase.UI.InventoryUI
{
    public class InventoryItemUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public Action<InventoryItemUI> OnSelect;
        public Action<InventoryItemUI> OnDeselect;

        public IItem Item;
        [SerializeField] private Image _background;
        [SerializeField] private Image _itemImage;
        [SerializeField] private Image _hovered;

        [SerializeField] private Color _defaultColor;

        [SerializeField] private Color _selectedColor;

        public void Construct(IItem item, Sprite sprite)
        {
            Item = item;
            _itemImage.sprite = sprite;

            CheckSelection();
        }

        public void DeselectItem()
        {
            Item.IsSelected = false;
            OnDeselect?.Invoke(this);
            SetBackgroundColor(_defaultColor);
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

            OnSelect?.Invoke(this);
            Item.IsSelected = true;
            SetBackgroundColor(_selectedColor);
        }

        private void SetBackgroundColor(Color color) => 
            _background.color = color;
    }
}