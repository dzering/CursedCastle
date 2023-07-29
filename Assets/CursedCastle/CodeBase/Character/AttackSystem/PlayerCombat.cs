using System;
using CursedCastle.CodeBase.Character.AttackSystem.Weapons;
using CursedCastle.CodeBase.Infrastructure;
using CursedCastle.InputSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace CursedCastle.CodeBase.Character.AttackSystem
{
    public class PlayerCombat : MonoBehaviour
    {
        public Animator Animator;

        private static readonly int AttackTrigger = Animator.StringToHash("Attack");
        private IInput _inputProvider;
        private MeleeWeapon _currentMeleeWeapon;
        
        private void Start()
        {
            _inputProvider = AllServices.Container.Single<IInputService>().InputProvider;
            _inputProvider.OnPlayerAttack += Attack;
        }

        private void Attack() => 
            Animator.SetTrigger(AttackTrigger);

        public void OnDamage()
        {
            if(_currentMeleeWeapon == null)
                return;
            
            _currentMeleeWeapon.Attack();
        }
    }
}