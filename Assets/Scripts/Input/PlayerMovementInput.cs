using UnityEngine;
using UnityEngine.InputSystem;

namespace Learn.PlayerController
{
    [DefaultExecutionOrder(-2)]
    public class PlayerMovementInput : MonoBehaviour, PlayerControls.IPlayerMovementMapActions
    {
        public PlayerControls PlayerControls { get; private set; }
        public Vector2 MovementInput { get; private set; }
        public bool JumpPressed { get; private set; }
        public bool JumpHeld { get; private set; }
        public bool DashPressed { get; private set; }

        private void OnEnable()
        {
            if (PlayerInputManager.Instance?.PlayerControls == null)
            {
                Debug.LogError("Player controls is not initialized - cannot enable");
                return;
            }

            PlayerInputManager.Instance.PlayerControls.PlayerMovementMap.Enable();
            PlayerInputManager.Instance.PlayerControls.PlayerMovementMap.SetCallbacks(this);
        }

        private void OnDisable()
        {
            if (PlayerInputManager.Instance?.PlayerControls == null)
            {
                Debug.LogError("Player controls is not initialized - cannot disable");
                return;
            }

            PlayerInputManager.Instance.PlayerControls.PlayerMovementMap.Disable();
            PlayerInputManager.Instance.PlayerControls.PlayerMovementMap.RemoveCallbacks(this);
        }

        private void LateUpdate()
        {
            JumpPressed = false;
            DashPressed = false;
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            MovementInput = context.ReadValue<Vector2>();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                JumpPressed = true;
                JumpHeld = true;
            }
            else if (context.canceled) {
                JumpHeld = false;
            }
        }

        public void OnDash(InputAction.CallbackContext context)
        {
            if (!context.performed)
                return;
            DashPressed = true;
        }

        public void OnMenu(InputAction.CallbackContext context)
        {
            if (!context.performed)
                return;
            PlayerInputManager.Instance.PlayerControls.PlayerMovementMap.Disable();
            PlayerInputManager.Instance.PlayerControls.MenuMap.Enable();
        }
    }
}