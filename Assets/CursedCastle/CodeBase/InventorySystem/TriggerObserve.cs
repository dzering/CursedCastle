using System;
using UnityEngine;

namespace CursedCastle.CodeBase.InventorySystem
{
    [RequireComponent(typeof(Collider))]
    public class TriggerObserve : MonoBehaviour
    {
        public event Action TriggeringStay;
        public event Action<Collider> TriggerEnter;
        public event Action<Collider> TriggerExit;

        private void OnTriggerStay(Collider other) => 
            TriggeringStay?.Invoke();

        private void OnTriggerEnter(Collider other) => 
            TriggerEnter?.Invoke(other);

        private void OnTriggerExit(Collider other) => 
            TriggerExit?.Invoke(other);
    }
}