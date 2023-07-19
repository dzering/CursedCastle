using CursedCastle.CodeBase.Infrastructure;
using UnityEngine;

namespace CursedCastle.CodeBase.Character.Interaction
{
    public class CharacterInteraction : MonoBehaviour, ICharacterInteraction
    {
        [SerializeField] private InteractableValue interactableValue;
        private IInteracting _interacting;
        private IInputService _inputService;
        
        private bool _hasInteractingObject;

        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
            _inputService.InputProvider.OnUseAction += Interact;
        }

        private void OnDestroy() => 
            _inputService.InputProvider.OnUseAction -= Interact;

        public void SetInteractingValue(IInteracting interacting) => 
            _interacting = interacting;

        public void RemoveInteractingValue() => 
            _interacting = null;

        public void Interact()
        {
            if (interactableValue.CurrentValue != null)
                interactableValue.CurrentValue.Interact(_interacting);
        }
    }
}