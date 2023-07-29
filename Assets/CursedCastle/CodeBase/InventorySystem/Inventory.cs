using CursedCastle.CodeBase.Character.Interaction;
using CursedCastle.CodeBase.Factories;
using CursedCastle.CodeBase.Infrastructure;
using CursedCastle.CodeBase.Loot;
using CursedCastle.CodeBase.UI.InventoryUI;
using CursedCastle.InputSystem;
using UnityEngine;

namespace CursedCastle.CodeBase.InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private Transform _placeForUsedItem;
        [HideInInspector] public InventoryUi InventoryUi;
       
        public IItem SelectedItem;
        private IInventoryRepository _repository;
        private IInput _input;
        private ICharacterInteraction _characterInteraction;
        
        private bool _isOpen;

        private IUIFactory _uiFactory;
        private GameObject _inventory;
        private GameFactory _gameFactory;
        private AllServices _services;
        private ICursor _cursor;
        private GameObject _usingItem;

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

        public void Close()
        {
            Destroy(_inventory);
            _isOpen = false;
            
            _cursor.OnUIFocus(_isOpen);
        }

        public void AddItem(IItem item) => 
            _repository.AddItem(item);

        public void RemoveItem()
        {
            if(InventoryUi.SelectedItem == null)
                return;

            InventoryItemUI selectedItem = CreateItemInWorld();
            _repository.RemoveItem(selectedItem.Item);
            InventoryUi.UpdateUI(_repository);
        }

        private InventoryItemUI CreateItemInWorld()
        {
            InventoryItemUI selectedItem = InventoryUi.SelectedItem;
            LootTypeID lootTypeID = selectedItem.Item.LootTypeID;
            _gameFactory.CreateLoot(lootTypeID, transform);
            
            return selectedItem;
        }

        public void UseItem(IItem itemUI)
        {
            if(itemUI == null)
                return;
            
            _usingItem = CreateSelectedItemInWorld(itemUI.LootTypeID, _placeForUsedItem);
            SetInteractingValueForCharacter(_usingItem);
        }

        private void OnDestroy() => 
            _input.OnInventoryInteraction -= UseInventory;

        public void CancelUseItem()
        {
            if(_usingItem == null)
                return;
            
            Destroy(_usingItem);
        }

        private void SetInteractingValueForCharacter(GameObject loot)
        {
            LootPiece lootPiece = loot.GetComponentInChildren<LootPiece>();
            IInteracting interacting = loot.GetComponentInChildren<InteractionType>();

            // todo Outline usable item in inventory;

            _characterInteraction.SetInteractingValue(interacting);
        }

        private GameObject CreateSelectedItemInWorld(LootTypeID lootTypeID, Transform placeForObject)
        {
            var loot = _gameFactory.CreateLoot(lootTypeID, placeForObject);
            return loot;
        }

        private void UseInventory()
        {
            if (!_isOpen)
                Open();
            else
                Close();
            _input.OnFocusUI(_isOpen);
        }

        private void Open()
        {
            if(_inventory != null)
                return;
            
            _isOpen = true;
            _inventory = _uiFactory.CreateInventory(this);
            InventoryUi = _inventory.GetComponent<InventoryUi>();
            InventoryUi.Construct(this, _uiFactory);
            InventoryUi.UpdateUI(_repository);
            
            _cursor.OnUIFocus(_isOpen);
        }
    }
}