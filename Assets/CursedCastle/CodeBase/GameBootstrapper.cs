using CursedCastle.CodeBase.Infrastructure;
using UnityEngine;

namespace CursedCastle.CodeBase
{
    public class GameBootstrapper : MonoBehaviour
    {
        private Game _game;
        [SerializeField] private GameObject _inputSystem;

        void Awake()
        {
            GameObject inputSystem = Instantiate(_inputSystem);
            _game = new Game(inputSystem, AllServices.Container);
            DontDestroyOnLoad(this);
        }
        
    }
}
