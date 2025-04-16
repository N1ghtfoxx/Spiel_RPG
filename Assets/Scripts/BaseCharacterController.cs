using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class BaseCharacterController : MonoBehaviour
{
    private Vector2 movementInput;
    [SerializeField] float movementSpeed;

    /// <summary>
    /// Movement is called by the input system when player moves the joystick or presses the arrow keys
    /// </summary>
    /// <param name="ctx">Context provided by Unity Input</param>
    public void Movement(CallbackContext ctx)
    {
        // movmentInput is set by unity events
        movementInput = ctx.ReadValue<Vector2>(); //comment

    }

    //This is now a FIXEDupdate
    private void FixedUpdate()
    {
        transform.Translate(new Vector3(movementInput.x, movementInput.y, 0) * Time.deltaTime * movementSpeed);
    }
}
