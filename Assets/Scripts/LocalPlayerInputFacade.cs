
using RedstoneHallows.Commands;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RedstoneHallows
{
    public class LocalPlayerInputFacade : MonoBehaviour
    {

        [SerializeField] MoveCommand _moveCommand;
        private JitterProblems _inputMap;

        private void Awake()
        {
            _inputMap = new JitterProblems();
            SubscribeToActions();
        }


        public void OnMoveAction(InputAction.CallbackContext context)
        {
            var vectorVal = context.ReadValue<Vector2>();
            _moveCommand.LocalExecute(vectorVal);
        }


        void OnDisable()
        {
            UnsubscribeFromActions();
        }

        private void SubscribeToActions()
        {
            // Enable must come before subscribing
            _inputMap.Enable();

            // Subscriptions
            _inputMap.Player.Move.performed += OnMoveAction;
            _inputMap.Player.Move.canceled += OnMoveAction;
        }

        private void UnsubscribeFromActions()
        {
            // Unsubscriptions
            _inputMap.Player.Move.performed -= OnMoveAction;
            _inputMap.Player.Move.canceled -= OnMoveAction;

            // Disable must come after unsubscribing
            _inputMap.Disable();
        }
    }
}