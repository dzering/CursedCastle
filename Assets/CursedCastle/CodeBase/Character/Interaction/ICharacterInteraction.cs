namespace CursedCastle.CodeBase.Character.Interaction
{
    public interface ICharacterInteraction
    {
        void SetInteractingValue(IInteractingValue interactingValue);
        void RemoveInteractingValue();
        void Interact();
    }
}