using System;
using CursedCastle.CodeBase.Factories;
using CursedCastle.CodeBase.Infrastructure;
using CursedCastle.CodeBase.Loot;
using CursedCastle.InputSystem;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace CursedCastle.CodeBase.InventorySystem
{
    public class InventoryService : MonoBehaviour
    {
        private IInventoryRepository _repository;
        private StarterAssetsInputs _input;
        private bool _isOpen;

        private IUIFactory _uiFactory;
        private GameObject _inventory;
        [HideInInspector] public InventoryUi InventoryUi;

        public void Construct(IUIFactory uiFactory) => 
            _uiFactory = uiFactory;

        private void Start()
        {
            _input = AllServices.Container.Single<IInputService>().StarterAssetsInputs;
            _input.OnInventoryInteraction += Interaction;
            _repository = new InventoryRepository();
        }

        private void OnDestroy() => 
            _input.OnInventoryInteraction -= Interaction;

        private void Interaction()
        {
            if (!_isOpen)
                Open();
            else
                Close();
        }

        private void Open()
        {
            if(_inventory != null)
                return;

            _isOpen = true;
            _inventory = _uiFactory.CreateInventory(this);
            InventoryUi = _inventory.GetComponent<InventoryUi>();
            Transform uiPlaceForItems = InventoryUi.PlaceForItems;
            CreateItems(_repository, uiPlaceForItems);
        }

        private void Close()
        {
            Destroy(_inventory);
            _isOpen = false;
        }

        private void CreateItems(IInventoryRepository repository, Transform placeForItems)
        {
            if(_repository.Items.Count == 0)
                return;
            
            foreach (var item in _repository.Items)
                CreateItem(item, placeForItems);
        }

        private void CreateItem(IItem item, Transform placeForItem)
        {
            LootTypeID lootTypeID = item.LootTypeID;
            _uiFactory.CreateInventoryItem(lootTypeID, InventoryUi);
        }

        public void AddItem(IItem item)
        {
            _repository.AddItem(item);
        }

        public void Drop()
        {
            InventoryItemUI selectedItem = InventoryUi.SelectedItem;
            Destroy(selectedItem.gameObject);
        }
        public void Take(){}
    }
}