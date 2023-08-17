using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace CursedCastle.CodeBase.Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(EnemyAnimator))]
    public class AnimateDuringMove : MonoBehaviour
    {
        public NavMeshAgent Agent;
        public EnemyAnimator Animator;
        private const float MinSpeed = 0.1f;


        private void Update()
        {
            if (ShouldMove())
                Animator.Move();
            else
                Animator.StopMove();
        }

        private bool ShouldMove() => 
            Agent.velocity.magnitude > MinSpeed;
    }
}