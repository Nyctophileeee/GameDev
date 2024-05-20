using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class GameInput : MonoBehaviour
{
    private InputActions inputActions;

    private void Awake() 
    {   
        inputActions = new InputActions();
        inputActions.Player.Enable();
    }
    
    public Vector2 GetMovementNormalized()
    {
        Vector2 inputVector = inputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;

    }
}
