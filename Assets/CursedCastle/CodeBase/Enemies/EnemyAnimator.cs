using System;
using CursedCastle.CodeBase.Logic;
using UnityEngine;

namespace CursedCastle.CodeBase.Enemies
{
    public class EnemyAnimator : MonoBehaviour, IAnimationStateReader
    {
        private Animator _animator;
        private static readonly int Idle = Animator.StringToHash("Idle");
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Jump = Animator.StringToHash("Jump");
        private static readonly int Hit = Animator.StringToHash("Hit");
        private static readonly int Death = Animator.StringToHash("Death");

        private readonly int _attackHashState = Animator.StringToHash("attack");
        private readonly int _jumpHashState = Animator.StringToHash("jump");
        private readonly int _dieHashState = Animator.StringToHash("die");
        private readonly int _moveHashState = Animator.StringToHash("walk");
        private readonly int _idleHashState = Animator.StringToHash("idle");

        public event Action<AnimatorState> StateEntered; 
        public event Action<AnimatorState> StateExited; 
        private void Start() => 
            _animator = GetComponent<Animator>();

        public void Move() => 
            _animator.SetBool(IsMoving, true);

        public void StopMove() => 
            _animator.SetBool(IsMoving, false);

        public void PlayAttack() => 
            _animator.SetTrigger(Attack);

        public void PlayHit() => 
            _animator.SetTrigger(Hit);

        public void PlayJump() => 
            _animator.SetTrigger(Jump);

        public void EnteredState(int hashState)
        {
            State = StateFor(hashState);
            StateEntered?.Invoke(State);
        }

        public void ExitedState(int hashState)
        {
            State = StateFor(hashState);
            StateExited?.Invoke(State);
        }

        public AnimatorState State { get; private set; }

        private AnimatorState StateFor(int hashState)
        {
            AnimatorState state;
            
            if (_attackHashState == hashState)
                state = AnimatorState.Attack;
            else if (_moveHashState == hashState)
                state = AnimatorState.Walk;
            else if (_dieHashState == hashState)
                state = AnimatorState.Die;
            else if (_idleHashState == hashState)
                state = AnimatorState.Idle;
            else if (_jumpHashState == hashState)
                state = AnimatorState.Jump;
            else
                state = AnimatorState.Uncknown;

            return state;
        }
    }
}
