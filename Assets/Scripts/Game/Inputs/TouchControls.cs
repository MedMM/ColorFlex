// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Game/Inputs/TouchControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Game.Inputs
{
    public class @TouchControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @TouchControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""TouchControls"",
    ""maps"": [
        {
            ""name"": ""Touch"",
            ""id"": ""bbd9c301-cf27-42e2-bff0-686b0d39e5a2"",
            ""actions"": [
                {
                    ""name"": ""TouchInput"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1367002e-9850-4a1f-8596-12f5c4e0a178"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchPress"",
                    ""type"": ""Button"",
                    ""id"": ""f65f2d3a-0f51-4851-821a-e026c7d84be3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""TouchDrag"",
                    ""type"": ""Value"",
                    ""id"": ""8ca4c713-7a25-4937-a6ca-d53e5b694769"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""dfe89f47-7799-4a99-be03-c023d3510b15"",
                    ""path"": ""<Touchscreen>/primaryTouch"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""824f2a4a-e15c-4e9b-98d2-866631c2e9eb"",
                    ""path"": ""<Touchscreen>/primaryTouch/tap"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f46b71c-fdea-45be-8b9d-fc3f5dd1fc4a"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchDrag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Swipe"",
            ""id"": ""55d4e7b4-6882-464b-be9c-005a51d98a13"",
            ""actions"": [
                {
                    ""name"": ""PrimaryContact"",
                    ""type"": ""PassThrough"",
                    ""id"": ""18b76918-c381-4d53-b3f0-36fb4bd3fc59"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""PrimaryPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a77c4d90-18c7-459b-aa7f-e3a2672fe332"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c5764924-ad66-4c32-adf3-dc33b9210a07"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryContact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a82065f9-083f-44aa-a144-bd0ba4984ed7"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Touch
            m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
            m_Touch_TouchInput = m_Touch.FindAction("TouchInput", throwIfNotFound: true);
            m_Touch_TouchPress = m_Touch.FindAction("TouchPress", throwIfNotFound: true);
            m_Touch_TouchDrag = m_Touch.FindAction("TouchDrag", throwIfNotFound: true);
            // Swipe
            m_Swipe = asset.FindActionMap("Swipe", throwIfNotFound: true);
            m_Swipe_PrimaryContact = m_Swipe.FindAction("PrimaryContact", throwIfNotFound: true);
            m_Swipe_PrimaryPosition = m_Swipe.FindAction("PrimaryPosition", throwIfNotFound: true);
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

        // Touch
        private readonly InputActionMap m_Touch;
        private ITouchActions m_TouchActionsCallbackInterface;
        private readonly InputAction m_Touch_TouchInput;
        private readonly InputAction m_Touch_TouchPress;
        private readonly InputAction m_Touch_TouchDrag;
        public struct TouchActions
        {
            private @TouchControls m_Wrapper;
            public TouchActions(@TouchControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @TouchInput => m_Wrapper.m_Touch_TouchInput;
            public InputAction @TouchPress => m_Wrapper.m_Touch_TouchPress;
            public InputAction @TouchDrag => m_Wrapper.m_Touch_TouchDrag;
            public InputActionMap Get() { return m_Wrapper.m_Touch; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(TouchActions set) { return set.Get(); }
            public void SetCallbacks(ITouchActions instance)
            {
                if (m_Wrapper.m_TouchActionsCallbackInterface != null)
                {
                    @TouchInput.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchInput;
                    @TouchInput.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchInput;
                    @TouchInput.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchInput;
                    @TouchPress.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPress;
                    @TouchPress.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPress;
                    @TouchPress.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPress;
                    @TouchDrag.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchDrag;
                    @TouchDrag.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchDrag;
                    @TouchDrag.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchDrag;
                }
                m_Wrapper.m_TouchActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @TouchInput.started += instance.OnTouchInput;
                    @TouchInput.performed += instance.OnTouchInput;
                    @TouchInput.canceled += instance.OnTouchInput;
                    @TouchPress.started += instance.OnTouchPress;
                    @TouchPress.performed += instance.OnTouchPress;
                    @TouchPress.canceled += instance.OnTouchPress;
                    @TouchDrag.started += instance.OnTouchDrag;
                    @TouchDrag.performed += instance.OnTouchDrag;
                    @TouchDrag.canceled += instance.OnTouchDrag;
                }
            }
        }
        public TouchActions @Touch => new TouchActions(this);

        // Swipe
        private readonly InputActionMap m_Swipe;
        private ISwipeActions m_SwipeActionsCallbackInterface;
        private readonly InputAction m_Swipe_PrimaryContact;
        private readonly InputAction m_Swipe_PrimaryPosition;
        public struct SwipeActions
        {
            private @TouchControls m_Wrapper;
            public SwipeActions(@TouchControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @PrimaryContact => m_Wrapper.m_Swipe_PrimaryContact;
            public InputAction @PrimaryPosition => m_Wrapper.m_Swipe_PrimaryPosition;
            public InputActionMap Get() { return m_Wrapper.m_Swipe; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(SwipeActions set) { return set.Get(); }
            public void SetCallbacks(ISwipeActions instance)
            {
                if (m_Wrapper.m_SwipeActionsCallbackInterface != null)
                {
                    @PrimaryContact.started -= m_Wrapper.m_SwipeActionsCallbackInterface.OnPrimaryContact;
                    @PrimaryContact.performed -= m_Wrapper.m_SwipeActionsCallbackInterface.OnPrimaryContact;
                    @PrimaryContact.canceled -= m_Wrapper.m_SwipeActionsCallbackInterface.OnPrimaryContact;
                    @PrimaryPosition.started -= m_Wrapper.m_SwipeActionsCallbackInterface.OnPrimaryPosition;
                    @PrimaryPosition.performed -= m_Wrapper.m_SwipeActionsCallbackInterface.OnPrimaryPosition;
                    @PrimaryPosition.canceled -= m_Wrapper.m_SwipeActionsCallbackInterface.OnPrimaryPosition;
                }
                m_Wrapper.m_SwipeActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @PrimaryContact.started += instance.OnPrimaryContact;
                    @PrimaryContact.performed += instance.OnPrimaryContact;
                    @PrimaryContact.canceled += instance.OnPrimaryContact;
                    @PrimaryPosition.started += instance.OnPrimaryPosition;
                    @PrimaryPosition.performed += instance.OnPrimaryPosition;
                    @PrimaryPosition.canceled += instance.OnPrimaryPosition;
                }
            }
        }
        public SwipeActions @Swipe => new SwipeActions(this);
        public interface ITouchActions
        {
            void OnTouchInput(InputAction.CallbackContext context);
            void OnTouchPress(InputAction.CallbackContext context);
            void OnTouchDrag(InputAction.CallbackContext context);
        }
        public interface ISwipeActions
        {
            void OnPrimaryContact(InputAction.CallbackContext context);
            void OnPrimaryPosition(InputAction.CallbackContext context);
        }
    }
}
