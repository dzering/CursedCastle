using CursedCastle.CodeBase.Character.Interaction;
using CursedCastle.CodeBase.Factories;
using CursedCastle.CodeBase.Infrastructure;
using CursedCastle.CodeBase.Loot;
using CursedCastle.CodeBase.UI.Inventory;
using CursedCastle.InputSystem;
using UnityEngine;

namespace CursedCastle.CodeBase.InventorySystem
{
    public class InventoryService : MonoBehaviour
    {
        [HideInInspector] public InventoryUi InventoryUi;
        private IInventoryRepository _repository;
        private StarterAssetsInputs _input;
        private ICharacterInteraction _characterInteraction;
        
        private bool _isOpen;

        private IUIFactory _uiFactory;
        private GameObject _inventory;
        private GameFactory _gameFactory;

        public void Construct(GameFactory gameFactory, IUIFactory uiFactory)
        {
            _gameFactory = gameFactory;
            _uiFactory = uiFactory;
        }

        private void Start()
        {
            _input = AllServices.Container.Single<IInputService>().StarterAssetsInputs;
            _input.OnInventoryInteraction += UseInventory;
            _repository = new InventoryRepository();
            _characterInteraction = GetComponent<CharacterInteraction>();
        }

        private void OnDestroy() => 
            _input.OnInventoryInteraction -= UseInventory;

        public void AddItem(IItem item)
        {
            _repository.AddItem(item);
        }

        public void RemoveItem()
        {
            InventoryItemUI selectedItem = InventoryUi.SelectedItem;
            _repository.RemoveItem(selectedItem.Item);
            LootTypeID lootTypeID = selectedItem.Item.LootTypeID;
            _gameFactory.CreateLoot(lootTypeID, transform);
            Destroy(selectedItem.gameObject);
        }

        public void UseItem()
        {
            InventoryItemUI selectedItem = InventoryUi.SelectedItem;
            _characterInteraction.SetInteractingValue(selectedItem as IInteractingValue);
        }
        
        private void UseInventory()
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

        private void CreateItem(IItem item, Transform placeForItem) => 
            _uiFactory.CreateInventoryItem(item, InventoryUi);
        
    }
}