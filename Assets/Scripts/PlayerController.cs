using System.Collections;
using System.Collections.Generic;
using PI.StateMachines;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PI.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        PlayerStateMachine stateMachine;

        private void Awake() => stateMachine = GetComponent<PlayerStateMachine>();

        public void ReadJumpPerformedAction(InputAction.CallbackContext value)
        {
            if (stateMachine.CurrentState == PlayerStates.InGround) { Debug.Log("Jump"); }
        }

        public void ReadJumpCanceledAction(InputAction.CallbackContext value)
        {
            if (stateMachine.CurrentState == PlayerStates.InAir) { Debug.Log("Trying to cancel jump"); }
        }

        public void ReadMeleeAction(InputAction.CallbackContext value)
        {
            if (stateMachine.CurrentState != PlayerStates.Stopped && stateMachine.CurrentState != PlayerStates.Attacking) { Debug.Log("Attacking"); }
        }

        public void ReadShootAction(InputAction.CallbackContext value)
        {
            if (stateMachine.CurrentState != PlayerStates.Stopped && stateMachine.CurrentState != PlayerStates.Attacking) { Debug.Log("Shooting"); }
        }

        public void ReadBlockAction(InputAction.CallbackContext value)
        {
            if (stateMachine.CurrentState != PlayerStates.Stopped && stateMachine.CurrentState != PlayerStates.Attacking) { Debug.Log("Blocking"); }
        }

        public void ReadDrinkAction(InputAction.CallbackContext value)
        {
            if (stateMachine.CurrentState == PlayerStates.InGround) { Debug.Log("Drinking"); }
        }
    }
}