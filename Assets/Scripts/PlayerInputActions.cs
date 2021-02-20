// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerControlsMap.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace RedstoneHallows
{
    public class @PlayerInputActions : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControlsMap"",
    ""maps"": [
        {
            ""name"": ""General"",
            ""id"": ""4795acb1-68fe-40a0-bc06-e2b609227491"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""c70603c6-3219-42fb-8c51-aeb25a2e84e8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""3e140e50-ca39-4118-8704-58019d6d5281"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""269eaaf4-d3d9-4419-8a24-379b45ffbc42"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9623c29c-5287-415b-8bd9-fbe3a25c7813"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""49cd6563-d38d-4aa0-99e9-497bc680fdcb"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2b3d81c6-0fa0-4380-b4e1-f033da8c193d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // General
            m_General = asset.FindActionMap("General", throwIfNotFound: true);
            m_General_Move = m_General.FindAction("Move", throwIfNotFound: true);
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

        // General
        private readonly InputActionMap m_General;
        private IGeneralActions m_GeneralActionsCallbackInterface;
        private readonly InputAction m_General_Move;
        public struct GeneralActions
        {
            private @PlayerInputActions m_Wrapper;
            public GeneralActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_General_Move;
            public InputActionMap Get() { return m_Wrapper.m_General; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GeneralActions set) { return set.Get(); }
            public void SetCallbacks(IGeneralActions instance)
            {
                if (m_Wrapper.m_GeneralActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnMove;
                }
                m_Wrapper.m_GeneralActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                }
            }
        }
        public GeneralActions @General => new GeneralActions(this);
        public interface IGeneralActions
        {
            void OnMove(InputAction.CallbackContext context);
        }
    }
}
