using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CursedCastle.InputSystem
{
    public interface IInput
    {
        event Action OnInventoryInteraction;
        event Action OnPickUpObject;
        event Action OnUseAction;
        event Action OnCrouchToggle;
        Vector2 Look { get; }
        void OnMove(InputValue value);
        void OnLook(InputValue value);
        void OnJump(InputValue value);
        void OnSprint(InputValue value);
        void OnInventory();
        void OnPickUp();
        void OnInteract();
        void OnCrouch();
        event Action OnPlayerAttack;
        void OnFocusUI(bool hasFocus);
    }
}