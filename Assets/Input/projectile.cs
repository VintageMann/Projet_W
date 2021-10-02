// GENERATED AUTOMATICALLY FROM 'Assets/Input/projectile.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ProjectileControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ProjectileControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""projectile"",
    ""maps"": [
        {
            ""name"": ""Projectile"",
            ""id"": ""6e6290ae-7354-46fe-9e7a-f172ff2430c6"",
            ""actions"": [
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""898ddbcb-9d37-46f7-9e33-4769b18f186d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d4758899-f9d6-40d7-9311-7acd1618476b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b48860ef-b4a0-4f13-893a-0b1a895ef288"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Projectile
        m_Projectile = asset.FindActionMap("Projectile", throwIfNotFound: true);
        m_Projectile_Aim = m_Projectile.FindAction("Aim", throwIfNotFound: true);
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

    // Projectile
    private readonly InputActionMap m_Projectile;
    private IProjectileActions m_ProjectileActionsCallbackInterface;
    private readonly InputAction m_Projectile_Aim;
    public struct ProjectileActions
    {
        private @ProjectileControls m_Wrapper;
        public ProjectileActions(@ProjectileControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Aim => m_Wrapper.m_Projectile_Aim;
        public InputActionMap Get() { return m_Wrapper.m_Projectile; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ProjectileActions set) { return set.Get(); }
        public void SetCallbacks(IProjectileActions instance)
        {
            if (m_Wrapper.m_ProjectileActionsCallbackInterface != null)
            {
                @Aim.started -= m_Wrapper.m_ProjectileActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_ProjectileActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_ProjectileActionsCallbackInterface.OnAim;
            }
            m_Wrapper.m_ProjectileActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
            }
        }
    }
    public ProjectileActions @Projectile => new ProjectileActions(this);
    public interface IProjectileActions
    {
        void OnAim(InputAction.CallbackContext context);
    }
}
