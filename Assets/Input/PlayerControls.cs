//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/Input/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Learn.PlayerController
{
    public partial class @PlayerControls: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""PlayerMovementMap"",
            ""id"": ""5887daae-9ceb-4c27-85f8-bff74acb96a9"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""ba372de7-d450-42ee-a792-a24a32e94541"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""bfceb231-cce2-424f-85c8-a1f6f0373a83"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""60683cc6-c712-4981-96eb-f30390d6fcf5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""66bc413f-1128-4c9a-9547-daf1334400e5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MouseAim"",
                    ""type"": ""Value"",
                    ""id"": ""60e7d936-6e98-42f2-a9a4-82e03df0f78e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""b5d1f318-f2a8-4e7e-8bc7-c135caccb0ca"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""aba670f0-c510-4c38-b0d0-b8510302a45c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""5ca5f907-f830-431b-9bd7-1079fcd28d6a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7413e83d-d764-480d-912b-df5298e5d473"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1d562041-a4c0-4c02-b21e-670f848dc9b8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ba75d920-110a-4116-81b1-db39e22316c5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9d1353b9-6098-466d-b696-8454abb6e0a0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left Stick"",
                    ""id"": ""84d93fde-f3c8-4065-b90c-91072c7cfc3b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""24e7b325-68e3-4622-b826-d300eb54ac60"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""dc0f317f-6b54-4a47-a432-4167e4118be6"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""756371d9-76f9-49f9-9921-e444bfbec649"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ced42ff1-1fcd-418a-a36d-c2db771655fa"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4af8e66c-e3cd-4bfb-8edf-62dba1c0de8d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c805caed-db52-479f-9f7b-5db5162c2d09"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c5a4a38-41d4-47b3-bd6a-67454e19e0b5"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""59e12e8b-8df3-4d69-9ee4-ac51d336bdd3"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05893380-6364-4f6e-9aef-7b84b19f078b"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d349477-83fc-4fbe-a0ed-dcb8d3b9fd50"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseAim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0a0c6de0-ef8b-4388-92a2-473775f29900"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35ede1cd-8b6f-4922-8914-0b407f971324"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3676a5a9-8105-4a95-8cdd-013c7c53bbab"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1434aaf3-7ba5-4e2b-bbe0-70fd6042b313"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MenuMap"",
            ""id"": ""1680c763-c499-48aa-8c5a-463b95f53353"",
            ""actions"": [
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""6ea4ba97-58d6-41b9-805c-84c789820543"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""422e2a55-d708-45f9-9982-c1f7d2265144"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Return"",
                    ""type"": ""Button"",
                    ""id"": ""4da1516e-44b4-4959-806c-25b995258d31"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""91993467-62c8-4be5-9a3b-77a1ec904f2f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""58b40b61-e0ce-41b8-ad40-9304d5bcb284"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""515ce082-6d87-49f1-839d-1f78618dff3b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""29e0df7f-625a-408d-a3c6-67633ebe0cd2"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""79c3df4c-2a05-4722-b8d3-3d896c12aaba"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ec5ef4d5-b1a4-4ce3-8a11-52c131489428"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""016c1fdf-0c0d-40ac-b306-f817ca8fd680"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left Stick"",
                    ""id"": ""3c1d59cb-cdec-4ede-88fc-572c544a78c3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ec6f4601-0a6a-4a9e-8713-d7ba0731ea4f"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f0a479ed-f00d-4bc9-9229-c692e7ed9bd0"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ad5c86a4-1680-4080-9bc1-01f73d4fe28a"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""89b600ce-2d9d-431e-a7df-53244ca4b2b8"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2771c273-c157-4f6f-910e-a65088943e7c"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Return"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1af4019-da59-4367-86bb-ece677250b61"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Return"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // PlayerMovementMap
            m_PlayerMovementMap = asset.FindActionMap("PlayerMovementMap", throwIfNotFound: true);
            m_PlayerMovementMap_Movement = m_PlayerMovementMap.FindAction("Movement", throwIfNotFound: true);
            m_PlayerMovementMap_Jump = m_PlayerMovementMap.FindAction("Jump", throwIfNotFound: true);
            m_PlayerMovementMap_Menu = m_PlayerMovementMap.FindAction("Menu", throwIfNotFound: true);
            m_PlayerMovementMap_Aim = m_PlayerMovementMap.FindAction("Aim", throwIfNotFound: true);
            m_PlayerMovementMap_MouseAim = m_PlayerMovementMap.FindAction("MouseAim", throwIfNotFound: true);
            m_PlayerMovementMap_Shoot = m_PlayerMovementMap.FindAction("Shoot", throwIfNotFound: true);
            m_PlayerMovementMap_Submit = m_PlayerMovementMap.FindAction("Submit", throwIfNotFound: true);
            // MenuMap
            m_MenuMap = asset.FindActionMap("MenuMap", throwIfNotFound: true);
            m_MenuMap_Select = m_MenuMap.FindAction("Select", throwIfNotFound: true);
            m_MenuMap_Navigate = m_MenuMap.FindAction("Navigate", throwIfNotFound: true);
            m_MenuMap_Return = m_MenuMap.FindAction("Return", throwIfNotFound: true);
        }

        ~@PlayerControls()
        {
            UnityEngine.Debug.Assert(!m_PlayerMovementMap.enabled, "This will cause a leak and performance issues, PlayerControls.PlayerMovementMap.Disable() has not been called.");
            UnityEngine.Debug.Assert(!m_MenuMap.enabled, "This will cause a leak and performance issues, PlayerControls.MenuMap.Disable() has not been called.");
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }

        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // PlayerMovementMap
        private readonly InputActionMap m_PlayerMovementMap;
        private List<IPlayerMovementMapActions> m_PlayerMovementMapActionsCallbackInterfaces = new List<IPlayerMovementMapActions>();
        private readonly InputAction m_PlayerMovementMap_Movement;
        private readonly InputAction m_PlayerMovementMap_Jump;
        private readonly InputAction m_PlayerMovementMap_Menu;
        private readonly InputAction m_PlayerMovementMap_Aim;
        private readonly InputAction m_PlayerMovementMap_MouseAim;
        private readonly InputAction m_PlayerMovementMap_Shoot;
        private readonly InputAction m_PlayerMovementMap_Submit;
        public struct PlayerMovementMapActions
        {
            private @PlayerControls m_Wrapper;
            public PlayerMovementMapActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_PlayerMovementMap_Movement;
            public InputAction @Jump => m_Wrapper.m_PlayerMovementMap_Jump;
            public InputAction @Menu => m_Wrapper.m_PlayerMovementMap_Menu;
            public InputAction @Aim => m_Wrapper.m_PlayerMovementMap_Aim;
            public InputAction @MouseAim => m_Wrapper.m_PlayerMovementMap_MouseAim;
            public InputAction @Shoot => m_Wrapper.m_PlayerMovementMap_Shoot;
            public InputAction @Submit => m_Wrapper.m_PlayerMovementMap_Submit;
            public InputActionMap Get() { return m_Wrapper.m_PlayerMovementMap; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerMovementMapActions set) { return set.Get(); }
            public void AddCallbacks(IPlayerMovementMapActions instance)
            {
                if (instance == null || m_Wrapper.m_PlayerMovementMapActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_PlayerMovementMapActionsCallbackInterfaces.Add(instance);
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Menu.started += instance.OnMenu;
                @Menu.performed += instance.OnMenu;
                @Menu.canceled += instance.OnMenu;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @MouseAim.started += instance.OnMouseAim;
                @MouseAim.performed += instance.OnMouseAim;
                @MouseAim.canceled += instance.OnMouseAim;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
            }

            private void UnregisterCallbacks(IPlayerMovementMapActions instance)
            {
                @Movement.started -= instance.OnMovement;
                @Movement.performed -= instance.OnMovement;
                @Movement.canceled -= instance.OnMovement;
                @Jump.started -= instance.OnJump;
                @Jump.performed -= instance.OnJump;
                @Jump.canceled -= instance.OnJump;
                @Menu.started -= instance.OnMenu;
                @Menu.performed -= instance.OnMenu;
                @Menu.canceled -= instance.OnMenu;
                @Aim.started -= instance.OnAim;
                @Aim.performed -= instance.OnAim;
                @Aim.canceled -= instance.OnAim;
                @MouseAim.started -= instance.OnMouseAim;
                @MouseAim.performed -= instance.OnMouseAim;
                @MouseAim.canceled -= instance.OnMouseAim;
                @Shoot.started -= instance.OnShoot;
                @Shoot.performed -= instance.OnShoot;
                @Shoot.canceled -= instance.OnShoot;
                @Submit.started -= instance.OnSubmit;
                @Submit.performed -= instance.OnSubmit;
                @Submit.canceled -= instance.OnSubmit;
            }

            public void RemoveCallbacks(IPlayerMovementMapActions instance)
            {
                if (m_Wrapper.m_PlayerMovementMapActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IPlayerMovementMapActions instance)
            {
                foreach (var item in m_Wrapper.m_PlayerMovementMapActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_PlayerMovementMapActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public PlayerMovementMapActions @PlayerMovementMap => new PlayerMovementMapActions(this);

        // MenuMap
        private readonly InputActionMap m_MenuMap;
        private List<IMenuMapActions> m_MenuMapActionsCallbackInterfaces = new List<IMenuMapActions>();
        private readonly InputAction m_MenuMap_Select;
        private readonly InputAction m_MenuMap_Navigate;
        private readonly InputAction m_MenuMap_Return;
        public struct MenuMapActions
        {
            private @PlayerControls m_Wrapper;
            public MenuMapActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Select => m_Wrapper.m_MenuMap_Select;
            public InputAction @Navigate => m_Wrapper.m_MenuMap_Navigate;
            public InputAction @Return => m_Wrapper.m_MenuMap_Return;
            public InputActionMap Get() { return m_Wrapper.m_MenuMap; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MenuMapActions set) { return set.Get(); }
            public void AddCallbacks(IMenuMapActions instance)
            {
                if (instance == null || m_Wrapper.m_MenuMapActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_MenuMapActionsCallbackInterfaces.Add(instance);
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
                @Return.started += instance.OnReturn;
                @Return.performed += instance.OnReturn;
                @Return.canceled += instance.OnReturn;
            }

            private void UnregisterCallbacks(IMenuMapActions instance)
            {
                @Select.started -= instance.OnSelect;
                @Select.performed -= instance.OnSelect;
                @Select.canceled -= instance.OnSelect;
                @Navigate.started -= instance.OnNavigate;
                @Navigate.performed -= instance.OnNavigate;
                @Navigate.canceled -= instance.OnNavigate;
                @Return.started -= instance.OnReturn;
                @Return.performed -= instance.OnReturn;
                @Return.canceled -= instance.OnReturn;
            }

            public void RemoveCallbacks(IMenuMapActions instance)
            {
                if (m_Wrapper.m_MenuMapActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IMenuMapActions instance)
            {
                foreach (var item in m_Wrapper.m_MenuMapActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_MenuMapActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public MenuMapActions @MenuMap => new MenuMapActions(this);
        public interface IPlayerMovementMapActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnMenu(InputAction.CallbackContext context);
            void OnAim(InputAction.CallbackContext context);
            void OnMouseAim(InputAction.CallbackContext context);
            void OnShoot(InputAction.CallbackContext context);
            void OnSubmit(InputAction.CallbackContext context);
        }
        public interface IMenuMapActions
        {
            void OnSelect(InputAction.CallbackContext context);
            void OnNavigate(InputAction.CallbackContext context);
            void OnReturn(InputAction.CallbackContext context);
        }
    }
}
