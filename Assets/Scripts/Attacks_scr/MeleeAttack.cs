using UnityEngine;
using PI.Attacks.Types;

namespace PI.Attacks
{
    public class MeleeAttack : BaseAttack
    {
        public override AttackType GetAttackType() { return AttackType.Melee; }

        public override void Attack()
        {
            Debug.Log($"{transform.parent.name} tried a MELEE attack");
        }
    }
}