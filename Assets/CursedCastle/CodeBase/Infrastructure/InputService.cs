using CursedCastle.InputSystem;
using UnityEngine.InputSystem;

namespace CursedCastle.CodeBase.Infrastructure
{
    public class InputService : IInputService
    {
        public PlayerInput PlayerInput { get; }
        public StarterAssetsInputs StarterAssetsInputs { get; }

        public InputService(PlayerInput playerInput, StarterAssetsInputs starterAssetsInputs)
        {
            PlayerInput = playerInput;
            StarterAssetsInputs = starterAssetsInputs;
        }
    }
}