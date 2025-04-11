using UnityEngine;

namespace PI.StateMachines
{
    public class PlayerStateMachine : MonoBehaviour
    {
        [SerializeField] PlayerStates initialState;

        public PlayerStates CurrentState { get; set; }

        private void Awake()
        {
            CurrentState = initialState;
        }
    }
}