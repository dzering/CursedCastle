using System;
using CursedCastle.CodeBase.Character.Interaction.InteractablePart;
using UnityEngine;

namespace CursedCastle.CodeBase.Character.Interaction
{
    [CreateAssetMenu(fileName = nameof(InteractableValue), menuName = "Containers/" + nameof(InteractableValue))]
    public class InteractableValue : ScriptableObject
    {
        public IInteractable CurrentValue { get; private set; }
        public Action<IInteractable> OnSelected;

        public void SetValue(IInteractable interactable)
        {
            CurrentValue = interactable;
            OnSelected?.Invoke(CurrentValue);
        }
    }
}