using System;
using CursedCastle.CodeBase.InventorySystem;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace CursedCastle.CodeBase.UI.Inventory
{
    public class InventoryItemUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [HideInInspector] public IItem Item;
        [SerializeField] private Image _background;
        [SerializeField] private Image _itemImage;
        [SerializeField] private Image _hovered;

        [SerializeField] private Color _defaultColor;

        [SerializeField] private Color _selectedColor;

        private InventoryUi _inventoryUi;

        private void Start()
        {
        }

        public void Construct(IItem item, Sprite sprite, InventoryUi inventoryUi)
        {
            Item = item;
            _itemImage.sprite = sprite;
            _inventoryUi = inventoryUi;

            CheckSelected();
        }

        private void CheckSelected()
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

            _inventoryUi.SelectItem(this);
            _background.color = _selectedColor;
            Item.IsSelected = true;
        }

        private void DeselectItem()
        {
            Item.IsSelected = false;
            _background.color = _defaultColor;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _hovered.gameObject.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _hovered.gameObject.SetActive(false);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            SelectItem();
        }
    }
}