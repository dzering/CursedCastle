using CursedCastle.InputSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace StarterAssets.Mobile.Scripts.CanvasInputs
{
    public class UICanvasControllerInput : MonoBehaviour
    {
        [FormerlySerializedAs("input")] [FormerlySerializedAs("inputs")] [FormerlySerializedAs("starterAssetsInputs")] [Header("Output")]
        public InputProvider inputProvider;

        public void VirtualMoveInput(Vector2 virtualMoveDirection)
        {
            inputProvider.MoveInput(virtualMoveDirection);
        }

        public void VirtualLookInput(Vector2 virtualLookDirection)
        {
            inputProvider.LookInput(virtualLookDirection);
        }

        public void VirtualJumpInput(bool virtualJumpState)
        {
            inputProvider.JumpInput(virtualJumpState);
        }

        public void VirtualSprintInput(bool virtualSprintState)
        {
            inputProvider.SprintInput(virtualSprintState);
        }
    }

}
