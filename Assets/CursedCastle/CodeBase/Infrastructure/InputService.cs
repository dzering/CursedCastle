using CursedCastle.InputSystem;
using UnityEngine.InputSystem;

namespace CursedCastle.CodeBase.Infrastructure
{
    public class InputService : IInputService
    {
        public PlayerInput PlayerInput { get; }
        public Input Input { get; }

        public InputService(PlayerInput playerInput, Input input)
        {
            PlayerInput = playerInput;
            Input = input;
        }
    }
}