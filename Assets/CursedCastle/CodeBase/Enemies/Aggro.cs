using System;
using CursedCastle.CodeBase.InventorySystem;
using UnityEngine;

namespace CursedCastle.CodeBase.Enemies
{
    public class Aggro : MonoBehaviour
    {
        public TriggerObserve Observe;
        public AgentMoveToPlayer Follow;

        private void Start()
        {
            Observe.TriggerEnter += TriggerEnter;
            Observe.TriggerExit += TriggerExit;
            SwitchFollowOff();
        }

        private void TriggerEnter(Collider obj) => 
            SwitchFollowOn();
        private void TriggerExit(Collider obj) => 
            SwitchFollowOff();
        
        private void SwitchFollowOn() => 
            Follow.enabled = true;

        private void SwitchFollowOff() => 
            Follow.enabled = false;
    }
}