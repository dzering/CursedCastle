using CursedCastle.CodeBase.Factories;
using CursedCastle.CodeBase.StaticData;
using UnityEngine;
using UnityEngine.InputSystem;
using Input = CursedCastle.InputSystem.Input;

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
            _allServices.RegisterSingle<IUIFactory>(new UIFactory(
                _allServices.Single<IStaticDataService>()));
            _allServices.RegisterSingle<IGameElementsFactory>(new GameElementsFactory());
            _allServices.RegisterSingle<IGameFactory>(new GameFactory(
                _allServices.Single<IUIFactory>(),
                _allServices.Single<IGameElementsFactory>(),
                _allServices.Single<IInputService>(), _allServices.Single<IStaticDataService>()));
        }

        private void RegisterStaticData()
        {
            IStaticDataService staticDataService = new StaticDataService();
            staticDataService.LoadLoot();
            _allServices.RegisterSingle<IStaticDataService>(staticDataService);
        }


        private void RegisterInputService()
        {
            Input input = _inputSystem.GetComponent<Input>();
            PlayerInput playerInput = _inputSystem.GetComponent<PlayerInput>();
            
            _allServices.RegisterSingle<IInputService>(new InputService(playerInput,input));
        }
    }
}