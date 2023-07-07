using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace CursedCastle.CodeBase.Character.Selector
{
    public class Emitter : MonoBehaviour, ISwitchable
    {
        [SerializeField] private float maxDistance;
        [SerializeField] private LayerMask layerMask;
        private RaycastHit _hit;
        private bool _isEmitting;

        private void Start() =>
            SwitchOn();

        public void SwitchOn() =>
            _isEmitting = true;


        public void SwitchOff() =>
            _isEmitting = false;

        private void Update()
        {
            if (!_isEmitting)
                return;

            Raycasting();
        }

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
    }
}