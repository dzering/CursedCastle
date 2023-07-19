using CursedCastle.InputSystem;
using UnityEngine.InputSystem;

namespace CursedCastle.CodeBase.Infrastructure
{
    public class InputService : IInputService
    {
        public PlayerInput PlayerInput { get; }
        public InputProvider InputProvider { get; }

        public InputService(PlayerInput playerInput, InputProvider inputProvider)
        {
            PlayerInput = playerInput;
            InputProvider = inputProvider;
        }
    }
}