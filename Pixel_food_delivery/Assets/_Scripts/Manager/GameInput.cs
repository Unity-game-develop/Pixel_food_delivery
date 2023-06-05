using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using NOOD;

public class GameInput : MonoBehaviorInstance<GameInput>
{
    #region Events
    public Action OnPlayerMove;
    public Action<Vector2> OnPlayerLMoveVector2;
    public Action OnPlayerInteract;
    #endregion
    GameInputSystem gameInputSystem;

    private void Awake() 
    {
        gameInputSystem = new GameInputSystem();

        gameInputSystem.Player.Enable();
        gameInputSystem.Player.Interact.performed += (InputAction.CallbackContext callbackContext) => OnPlayerInteract?.Invoke();
    }
    
    private void Update() 
    {
        Vector2 movementInput = gameInputSystem.Player.Move.ReadValue<Vector2>();
        OnPlayerLMoveVector2?.Invoke(movementInput);
        if(movementInput != Vector2.zero) OnPlayerMove?.Invoke();
    }


}
