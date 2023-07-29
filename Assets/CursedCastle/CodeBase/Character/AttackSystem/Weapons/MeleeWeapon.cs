using UnityEngine;
using UnityEngine.Serialization;

namespace CursedCastle.CodeBase.Character.AttackSystem.Weapons
{
    public class MeleeWeapon : WeaponBase
    {
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private float _attackRange;
        [SerializeField] private LayerMask _layerMasks;
        [SerializeField] private int _damaging;
        private Collider[] results;
        
        public override void Attack()
        {
            var size = Physics.OverlapSphereNonAlloc(_attackPoint.position, _attackRange, results, _layerMasks);
            if(size == 0)
                return;
            
            foreach (Collider collider in results)
                if (collider.TryGetComponent(out Damageable damageable))
                    damageable.TakeDamage(_damaging);
        }
        
        private void OnDrawGizmosSelected()
        {
            if(_attackPoint == null)
                return;
            
            Gizmos.DrawSphere(_attackPoint.position, _attackRange);
        }
    }
}