using CursedCastle.CodeBase.Factories;
using UnityEngine;

namespace CursedCastle.CodeBase
{
    public class LoadLevelState
    {
        private readonly IUIFactory _uiFactory;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(IUIFactory uiFactory, IGameFactory gameFactory)
        {
            _uiFactory = uiFactory;
            _gameFactory = gameFactory;
            InitGameWorld();
        }

        private void InitGameWorld()
        {
            _uiFactory.CreateUiRoot();
            GameObject character = _gameFactory.CreateCharacter();
            _gameFactory.CreateVmCamera(character);
        }
    }
}