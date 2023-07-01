using System;
using System.Collections;
using CursedCastle.CodeBase.Loot;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CursedCastle.CodeBase.InventorySystem
{
    public class InventoryItemUI : MonoBehaviour
    {
        [HideInInspector] public LootTypeID LootTypeID; 
        [SerializeField] private Image _image;
        [SerializeField] private Button _selectButton;
        private InventoryUi _inventoryUi;

        public void Construct(LootTypeID lootTypeID, Sprite sprite, InventoryUi inventoryUi)
        {
            LootTypeID = lootTypeID;
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
