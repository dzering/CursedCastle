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
        [SerializeField] private Transform _placeForUsedItem;
        
        [HideInInspector] public InventoryUi InventoryUi;
        private IInventoryRepository _repository;
        private IInput _input;
        private ICharacterInteraction _characterInteraction;
        
        private bool _isOpen;

        private IUIFactory _uiFactory;
        private GameObject _inventory;
        private GameFactory _gameFactory;
        private AllServices _services;
        private ICursor _cursor;

        public void Construct(GameFactory gameFactory, IUIFactory uiFactory, IInput input, ICursor cursor)
        {
            _gameFactory = gameFactory;
            _uiFactory = uiFactory;
            _input = input;
            _cursor = cursor;
            
            _input.OnInventoryInteraction += UseInventory;
        }

        private void Start()
        {
            _repository = new InventoryRepository();
            _characterInteraction = GetComponent<CharacterInteraction>();
        }

        private void OnDestroy() => 
            _input.OnInventoryInteraction -= UseInventory;

        public void AddItem(IItem item) => 
            _repository.AddItem(item);

        public void DropItem()
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
            if(selectedItem==null)
                return;
            
            var loot = CreateSelectedItemInWorld(selectedItem);
            SetInteractingValueForCharacter(loot);
        }

        private void SetInteractingValueForCharacter(GameObject loot)
        {
            LootPiece lootPiece = loot.GetComponentInChildren<LootPiece>();
            IInteracting interacting = loot.GetComponentInChildren<InteractionType>();

            // todo Outline usable item in inventory;

            _characterInteraction.SetInteractingValue(interacting);
        }

        private GameObject CreateSelectedItemInWorld(InventoryItemUI selectedItem)
        {
            InventoryItemUI item = selectedItem;
            LootTypeID lootTypeID = item.Item.LootTypeID;
            var loot = _gameFactory.CreateLoot(lootTypeID, _placeForUsedItem);
            return loot;
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
            
            _cursor.OnUIFocus(_isOpen);
        }

        public void Close()
        {
            Destroy(_inventory);
            _isOpen = false;
            
            _cursor.OnUIFocus(_isOpen);
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