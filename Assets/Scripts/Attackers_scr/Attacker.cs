using System.Collections.Generic;
using PI.Attacks;
using PI.Attacks.Types;
using UnityEngine;

namespace PI.Attackers
{
    public class Attacker : MonoBehaviour
    {
        Dictionary<AttackType, BaseAttack> attacks = new Dictionary<AttackType, BaseAttack>();

        private void Awake() { GetAllAttacks(); }

        private void GetAllAttacks()
        {
            foreach (BaseAttack attack in GetComponentsInChildren<BaseAttack>())
            {
                attacks.Add(attack.GetAttackType(), attack);
            }
        }

        public void TryAttack(AttackType attackToTrigger)
        {
            if (attacks.ContainsKey(attackToTrigger))
            {
                attacks[attackToTrigger].Attack();
            }
#if UNITY_EDITOR
            else { Debug.Log($"Unit doesn't have an attack of type {attackToTrigger}"); }
#endif
        }
    }
}
