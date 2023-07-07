using CursedCastle.CodeBase.Character.Selector;
using UnityEngine;

namespace CursedCastle.CodeBase.Factories
{
    public class GameElementsFactory : IGameElementsFactory
    {
        private const string RayPath = "Emitter";

        public Emitter CreateEmitter(Transform transform)
        {
            Emitter emitterPrefab = Resources.Load<Emitter>(RayPath);
            Emitter emitter = Object.Instantiate(emitterPrefab, transform);
            return emitter;
        }
    }
}