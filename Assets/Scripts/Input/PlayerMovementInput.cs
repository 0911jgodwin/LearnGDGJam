using UnityEngine;
using UnityEngine.InputSystem;

namespace Learn.PlayerController
{
    [DefaultExecutionOrder(-2)]
    public class PlayerMovementInput : MonoBehaviour, PlayerControls.IPlayerMovementMapActions
    {
        public PlayerControls PlayerControls { get; private set; }
        public Camera PlayerCamera;
        public Vector2 MovementInput { get; private set; }
        public Vector2 AimInput { get; private set; }
        public bool JumpPressed { get; private set; }
        public bool JumpHeld { get; private set; }
        public bool DashPressed { get; private set; }
        public bool ShootPressed { get; private set; }
        public bool ShootHeld { get; private set; }

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
            ShootPressed = false;
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
            //DashPressed = true;
        }

        public void OnMenu(InputAction.CallbackContext context)
        {
            if (!context.performed)
                return;
            PlayerInputManager.Instance.PlayerControls.PlayerMovementMap.Disable();
            PlayerInputManager.Instance.PlayerControls.MenuMap.Enable();
        }

        public void OnAim(InputAction.CallbackContext context)
        {
            if (!context.performed)
                return;
            AimInput = context.ReadValue<Vector2>();
        }

        public void OnMouseAim(InputAction.CallbackContext context)
        {
            if (!context.performed)
                return;
            Vector2 worldPos = PlayerCamera.ScreenToWorldPoint(context.ReadValue<Vector2>());
            AimInput = new Vector3(worldPos.x, worldPos.y, 0) - transform.position;
        }

        public void OnShoot(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                ShootPressed = true;
                ShootHeld = true;
            }
            else if (context.canceled)
            {
                ShootHeld = false;
            }
        }
    }
}