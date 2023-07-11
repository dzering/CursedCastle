using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CursedCastle.InputSystem
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		public event Action OnInventoryInteraction;
		public event Action OnPickUpObject;

		[Header("Character Input Values")]
		public Vector2 move;

		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool isInventory;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;
		

#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnInventory()
		{
			OnInventoryInteraction?.Invoke();
			isInventory = !isInventory;
			OnUIFocus(isInventory);
		}

		public void OnPickUp()
		{
			OnPickUpObject?.Invoke();
		}
#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		public void OnUIFocus(bool hasUI)
		{
			SetCursorState(!hasUI);
			SetCursorVisible(hasUI);
		}

		private static void SetCursorVisible(bool hasUI)
		{
			Cursor.visible = hasUI;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}

	}
}