using CursedCastle.CodeBase.Infrastructure;
using UnityEngine;

namespace CursedCastle.CodeBase.Factories
{
    public interface IUIFactory : IService
    {
        GameObject CreateInventory();
        void CreateUiRoot();
    }
}