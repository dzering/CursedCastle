using CursedCastle.CodeBase.Character.Selector;
using CursedCastle.CodeBase.Infrastructure;
using UnityEngine;

namespace CursedCastle.CodeBase.Factories
{
    public interface IGameElementsFactory : IService
    {
        Emitter CreateEmitter(Transform transform);
    }
}