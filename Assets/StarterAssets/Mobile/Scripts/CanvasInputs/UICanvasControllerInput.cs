using UnityEngine;
using UnityEngine.Serialization;
using Input = CursedCastle.InputSystem.Input;

namespace StarterAssets.Mobile.Scripts.CanvasInputs
{
    public class UICanvasControllerInput : MonoBehaviour
    {
        [FormerlySerializedAs("inputs")] [FormerlySerializedAs("starterAssetsInputs")] [Header("Output")]
        public Input input;

        public void VirtualMoveInput(Vector2 virtualMoveDirection)
        {
            input.MoveInput(virtualMoveDirection);
        }

        public void VirtualLookInput(Vector2 virtualLookDirection)
        {
            input.LookInput(virtualLookDirection);
        }

        public void VirtualJumpInput(bool virtualJumpState)
        {
            input.JumpInput(virtualJumpState);
        }

        public void VirtualSprintInput(bool virtualSprintState)
        {
            input.SprintInput(virtualSprintState);
        }
    }

}
