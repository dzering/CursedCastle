using UnityEngine;

namespace CursedCastle.CodeBase.Character.AttackSystem
{
    public abstract class Damageable : MonoBehaviour
    {
        public abstract void TakeDamage(int value);
    }
}