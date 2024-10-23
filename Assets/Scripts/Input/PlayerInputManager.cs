using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Learn.PlayerController
{
    [DefaultExecutionOrder(-3)]
    public class PlayerInputManager : MonoBehaviour
    {
        public static PlayerInputManager Instance;
        public PlayerControls PlayerControls {  get; private set; }

        public InputActionMap CurrentActionMap { get; private set; }
        public static event Action<InputActionMap> _actionMapChange;


        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void OnEnable()
        {
            PlayerControls = new PlayerControls();
            PlayerControls.Enable();
        }

        private void OnDisable()
        {
            PlayerControls.Disable();
        }
    }
}

