using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputs : MonoBehaviour
{
    public static GameInputs Instance;

    private PlayerInputActions playerInputActions;

    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternativeAction;
    public event EventHandler OnPauseAction;

    private void Awake()
    {
        Instance= this;

        playerInputActions = new PlayerInputActions();

        playerInputActions.Player.Enable();
        playerInputActions.Player.Interact.performed += Interact_performed;
        playerInputActions.Player.InteractAlternate.performed += InteractAlternate_performed;
        playerInputActions.Player.Pause.performed += Pause_performed;
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext callback)
    {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext callback)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    private void InteractAlternate_performed(UnityEngine.InputSystem.InputAction.CallbackContext callback)
    {
        OnInteractAlternativeAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        return inputVector;
    }
}
