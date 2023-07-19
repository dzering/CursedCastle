using CursedCastle.CodeBase.Factories;
using CursedCastle.CodeBase.StaticData;
using CursedCastle.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CursedCastle.CodeBase.Infrastructure
{
    public class BootstrapState
    {
        private readonly AllServices _allServices;
        private readonly GameObject _inputSystem;

        public BootstrapState(AllServices allServices, GameObject inputSystem)
        {
            _allServices = allServices;
            _inputSystem = inputSystem;
            
            RegisterService();
        }

        private void RegisterService()
        {
            RegisterInputService();
            RegisterStaticData();
            _allServices.RegisterSingle<ICursor>(new CursorBehavior());
            _allServices.RegisterSingle<IUIFactory>(new UIFactory(
                _allServices.Single<IStaticDataService>()));
            _allServices.RegisterSingle<IGameElementsFactory>(new GameElementsFactory());
            _allServices.RegisterSingle<IGameFactory>(new GameFactory(
                _allServices.Single<IUIFactory>(),
                _allServices.Single<IGameElementsFactory>(),
                _allServices.Single<IInputService>(),
                _allServices.Single<IStaticDataService>(),
                _allServices.Single<ICursor>()));
        }

        private void RegisterStaticData()
        {
            IStaticDataService staticDataService = new StaticDataService();
            staticDataService.LoadLoot();
            _allServices.RegisterSingle<IStaticDataService>(staticDataService);
        }


        private void RegisterInputService()
        {
            InputProvider inputProvider = _inputSystem.GetComponent<InputProvider>();
            PlayerInput playerInput = _inputSystem.GetComponent<PlayerInput>();
            
            _allServices.RegisterSingle<IInputService>(new InputService(playerInput,inputProvider));
        }
    }
}