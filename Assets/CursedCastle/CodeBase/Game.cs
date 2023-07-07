using CursedCastle.CodeBase.Factories;
using CursedCastle.CodeBase.Infrastructure;
using UnityEngine;

namespace CursedCastle.CodeBase
{
    public class Game
    {
        private readonly GameObject _inputSystem;
        private readonly AllServices _services;
        private readonly LoadLevelState _loadLevelState;

        public Game(GameObject inputSystem, AllServices services)
        {
            _inputSystem = inputSystem;
            _services = services;
            Initialize();
            _loadLevelState = new LoadLevelState(_services.Single<IUIFactory>(),
                _services.Single<IGameFactory>(), _services.Single<IGameElementsFactory>());
        }
        
        private void Initialize()
        {
            BootstrapState bootstrapState = new BootstrapState(AllServices.Container, _inputSystem);
        }
    }
}