using UnityEngine;
using UnityEngine.InputSystem;

namespace Learn.PlayerController
{
    [DefaultExecutionOrder(-2)]
    public class MenuInput : MonoBehaviour, PlayerControls.IMenuMapActions
    {
        public Vector2 NavigationInput { get; private set; }
        public bool SelectPressed { get; private set; }
        public bool ReturnPressed { get; private set; }

        private void OnEnable()
        {
            if (PlayerInputManager.Instance?.PlayerControls == null)
            {
                Debug.LogError("Player controls is not initialized - cannot enable");
                return;
            }

            PlayerInputManager.Instance.PlayerControls.MenuMap.Enable();
            PlayerInputManager.Instance.PlayerControls.MenuMap.SetCallbacks(this);
        }

        private void OnDisable()
        {
            if (PlayerInputManager.Instance?.PlayerControls == null)
            {
                Debug.LogError("Player controls is not initialized - cannot disable");
                return;
            }

            PlayerInputManager.Instance.PlayerControls.MenuMap.Disable();
            PlayerInputManager.Instance.PlayerControls.MenuMap.RemoveCallbacks(this);
        }

        private void LateUpdate()
        {
            SelectPressed = false;
            ReturnPressed = false;
        }

        public void Reenable()
        {
            PlayerInputManager.Instance.PlayerControls.MenuMap.Enable();
            PlayerInputManager.Instance.PlayerControls.MenuMap.SetCallbacks(this);
        }

        public void OnSelect(InputAction.CallbackContext context)
        {
            if (!context.performed)
                return;
            SelectPressed = true;
        }

        public void OnNavigate(InputAction.CallbackContext context)
        {
            NavigationInput = context.ReadValue<Vector2>();
        }

        public void OnReturn(InputAction.CallbackContext context)
        {
            if (!context.performed)
                return;
            ReturnPressed = true;
        }
    }
}
