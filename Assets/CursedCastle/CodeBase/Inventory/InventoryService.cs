using CursedCastle.CodeBase.Factories;
using CursedCastle.CodeBase.Infrastructure;
using CursedCastle.InputSystem;
using UnityEngine;

namespace CursedCastle.CodeBase.Inventory
{
    public class InventoryService : MonoBehaviour
    {
        [SerializeField] private GameObject _itemPref;
        [SerializeField] private GameObject _inventoryPref;

        [SerializeField] private Transform HUD;
        private IInventoryRepository _repository;
        private StarterAssetsInputs _input;
        private bool _isOpen;

        private Transform inventoryTransform;
        private IUIFactory _uiFactory;
        private GameObject _inventory;

        public void Construct(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }
        private void Start()
        {
            _input = AllServices.Container.Single<IInputService>().StarterAssetsInputs;
            _input.OnInventoryInteraction += Interaction;
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
        }

        private void CreateInventoryItems(IInventoryRepository repository, Transform inventory)
        {
            for (int i = 0; i < _repository.Items.Count; i++)
            {
                CreateInventoryItem(repository.Items[i], inventory);
            }
        }

        private void CreateInventoryItem(IInventoryItem repositoryItem, Transform inventory)
        {
            Instantiate(_itemPref, inventoryTransform);
        }

        private void Close()
        {
            GameObject.Destroy(_inventory);
            _isOpen = false;
        }

    }
}