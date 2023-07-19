using CursedCastle.InputSystem;
using UnityEngine.InputSystem;

namespace CursedCastle.CodeBase.Infrastructure
{
    public interface IInputService : IService
    {
        PlayerInput PlayerInput { get; }
        InputProvider InputProvider { get; }
    }
}