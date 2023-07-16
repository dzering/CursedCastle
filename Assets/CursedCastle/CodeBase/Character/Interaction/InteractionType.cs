using UnityEngine;

namespace CursedCastle.CodeBase.Character.Interaction
{
    public class InteractionType : MonoBehaviour, IInteractingValue
    {
        [SerializeField] private InteractionTypeID interactionTypeID;

        public InteractionTypeID InteractionTypeID => interactionTypeID;
    }
}