using UnityEngine;
using UnityEngine.InputSystem;
using PI.Movement;
using PI.InputReading;
using PI.Attackers;
using PI.Attacks.Types;

namespace PI.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Collider2D groundChecker;
        [SerializeField] LayerMask groundMask;

        bool grounded;
        bool stopped;
        Mover mover;
        Attacker attacker;
        PlayerInputReader inputReader;

        private void Awake()
        {
            mover = GetComponent<Mover>();
            attacker = GetComponent<Attacker>();
            inputReader = GetComponent<PlayerInputReader>();

            inputReader.FindActionMapAndActions();
        }

        #region Action Subscription
        private void OnEnable() => SubscribeActions();
        private void OnDisable() => UnsubscribeActions();

        private void SubscribeActions()
        {
            inputReader.JumpAction.performed += ReadJumpPerformedAction;
            inputReader.JumpAction.canceled += ReadJumpCanceledAction;
            inputReader.MeleeAction.performed += ReadMeleeAction;
            inputReader.ShootAction.performed += ReadShootAction;
            inputReader.BlockAction.performed += ReadBlockAction;
            inputReader.DrinkAction.performed += ReadDrinkAction;

            inputReader.SetEnableMap(true);
        }

        private void UnsubscribeActions()
        {
            inputReader.SetEnableMap(false);

            inputReader.JumpAction.performed -= ReadJumpPerformedAction;
            inputReader.JumpAction.canceled -= ReadJumpCanceledAction;
            inputReader.MeleeAction.performed -= ReadMeleeAction;
            inputReader.ShootAction.performed -= ReadShootAction;
            inputReader.BlockAction.performed -= ReadBlockAction;
            inputReader.DrinkAction.performed -= ReadDrinkAction;
        }
        #endregion

        private void FixedUpdate()
        {
            mover.Move(!stopped ? inputReader.XAxis : 0);

            grounded = Physics2D.IsTouchingLayers(groundChecker, groundMask);
        }

        public void ReadJumpPerformedAction(InputAction.CallbackContext value)
        {
            if (grounded)
            {
                mover.Jump();
                grounded = false;
            }
        }

        public void ReadJumpCanceledAction(InputAction.CallbackContext value) { if (!grounded) { mover.HaltJump(); } }

        public void ReadMeleeAction(InputAction.CallbackContext value)
        {
            if (!stopped) { attacker.TryAttack(AttackType.Melee); }
        }

        public void ReadShootAction(InputAction.CallbackContext value)
        {
            if (!stopped) { attacker.TryAttack(AttackType.Ranged); }
        }

        public void ReadBlockAction(InputAction.CallbackContext value)
        {
            if (!stopped) { Debug.Log("Blocking"); }
        }

        public void ReadDrinkAction(InputAction.CallbackContext value)
        {
            if (!stopped && grounded) { Debug.Log("Drinking"); }
        }
    }
}