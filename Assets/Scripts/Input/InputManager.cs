using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerInputActions;

public class InputManager : MonoBehaviour, IPlayerActions, IUIActions
{
    PlayerInputActions inputActions;
    
    // -- INPUT EVENTS TO BROADCAST -- //
    public event Action<Vector2> OnPlayerMove = delegate { };
    public event Action OnPlayerInteract = delegate { };
    
    void Awake()
    {
        inputActions = new PlayerInputActions();
        
        EnableDisableInputActions(true);
        
        // set input callbacks for both action maps to be handled here
        inputActions.Player.SetCallbacks(this);
        inputActions.UI.SetCallbacks(this);
    }

    void OnEnable() => EnableDisableInputActions(true);
    void OnDisable() => EnableDisableInputActions(false);

    void EnableDisableInputActions(bool toggle)
    {
        if (toggle)
        {
            // enable input asset and its maps
            inputActions.Enable();
            inputActions.Player.Enable();
            inputActions.UI.Enable();
        }
        else
        {
            inputActions.UI.Disable();
            inputActions.Player.Disable();
            inputActions.Disable();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // Check context no matter the input state
        if (context.started || context.performed || context.canceled)
        {
            OnPlayerMove?.Invoke(context.ReadValue<Vector2>());
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed || context.started)
        {
            OnPlayerInteract?.Invoke();
        }
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
    }

    public void OnJump(InputAction.CallbackContext context)
    {
    }

    public void OnPrevious(InputAction.CallbackContext context)
    {
    }

    public void OnNext(InputAction.CallbackContext context)
    {
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
    }

    public void OnNavigate(InputAction.CallbackContext context)
    {
    }

    public void OnSubmit(InputAction.CallbackContext context)
    {
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
    }

    public void OnClick(InputAction.CallbackContext context)
    {
    }

    public void OnRightClick(InputAction.CallbackContext context)
    {
    }

    public void OnMiddleClick(InputAction.CallbackContext context)
    {
    }

    public void OnScrollWheel(InputAction.CallbackContext context)
    {
    }

    public void OnTrackedDevicePosition(InputAction.CallbackContext context)
    {
    }

    public void OnTrackedDeviceOrientation(InputAction.CallbackContext context)
    {
    }
}
