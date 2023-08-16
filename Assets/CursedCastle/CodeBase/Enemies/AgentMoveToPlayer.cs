using CursedCastle.CodeBase.Factories;
using CursedCastle.CodeBase.Infrastructure;
using UnityEngine;
using UnityEngine.AI;

namespace CursedCastle.CodeBase.Enemies
{
    public class AgentMoveToPlayer : MonoBehaviour
    {
        public NavMeshAgent agent;
        private GameObject _player;
        private IGameFactory _gameFactory;
        private bool _isTargetInit;
        private float minDistance = 1;

        private void Start()
        {
            _gameFactory = AllServices.Container.Single<IGameFactory>();

            if (_gameFactory.Player != null)
                InitializePlayer();
            else
                _gameFactory.OnPlayerCreated += InitializePlayer;
        }

        private void InitializePlayer()
        {
            _player = _gameFactory.Player;
            _isTargetInit = true;
        }

        private void Update()
        {
            if (_isTargetInit && PlayerNotReached())
                agent.destination = _player.transform.position;
        }

        private bool PlayerNotReached() =>
            Vector3.Distance(agent.transform.position, _player.transform.position) >= minDistance;
    }
}