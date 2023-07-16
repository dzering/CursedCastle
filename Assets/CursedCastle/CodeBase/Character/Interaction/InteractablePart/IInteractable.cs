namespace CursedCastle.CodeBase.Character.Interaction.InteractablePart
{
    public interface IInteractable
    {
        public InteractionTypeID InteractionTypeID{get;}
        void Interact(IInteracting interacting);
        void Interact();
    }
}