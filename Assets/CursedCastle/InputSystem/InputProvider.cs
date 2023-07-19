using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CursedCastle.InputSystem
{
	public class InputProvider : MonoBehaviour, IInput
	{
		public event Action OnInventoryInteraction;
		public event Action OnPickUpObject;
		public event Action OnUseAction;

		[Header("Character Input Values")]
		public Vector2 move;

		public Vector2 Look { get; private set; }
		public bool jump;
		public bool sprint;
		public bool isInventory;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;


#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputValue value) => 
			MoveInput(value.Get<Vector2>());

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook) 
				LookInput(value.Get<Vector2>());
		}

		public void OnJump(InputValue value) => 
			JumpInput(value.isPressed);

		public void OnSprint(InputValue value) => 
			SprintInput(value.isPressed);

		public void OnInventory()
		{
			OnInventoryInteraction?.Invoke();
			isInventory = !isInventory;
		}

		public void OnPickUp() => 
			OnPickUpObject?.Invoke();
		public void OnInteract() => 
			OnUseAction?.Invoke();
#endif


		public void MoveInput(Vector2 newMoveDirection) => 
			move = newMoveDirection;

		public void LookInput(Vector2 newLookDirection) => 
			Look = newLookDirection;

		public void JumpInput(bool newJumpState) => 
			jump = newJumpState;

		public void SprintInput(bool newSprintState) => 
			sprint = newSprintState;
	}
}