// GENERATED AUTOMATICALLY FROM 'Assets/Player_Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Control_Map : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Control_Map()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player_Controls"",
    ""maps"": [
        {
            ""name"": ""PSX_Controller"",
            ""id"": ""e3ed06ef-b373-4835-8f82-2778b0932e9b"",
            ""actions"": [
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""d0476059-84a4-4191-8d3b-12974b6dd71b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""f28cac1c-fcf4-4121-9251-17698e6f09a0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveUp"",
                    ""type"": ""Button"",
                    ""id"": ""cbfcaed1-b6d9-435b-9a91-794322b88b6a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveDown"",
                    ""type"": ""Button"",
                    ""id"": ""ed8286f0-ced6-47de-bcec-602f08bf913d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CamLeft"",
                    ""type"": ""Button"",
                    ""id"": ""f6250763-8640-4d7a-a66c-ccb5f22dbe62"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CamRight"",
                    ""type"": ""Button"",
                    ""id"": ""27753277-b426-4225-b363-1f42526f8258"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump_Fly"",
                    ""type"": ""Button"",
                    ""id"": ""b20b6d2b-4f24-4e41-9839-a08cdb4a5606"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Vehicle"",
                    ""type"": ""Button"",
                    ""id"": ""b3051d6b-3136-4610-82b2-09356f36f511"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sword"",
                    ""type"": ""Button"",
                    ""id"": ""4108673f-99dd-43d3-b7fb-b2dc22bf3e11"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""0a45f834-a371-4954-9eac-5c6ce9728c98"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Menu/Pause"",
                    ""type"": ""Button"",
                    ""id"": ""085373b1-0557-444f-8da2-44947f86360d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Phone"",
                    ""type"": ""Button"",
                    ""id"": ""e93e4a79-0acc-4f83-a650-4219d25fe960"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CamLeft2"",
                    ""type"": ""Button"",
                    ""id"": ""befa54a6-f22e-4f76-8c23-7fe98444e7c1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CamRight2"",
                    ""type"": ""Button"",
                    ""id"": ""50f5ff19-b94c-4203-ae2f-7f1cf08458f4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DEBUG"",
                    ""type"": ""Button"",
                    ""id"": ""3491ef9e-2263-4139-95be-1b45be703962"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d92c9a1d-6412-4177-a2bc-c55867e2d7ab"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c3c4e004-07fb-4f71-a2ba-0fee20b449cd"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67a94e98-16f9-458b-b08f-758fbcc139b0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f3ae64e8-4e1f-43ce-ae0f-95a4254719d4"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0aeb7f76-e3ac-4652-8c62-ecc62ede5903"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c03ad572-7485-485e-b85a-33f1e18ab799"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d87cf76b-e4a8-4f77-bb13-f0e884877198"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""64b18bb9-7aa6-425d-9373-265cf853c4a3"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fd2ccce3-1c84-4577-802f-50c101e2af59"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump_Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36247ac0-5dae-4239-b7ef-ad297aab0eab"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump_Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""622b3384-9b72-422b-8069-1d2a6e762ad9"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CamLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""91bef3dd-3a6c-437b-ae20-530699bcedd8"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CamLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4394ab89-1869-45c6-b09d-dd9dee0c8907"",
                    ""path"": ""<Keyboard>/n"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CamRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4fae49a0-a15b-4b6e-9ab3-3b0205dc6dfc"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CamRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dd5fe25a-3b01-4967-8143-ff58caa5524c"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vehicle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0c187e7-066d-47b6-a856-faca033d6fa9"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vehicle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""329ddc2d-dc66-4562-80fe-3ef3be6bcec0"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sword"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6ccf7f5-743c-435d-a3eb-35543a5be125"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sword"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4f26a95-cec0-4463-8c5f-9d4d84ac28e9"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88753c46-d9b8-45a7-9493-49b677ead8cb"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7c97411c-375c-4a1f-a1cd-096dc0e61a3d"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu/Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8085f42c-ef1d-4699-8452-e82868ca4122"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu/Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a138c82-f0ef-4a90-bdac-9b949072d281"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Phone"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""77a0efb7-cd06-4d1f-9f87-67bcc8d75d49"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Phone"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff1c96d9-387e-44f2-8787-1e70c9aec990"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CamLeft2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""53fb29de-e55b-4ec1-a998-2ea299e4daa0"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CamLeft2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b912932-80a9-4513-be47-4057f6437ec1"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CamRight2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1a037116-619f-4b62-88eb-a50d4699f5d3"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CamRight2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8398eb0b-6906-4902-bb7d-dcb6819c6658"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DEBUG"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PSX_Controller
        m_PSX_Controller = asset.FindActionMap("PSX_Controller", throwIfNotFound: true);
        m_PSX_Controller_MoveLeft = m_PSX_Controller.FindAction("MoveLeft", throwIfNotFound: true);
        m_PSX_Controller_MoveRight = m_PSX_Controller.FindAction("MoveRight", throwIfNotFound: true);
        m_PSX_Controller_MoveUp = m_PSX_Controller.FindAction("MoveUp", throwIfNotFound: true);
        m_PSX_Controller_MoveDown = m_PSX_Controller.FindAction("MoveDown", throwIfNotFound: true);
        m_PSX_Controller_CamLeft = m_PSX_Controller.FindAction("CamLeft", throwIfNotFound: true);
        m_PSX_Controller_CamRight = m_PSX_Controller.FindAction("CamRight", throwIfNotFound: true);
        m_PSX_Controller_Jump_Fly = m_PSX_Controller.FindAction("Jump_Fly", throwIfNotFound: true);
        m_PSX_Controller_Vehicle = m_PSX_Controller.FindAction("Vehicle", throwIfNotFound: true);
        m_PSX_Controller_Sword = m_PSX_Controller.FindAction("Sword", throwIfNotFound: true);
        m_PSX_Controller_Interact = m_PSX_Controller.FindAction("Interact", throwIfNotFound: true);
        m_PSX_Controller_MenuPause = m_PSX_Controller.FindAction("Menu/Pause", throwIfNotFound: true);
        m_PSX_Controller_Phone = m_PSX_Controller.FindAction("Phone", throwIfNotFound: true);
        m_PSX_Controller_CamLeft2 = m_PSX_Controller.FindAction("CamLeft2", throwIfNotFound: true);
        m_PSX_Controller_CamRight2 = m_PSX_Controller.FindAction("CamRight2", throwIfNotFound: true);
        m_PSX_Controller_DEBUG = m_PSX_Controller.FindAction("DEBUG", throwIfNotFound: true);
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

    // PSX_Controller
    private readonly InputActionMap m_PSX_Controller;
    private IPSX_ControllerActions m_PSX_ControllerActionsCallbackInterface;
    private readonly InputAction m_PSX_Controller_MoveLeft;
    private readonly InputAction m_PSX_Controller_MoveRight;
    private readonly InputAction m_PSX_Controller_MoveUp;
    private readonly InputAction m_PSX_Controller_MoveDown;
    private readonly InputAction m_PSX_Controller_CamLeft;
    private readonly InputAction m_PSX_Controller_CamRight;
    private readonly InputAction m_PSX_Controller_Jump_Fly;
    private readonly InputAction m_PSX_Controller_Vehicle;
    private readonly InputAction m_PSX_Controller_Sword;
    private readonly InputAction m_PSX_Controller_Interact;
    private readonly InputAction m_PSX_Controller_MenuPause;
    private readonly InputAction m_PSX_Controller_Phone;
    private readonly InputAction m_PSX_Controller_CamLeft2;
    private readonly InputAction m_PSX_Controller_CamRight2;
    private readonly InputAction m_PSX_Controller_DEBUG;
    public struct PSX_ControllerActions
    {
        private @Control_Map m_Wrapper;
        public PSX_ControllerActions(@Control_Map wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveLeft => m_Wrapper.m_PSX_Controller_MoveLeft;
        public InputAction @MoveRight => m_Wrapper.m_PSX_Controller_MoveRight;
        public InputAction @MoveUp => m_Wrapper.m_PSX_Controller_MoveUp;
        public InputAction @MoveDown => m_Wrapper.m_PSX_Controller_MoveDown;
        public InputAction @CamLeft => m_Wrapper.m_PSX_Controller_CamLeft;
        public InputAction @CamRight => m_Wrapper.m_PSX_Controller_CamRight;
        public InputAction @Jump_Fly => m_Wrapper.m_PSX_Controller_Jump_Fly;
        public InputAction @Vehicle => m_Wrapper.m_PSX_Controller_Vehicle;
        public InputAction @Sword => m_Wrapper.m_PSX_Controller_Sword;
        public InputAction @Interact => m_Wrapper.m_PSX_Controller_Interact;
        public InputAction @MenuPause => m_Wrapper.m_PSX_Controller_MenuPause;
        public InputAction @Phone => m_Wrapper.m_PSX_Controller_Phone;
        public InputAction @CamLeft2 => m_Wrapper.m_PSX_Controller_CamLeft2;
        public InputAction @CamRight2 => m_Wrapper.m_PSX_Controller_CamRight2;
        public InputAction @DEBUG => m_Wrapper.m_PSX_Controller_DEBUG;
        public InputActionMap Get() { return m_Wrapper.m_PSX_Controller; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PSX_ControllerActions set) { return set.Get(); }
        public void SetCallbacks(IPSX_ControllerActions instance)
        {
            if (m_Wrapper.m_PSX_ControllerActionsCallbackInterface != null)
            {
                @MoveLeft.started -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.performed -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.canceled -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnMoveLeft;
                @MoveRight.started -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnMoveRight;
                @MoveRight.performed -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnMoveRight;
                @MoveRight.canceled -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnMoveRight;
                @MoveUp.started -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnMoveUp;
                @MoveUp.performed -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnMoveUp;
                @MoveUp.canceled -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnMoveUp;
                @MoveDown.started -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnMoveDown;
                @MoveDown.performed -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnMoveDown;
                @MoveDown.canceled -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnMoveDown;
                @CamLeft.started -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnCamLeft;
                @CamLeft.performed -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnCamLeft;
                @CamLeft.canceled -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnCamLeft;
                @CamRight.started -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnCamRight;
                @CamRight.performed -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnCamRight;
                @CamRight.canceled -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnCamRight;
                @Jump_Fly.started -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnJump_Fly;
                @Jump_Fly.performed -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnJump_Fly;
                @Jump_Fly.canceled -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnJump_Fly;
                @Vehicle.started -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnVehicle;
                @Vehicle.performed -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnVehicle;
                @Vehicle.canceled -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnVehicle;
                @Sword.started -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnSword;
                @Sword.performed -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnSword;
                @Sword.canceled -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnSword;
                @Interact.started -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnInteract;
                @MenuPause.started -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnMenuPause;
                @MenuPause.performed -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnMenuPause;
                @MenuPause.canceled -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnMenuPause;
                @Phone.started -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnPhone;
                @Phone.performed -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnPhone;
                @Phone.canceled -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnPhone;
                @CamLeft2.started -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnCamLeft2;
                @CamLeft2.performed -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnCamLeft2;
                @CamLeft2.canceled -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnCamLeft2;
                @CamRight2.started -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnCamRight2;
                @CamRight2.performed -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnCamRight2;
                @CamRight2.canceled -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnCamRight2;
                @DEBUG.started -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnDEBUG;
                @DEBUG.performed -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnDEBUG;
                @DEBUG.canceled -= m_Wrapper.m_PSX_ControllerActionsCallbackInterface.OnDEBUG;
            }
            m_Wrapper.m_PSX_ControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveLeft.started += instance.OnMoveLeft;
                @MoveLeft.performed += instance.OnMoveLeft;
                @MoveLeft.canceled += instance.OnMoveLeft;
                @MoveRight.started += instance.OnMoveRight;
                @MoveRight.performed += instance.OnMoveRight;
                @MoveRight.canceled += instance.OnMoveRight;
                @MoveUp.started += instance.OnMoveUp;
                @MoveUp.performed += instance.OnMoveUp;
                @MoveUp.canceled += instance.OnMoveUp;
                @MoveDown.started += instance.OnMoveDown;
                @MoveDown.performed += instance.OnMoveDown;
                @MoveDown.canceled += instance.OnMoveDown;
                @CamLeft.started += instance.OnCamLeft;
                @CamLeft.performed += instance.OnCamLeft;
                @CamLeft.canceled += instance.OnCamLeft;
                @CamRight.started += instance.OnCamRight;
                @CamRight.performed += instance.OnCamRight;
                @CamRight.canceled += instance.OnCamRight;
                @Jump_Fly.started += instance.OnJump_Fly;
                @Jump_Fly.performed += instance.OnJump_Fly;
                @Jump_Fly.canceled += instance.OnJump_Fly;
                @Vehicle.started += instance.OnVehicle;
                @Vehicle.performed += instance.OnVehicle;
                @Vehicle.canceled += instance.OnVehicle;
                @Sword.started += instance.OnSword;
                @Sword.performed += instance.OnSword;
                @Sword.canceled += instance.OnSword;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @MenuPause.started += instance.OnMenuPause;
                @MenuPause.performed += instance.OnMenuPause;
                @MenuPause.canceled += instance.OnMenuPause;
                @Phone.started += instance.OnPhone;
                @Phone.performed += instance.OnPhone;
                @Phone.canceled += instance.OnPhone;
                @CamLeft2.started += instance.OnCamLeft2;
                @CamLeft2.performed += instance.OnCamLeft2;
                @CamLeft2.canceled += instance.OnCamLeft2;
                @CamRight2.started += instance.OnCamRight2;
                @CamRight2.performed += instance.OnCamRight2;
                @CamRight2.canceled += instance.OnCamRight2;
                @DEBUG.started += instance.OnDEBUG;
                @DEBUG.performed += instance.OnDEBUG;
                @DEBUG.canceled += instance.OnDEBUG;
            }
        }
    }
    public PSX_ControllerActions @PSX_Controller => new PSX_ControllerActions(this);
    public interface IPSX_ControllerActions
    {
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
        void OnMoveUp(InputAction.CallbackContext context);
        void OnMoveDown(InputAction.CallbackContext context);
        void OnCamLeft(InputAction.CallbackContext context);
        void OnCamRight(InputAction.CallbackContext context);
        void OnJump_Fly(InputAction.CallbackContext context);
        void OnVehicle(InputAction.CallbackContext context);
        void OnSword(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnMenuPause(InputAction.CallbackContext context);
        void OnPhone(InputAction.CallbackContext context);
        void OnCamLeft2(InputAction.CallbackContext context);
        void OnCamRight2(InputAction.CallbackContext context);
        void OnDEBUG(InputAction.CallbackContext context);
    }
}
