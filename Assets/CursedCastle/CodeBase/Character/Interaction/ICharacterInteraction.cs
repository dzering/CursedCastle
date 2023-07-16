namespace CursedCastle.CodeBase.Character.Interaction
{
    public interface ICharacterInteraction
    {
        void SetInteractingValue(IInteracting interacting);
        void RemoveInteractingValue();
        void Interact();
    }
}