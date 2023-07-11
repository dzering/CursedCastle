using CursedCastle.CodeBase.InventorySystem;
using UnityEngine;

namespace CursedCastle.CodeBase.Character.Selector
{
    public class Emitter : MonoBehaviour
    {
        [SerializeField] private float maxDistance;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private SelectableValue selectableValue;
        private RaycastHit _hit;
        private bool _isEmitting;

        public void Interact()
        {
            Raycasting();
        }

        private bool Raycasting()
        {
            bool isRaycast = Physics.Raycast(transform.position, transform.forward, out _hit, maxDistance, layerMask.value);

            if (isRaycast)
            {
                ISelectable selectable = _hit.collider.GetComponentInParent<ISelectable>();
                selectableValue.SetValue(selectable);
                Debug.DrawRay(transform.position, transform.forward * _hit.distance, Color.green);
            }

            else
            {
                selectableValue.SetValue(null);
                Debug.DrawRay(transform.position, transform.forward * 1000, Color.red);
            }
            

            return isRaycast;
        }
    }
}