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
        public bool OptionsOpen = false;


        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                //Destroy(gameObject);
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

        public MenuInput GetMenuInput()
        {
            return GetComponent<MenuInput>();
        }
    }
}

