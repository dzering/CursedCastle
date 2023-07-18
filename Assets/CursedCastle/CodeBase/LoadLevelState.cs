using CursedCastle.CodeBase.Character.Movement;
using CursedCastle.CodeBase.Character.Selector;
using CursedCastle.CodeBase.Factories;
using CursedCastle.CodeBase.InventorySystem;
using UnityEngine;

namespace CursedCastle.CodeBase
{
    public class LoadLevelState
    {
        private readonly IUIFactory _uiFactory;
        private readonly IGameFactory _gameFactory;
        private readonly IGameElementsFactory _gameElementsFactory;

        public LoadLevelState(IUIFactory uiFactory, IGameFactory gameFactory, IGameElementsFactory gameElementsFactory)
        {
            _uiFactory = uiFactory;
            _gameFactory = gameFactory;
            _gameElementsFactory = gameElementsFactory;
            
            InitGameWorld();
        }

        private void InitGameWorld()
        {
            _uiFactory.CreateUiRoot();
            _uiFactory.CreateHUD();
            GameObject character = _gameFactory.CreateCharacter();

            Transform target = character.GetComponent<HeadVerticalRotation>().target;

            GameObject vmCamera = _gameFactory.CreateVmCamera(target.gameObject);

            Emitter emitter = _gameElementsFactory.CreateEmitter(vmCamera.transform);
            TriggerObserve observe = character.GetComponentInChildren<TriggerObserve>();
            observe.TriggeringStay += emitter.Execute;
        }
    }
}