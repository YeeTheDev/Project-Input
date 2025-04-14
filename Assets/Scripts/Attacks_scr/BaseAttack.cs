using UnityEngine;
using PI.Attacks.Types;

namespace PI.Attacks
{
    public abstract class BaseAttack : MonoBehaviour
    {
        public virtual AttackType GetAttackType() { return AttackType.NONE; }
        public virtual void Attack() { }
    }
}