using Cinemachine;
using CursedCastle.CodeBase.Character;
using CursedCastle.CodeBase.Character.Interaction;
using CursedCastle.CodeBase.Infrastructure;
using CursedCastle.CodeBase.InventorySystem;
using CursedCastle.CodeBase.Loot;
using CursedCastle.CodeBase.StaticData;
using CursedCastle.InputSystem;
using StarterAssets.ThirdPersonController.Scripts;
using UnityEngine;

namespace CursedCastle.CodeBase.Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly IUIFactory _uiFactory;
        private readonly IGameElementsFactory _gameElementsFactory;
        private readonly IInputService _inputService;
        private readonly IStaticDataService _staticDataService;
        private readonly ICursor _cursor;
        private const string INPUT_SYSTEM_PATH = "InputSystem";
        private const string CHARACTER_PATH = "Character";
        private const string CAMERA_PATH = "CMvcam";

        public GameObject CreateInputSystem()
        {
            GameObject pref = Resources.Load<GameObject>(INPUT_SYSTEM_PATH);
            return Object.Instantiate(pref);
        }

        public GameFactory(IUIFactory uiFactory, IGameElementsFactory gameElementsFactory, 
            IInputService inputService, IStaticDataService staticDataService, ICursor cursor)
        {
            _uiFactory = uiFactory;
            _gameElementsFactory = gameElementsFactory;
            _inputService = inputService;
            _staticDataService = staticDataService;
            _cursor = cursor;
        }

        public GameObject CreateCharacter()
        {
            GameObject pref = Resources.Load<GameObject>(CHARACTER_PATH);
            GameObject character = Object.Instantiate(pref);
            ThirdPersonController controller = character.GetComponent<ThirdPersonController>();
            controller.Construct(_inputService);

            PlayerRotation rotation = character.GetComponent<PlayerRotation>();
            rotation.Construct(_inputService.InputProvider);

            InventoryService inventoryService = character.GetComponentInChildren<InventoryService>();
            inventoryService.Construct(this, _uiFactory, _inputService.InputProvider, _cursor);

            PickUpLootAbility pickUpLootAbility = character.GetComponentInParent<PickUpLootAbility>();
            pickUpLootAbility.Construct(_inputService);

            CharacterInteraction interaction = character.GetComponentInChildren<CharacterInteraction>();
            interaction.Construct(_inputService);

            return character;
        }

        public GameObject CreateVmCamera(GameObject target)
        {
            GameObject pref = Resources.Load<GameObject>(CAMERA_PATH);
            GameObject cameraGameObject = Object.Instantiate(pref);
            CinemachineVirtualCamera vcamera = cameraGameObject.GetComponent<CinemachineVirtualCamera>();
            vcamera.Follow = target.transform;
            vcamera.LookAt = target.transform;
            return cameraGameObject;
        }

        public GameObject CreateLoot(LootTypeID lootTypeID, Transform transform)
        {
            LootStaticData lootStaticData = _staticDataService.ForLoot(lootTypeID);
            GameObject prefab = lootStaticData.prefab;
            GameObject loot = Object.Instantiate(prefab);
            loot.transform.position = transform.position;
            return loot;
        }
    }
}