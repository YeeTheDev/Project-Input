using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PI.InputReading
{
    public class PlayerInputReader : MonoBehaviour
    {
        [SerializeField] PlayerInput playerInput;
        [SerializeField] string basicMapBame = "BasicMap";
        [SerializeField] string moveActionName = "Move";
        [SerializeField] string jumpActionName = "Jump";
        [SerializeField] string meleeActionName = "Melee";
        [SerializeField] string shootActionName = "Shoot";
        [SerializeField] string blockActionName = "Block";
        [SerializeField] string drinkActionName = "Drink";

        InputActionMap basicMap;
        InputAction moveAction;
        InputAction jumpAction;
        InputAction meleeAction;
        InputAction shootAction;
        InputAction blockAction;
        InputAction drinkAction;

        private void OnEnable()
        {
            FindActionMapAndActions();
            SubscribeActions();

            basicMap.Enable();
        }

        private void FindActionMapAndActions()
        {
            basicMap = playerInput.actions.FindActionMap(basicMapBame);

            moveAction = playerInput.actions.FindAction(moveActionName);
            jumpAction = playerInput.actions.FindAction(jumpActionName);
            meleeAction = playerInput.actions.FindAction(meleeActionName);
            shootAction = playerInput.actions.FindAction(shootActionName);
            blockAction = playerInput.actions.FindAction(blockActionName);
            drinkAction = playerInput.actions.FindAction(drinkActionName);
        }

        private void SubscribeActions()
        {
            jumpAction.performed += ReadJumpPerformedAction;
            jumpAction.canceled += ReadJumpCanceledAction;
            meleeAction.performed += ReadMeleeAction;
            shootAction.performed += ReadShootAction;
            blockAction.performed += ReadBlockAction;
            drinkAction.performed += ReadDrinkAction;
        }

        private void OnDisable()
        {
            UnsubscribeActions();

            basicMap.Disable();
        }   

        private void UnsubscribeActions()
        {
            jumpAction.performed -= ReadJumpPerformedAction;
            jumpAction.canceled -= ReadJumpCanceledAction;
            meleeAction.performed -= ReadMeleeAction;
            shootAction.performed -= ReadShootAction;
            blockAction.performed -= ReadBlockAction;
            drinkAction.performed -= ReadDrinkAction;
        }

        private void Update()
        {
            Debug.Log(moveAction.ReadValue<float>());
        }

        private void ReadJumpPerformedAction(InputAction.CallbackContext value) => Debug.Log("Jumping");
        private void ReadJumpCanceledAction(InputAction.CallbackContext value) => Debug.Log("Stop jumping");
        private void ReadMeleeAction(InputAction.CallbackContext value) => Debug.Log("Meleeing");
        private void ReadShootAction(InputAction.CallbackContext value) => Debug.Log("Shooting");
        private void ReadBlockAction(InputAction.CallbackContext value) => Debug.Log("Blocking");
        private void ReadDrinkAction(InputAction.CallbackContext value) => Debug.Log("Drinking");
    }
}
