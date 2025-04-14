using UnityEngine;
using PI.Attacks.Types;

namespace PI.Attacks
{
    public class RangedAttack : BaseAttack
    {
        public override AttackType GetAttackType() { return AttackType.Ranged; }

        public override void Attack()
        {
            Debug.Log($"{transform.parent.name} tried a RANGED attack");
        }
    }
}
