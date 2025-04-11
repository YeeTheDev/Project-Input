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
        InputActionMap currentMap;
        InputAction moveAction;

        public float XAxis => moveAction.ReadValue<float>();

        public InputAction JumpAction { get; private set; }
        public InputAction MeleeAction { get; private set; }
        public InputAction ShootAction { get; private set; }
        public InputAction BlockAction { get; private set; }
        public InputAction DrinkAction { get; private set; }

        public void FindActionMapAndActions()
        {
            basicMap = playerInput.actions.FindActionMap(basicMapBame);
            currentMap = basicMap;

            moveAction = playerInput.actions.FindAction(moveActionName);
            JumpAction = playerInput.actions.FindAction(jumpActionName);
            MeleeAction = playerInput.actions.FindAction(meleeActionName);
            ShootAction = playerInput.actions.FindAction(shootActionName);
            BlockAction = playerInput.actions.FindAction(blockActionName);
            DrinkAction = playerInput.actions.FindAction(drinkActionName);
        }

        public void SetEnableMap(bool enable)
        {
            if (enable) { currentMap.Enable(); }
            else { currentMap.Disable(); }
        }
    }
}
