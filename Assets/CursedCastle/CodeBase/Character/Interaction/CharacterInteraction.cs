using CursedCastle.CodeBase.Infrastructure;
using UnityEngine;

namespace CursedCastle.CodeBase.Character.Interaction
{
    public class CharacterInteraction : MonoBehaviour, ICharacterInteraction
    {
        [SerializeField] private InteractableValue interactableValue;
        private IInteractingValue _interactingValue;
        private IInputService _inputService;
        
        private bool _hasInteractingObject;

        public void Construct(IInputService inputService) //todo initialization
        {
            _inputService = inputService;
            _inputService.StarterAssetsInputs.OnUseAction += Interact;
        }

        private void OnDestroy() => 
            _inputService.StarterAssetsInputs.OnUseAction -= Interact;

        public void SetInteractingValue(IInteractingValue interactingValue) => 
            _interactingValue = interactingValue;

        public void RemoveInteractingValue() => 
            _interactingValue = null;

        public void Interact()
        {
            if (interactableValue.CurrentValue != null)
                interactableValue.CurrentValue.Interact(_interactingValue);
        }
    }
}