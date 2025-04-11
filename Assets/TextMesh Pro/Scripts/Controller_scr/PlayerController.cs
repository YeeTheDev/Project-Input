using UnityEngine;
using UnityEngine.InputSystem;
using PI.Movement;
using PI.InputReading;

namespace PI.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Collider2D groundChecker;
        [SerializeField] LayerMask groundMask;

        bool grounded;
        bool stopped;
        Mover mover;
        PlayerInputReader inputReader;

        private void Awake()
        {
            inputReader = GetComponent<PlayerInputReader>();
            mover = GetComponent<Mover>();

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
            if (!stopped) { Debug.Log("Attacking"); }
        }

        public void ReadShootAction(InputAction.CallbackContext value)
        {
            if (!stopped) { Debug.Log("Shooting"); }
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