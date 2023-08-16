using System;
using CursedCastle.CodeBase.Infrastructure;
using UnityEngine;

namespace CursedCastle.CodeBase.Factories
{
    public interface IGameFactory : IService
    {
        GameObject CreateInputSystem();
        GameObject CreateCharacter();
        GameObject CreateVmCamera(GameObject target);
        GameObject Player { get;}
        event Action OnPlayerCreated;
    }
}