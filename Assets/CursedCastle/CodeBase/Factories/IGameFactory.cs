using CursedCastle.CodeBase.Infrastructure;
using UnityEngine;

namespace CursedCastle.CodeBase.Factories
{
    public interface IGameFactory : IService
    {
        GameObject CreateInputSystem();
        GameObject CreateCharacter();
        void CreateVmCamera(GameObject target);
    }
}