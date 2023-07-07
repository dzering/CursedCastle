using System;
using UnityEngine;

namespace CursedCastle.CodeBase.InventorySystem
{
    [RequireComponent(typeof(Collider))]
    public class TriggerObserve : MonoBehaviour
    {
        public event Action TriggeringStay;

        private void OnTriggerStay(Collider other) => 
            TriggeringStay?.Invoke();
    }
}