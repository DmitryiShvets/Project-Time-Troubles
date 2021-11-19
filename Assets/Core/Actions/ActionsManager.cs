// GENERATED AUTOMATICALLY FROM 'Assets/Core/Actions/ActionsManager.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Core.Actions
{
    public class @ActionsManager : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @ActionsManager()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""ActionsManager"",
    ""maps"": [
        {
            ""name"": ""Ui"",
            ""id"": ""27c7905f-df1c-43ff-be79-f2f7eb8bbe3c"",
            ""actions"": [
                {
                    ""name"": ""PauseGame"",
                    ""type"": ""Button"",
                    ""id"": ""96ada148-f0be-4467-9538-7a342d6b2577"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PressAdd"",
                    ""type"": ""PassThrough"",
                    ""id"": ""aec639f8-28d9-4afc-9ce5-e08854e51ca4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PressRem"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b218ab6d-ef37-4063-9f27-311b65cfcc11"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""47f16405-3b06-4fae-ac2d-797bb29e554f"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7a0c106-a237-4cf4-a23b-a0fc7767509c"",
                    ""path"": ""<Keyboard>/numpadPlus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PressAdd"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""17186f10-f1dd-42f4-a6f0-9734c772fc6b"",
                    ""path"": ""<Keyboard>/minus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PressRem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player"",
            ""id"": ""adc9711a-c893-44dc-9185-cee5e8987fff"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""ded0eba1-6610-4732-b90d-a8ef377bb53b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""4bda4c8d-221c-4798-b0e8-8ba4ba99567e"",
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
                    ""id"": ""847ffd07-6a8e-47c7-8356-ee495b3446a6"",
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
                    ""id"": ""729cb991-d1ed-47a1-9385-2b9c214ff551"",
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
                    ""id"": ""616c957c-f011-415e-b5eb-3157206a2904"",
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
                    ""id"": ""4d6c4918-3a89-4aa2-884e-7070aa3f8bea"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Ui
            m_Ui = asset.FindActionMap("Ui", throwIfNotFound: true);
            m_Ui_PauseGame = m_Ui.FindAction("PauseGame", throwIfNotFound: true);
            m_Ui_PressAdd = m_Ui.FindAction("PressAdd", throwIfNotFound: true);
            m_Ui_PressRem = m_Ui.FindAction("PressRem", throwIfNotFound: true);
            // Player
            m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
            m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
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

        // Ui
        private readonly InputActionMap m_Ui;
        private IUiActions m_UiActionsCallbackInterface;
        private readonly InputAction m_Ui_PauseGame;
        private readonly InputAction m_Ui_PressAdd;
        private readonly InputAction m_Ui_PressRem;
        public struct UiActions
        {
            private @ActionsManager m_Wrapper;
            public UiActions(@ActionsManager wrapper) { m_Wrapper = wrapper; }
            public InputAction @PauseGame => m_Wrapper.m_Ui_PauseGame;
            public InputAction @PressAdd => m_Wrapper.m_Ui_PressAdd;
            public InputAction @PressRem => m_Wrapper.m_Ui_PressRem;
            public InputActionMap Get() { return m_Wrapper.m_Ui; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(UiActions set) { return set.Get(); }
            public void SetCallbacks(IUiActions instance)
            {
                if (m_Wrapper.m_UiActionsCallbackInterface != null)
                {
                    @PauseGame.started -= m_Wrapper.m_UiActionsCallbackInterface.OnPauseGame;
                    @PauseGame.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnPauseGame;
                    @PauseGame.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnPauseGame;
                    @PressAdd.started -= m_Wrapper.m_UiActionsCallbackInterface.OnPressAdd;
                    @PressAdd.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnPressAdd;
                    @PressAdd.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnPressAdd;
                    @PressRem.started -= m_Wrapper.m_UiActionsCallbackInterface.OnPressRem;
                    @PressRem.performed -= m_Wrapper.m_UiActionsCallbackInterface.OnPressRem;
                    @PressRem.canceled -= m_Wrapper.m_UiActionsCallbackInterface.OnPressRem;
                }
                m_Wrapper.m_UiActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @PauseGame.started += instance.OnPauseGame;
                    @PauseGame.performed += instance.OnPauseGame;
                    @PauseGame.canceled += instance.OnPauseGame;
                    @PressAdd.started += instance.OnPressAdd;
                    @PressAdd.performed += instance.OnPressAdd;
                    @PressAdd.canceled += instance.OnPressAdd;
                    @PressRem.started += instance.OnPressRem;
                    @PressRem.performed += instance.OnPressRem;
                    @PressRem.canceled += instance.OnPressRem;
                }
            }
        }
        public UiActions @Ui => new UiActions(this);

        // Player
        private readonly InputActionMap m_Player;
        private IPlayerActions m_PlayerActionsCallbackInterface;
        private readonly InputAction m_Player_Movement;
        public struct PlayerActions
        {
            private @ActionsManager m_Wrapper;
            public PlayerActions(@ActionsManager wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_Player_Movement;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                }
                m_Wrapper.m_PlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                }
            }
        }
        public PlayerActions @Player => new PlayerActions(this);
        public interface IUiActions
        {
            void OnPauseGame(InputAction.CallbackContext context);
            void OnPressAdd(InputAction.CallbackContext context);
            void OnPressRem(InputAction.CallbackContext context);
        }
        public interface IPlayerActions
        {
            void OnMovement(InputAction.CallbackContext context);
        }
    }
}
