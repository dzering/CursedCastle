using CursedCastle.CodeBase.Factories;
using CursedCastle.CodeBase.Infrastructure;
using CursedCastle.CodeBase.StaticData;
using CursedCastle.InputSystem;
using UnityEngine;

namespace CursedCastle.CodeBase.Inventory
{
    public class InventoryService : MonoBehaviour
    {
        [SerializeField] private GameObject _itemPref;
        [SerializeField] private Transform _placeForItems;
        private IInventoryRepository _repository;
        private StarterAssetsInputs _input;
        private bool _isOpen;

        private IUIFactory _uiFactory;
        private GameObject _inventory;
        private InventoryRepository _inventoryRepository;
        public Sprite _sprite; // Delete it
        private InventoryUI _inventoryUI;

        public void Construct(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }
        private void Start()
        {
            _input = AllServices.Container.Single<IInputService>().StarterAssetsInputs;
            _input.OnInventoryInteraction += Interaction;
            _inventoryRepository = new InventoryRepository();
        }

        private void OnDestroy()
        {
            _input.OnInventoryInteraction -= Interaction;
        }

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
            _inventory = _uiFactory.CreateInventory();
            _inventoryUI = _inventory.GetComponent<InventoryUI>();
            _placeForItems = _inventoryUI._placeForItems;
            CreateItems(_repository, _placeForItems);
        }

        private void Update()
        {
            if (_input.jump)
            {
                if(!_isOpen)
                    return;
                CreateItem(new ItemModel("Label", _sprite), _placeForItems);
            }
        }

        private void CreateItems(IInventoryRepository repository, Transform placeForItems)
        {
            for (int i = 0; i < _repository.Items.Count; i++)
            {
                CreateItem(repository.Items[i], placeForItems);
            }
        }

        private void CreateItem(IItemModel model, Transform placeForItem)
        {
            GameObject item = Instantiate(_itemPref, placeForItem);
            InventoryItem inventoryItem = item.GetComponent<InventoryItem>();
            inventoryItem.Construct(model);
        }

        private void Close()
        {
            GameObject.Destroy(_inventory);
            _isOpen = false;
        }

        public void AddItem(LootTypeID lootTypeID)
        {
            // UpdateInventory();
        }

    }
}