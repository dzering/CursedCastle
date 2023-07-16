using CursedCastle.CodeBase.Character.Interaction;
using CursedCastle.CodeBase.Character.Interaction.InteractablePart;
using UnityEngine;

namespace CursedCastle.CodeBase.Character.Selector
{
    public class Emitter : MonoBehaviour
    {
        [SerializeField] private float maxDistance = 1;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private SelectableValue selectableValue;
        [SerializeField] private InteractableValue interactableValue;
        private RaycastHit _hit;
        private bool _isEmitting;

        public void Execute() => 
            Raycasting();

        private bool Raycasting()
        {
            bool isRaycast = Physics.Raycast(transform.position, transform.forward, out _hit, maxDistance,
                layerMask.value);

            if (isRaycast)
            {
                ISelectable selectable = _hit.collider.GetComponentInParent<ISelectable>();
                if (selectable != null)
                {
                    selectableValue.SetValue(selectable);
                    DebugRaycast();
                }

                IInteractable interactable = _hit.collider.GetComponentInParent<IInteractable>();
                if (interactable != null)
                {
                    interactableValue.SetValue(interactable);
                    DebugRaycast();
                }
            }

            else
            {
                selectableValue.SetValue(null);
                interactableValue.SetValue(null);
                Debug.DrawRay(transform.position, transform.forward * 1000, Color.red);
            }
            
            return isRaycast;
        }

        private void DebugRaycast() => 
            Debug.DrawRay(transform.position, transform.forward * _hit.distance, Color.green);
    }
}