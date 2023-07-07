using System;
using CursedCastle.CodeBase.InventorySystem;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace CursedCastle.CodeBase.Character.Selector
{
    public class Emitter : MonoBehaviour, IInteractable
    {
        [SerializeField] private float maxDistance;
        [SerializeField] private LayerMask layerMask;
        private RaycastHit _hit;
        private bool _isEmitting;

        private bool Raycasting()
        {
            bool isRaycast = Physics.Raycast(transform.position, transform.forward, out _hit, maxDistance, layerMask.value);
            
            if (isRaycast)
                Debug.DrawRay(transform.position, transform.forward * _hit.distance, Color.green);
            else
            {
                Debug.DrawRay(transform.position, transform.forward * 1000, Color.red);
            }

            return isRaycast;
        }

        public void Interact()
        {
            Raycasting();
        }
    }
}