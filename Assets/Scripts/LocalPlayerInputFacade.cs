
using RedstoneHallows.Commands;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RedstoneHallows
{
    public class LocalPlayerInputFacade : MonoBehaviour
    {

        [SerializeField] MoveCommand _moveCommand;
        private PlayerInputActions _inputMap;

        private void Awake()
        {
            _inputMap = new PlayerInputActions();
            SubscribeToActions();
        }


        public void OnMoveAction(InputAction.CallbackContext context)
        {
            var vectorVal = context.ReadValue<Vector2>().normalized;
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
            _inputMap.General.Move.performed += OnMoveAction;
            _inputMap.General.Move.canceled += OnMoveAction;
        }

        private void UnsubscribeFromActions()
        {
            // Unsubscriptions
            _inputMap.General.Move.performed -= OnMoveAction;
            _inputMap.General.Move.canceled -= OnMoveAction;

            // Disable must come after unsubscribing
            _inputMap.Disable();
        }
    }
}