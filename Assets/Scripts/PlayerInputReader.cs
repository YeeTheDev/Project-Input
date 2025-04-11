using UnityEngine;
using UnityEngine.InputSystem;
using PI.Controllers;

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
        
        PlayerController playerController;

        public float XAxis => moveAction.ReadValue<float>();

        private void Awake() => playerController = GetComponent<PlayerController>();

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
            jumpAction.performed += playerController.ReadJumpPerformedAction;
            jumpAction.canceled += playerController.ReadJumpCanceledAction;
            meleeAction.performed += playerController.ReadMeleeAction;
            shootAction.performed += playerController.ReadShootAction;
            blockAction.performed += playerController.ReadBlockAction;
            drinkAction.performed += playerController.ReadDrinkAction;
        }

        private void OnDisable()
        {
            UnsubscribeActions();

            basicMap.Disable();
        }

        private void UnsubscribeActions()
        {
            jumpAction.performed -= playerController.ReadJumpPerformedAction;
            jumpAction.canceled -= playerController.ReadJumpCanceledAction;
            meleeAction.performed -= playerController.ReadMeleeAction;
            shootAction.performed -= playerController.ReadShootAction;
            blockAction.performed -= playerController.ReadBlockAction;
            drinkAction.performed -= playerController.ReadDrinkAction;
        }
    }
}
