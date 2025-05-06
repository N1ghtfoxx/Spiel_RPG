using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class BaseCharacterController : MonoBehaviour
{
    private Vector2 movementInput;
    [SerializeField] private float movementSpeed;
    [Range(0,1)][SerializeField] private float slowedFactor;
    private bool isSlowed;

    private void Start()
    {
        isSlowed = false;
    }

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
        //var actualMovementSpeed = isSlowed ? movementSpeed * slowedFactor : movementSpeed;
        var actualMovementSpeed = movementSpeed;
        if(isSlowed) actualMovementSpeed *= slowedFactor;

        transform.Translate(new Vector3(movementInput.x, movementInput.y, 0) * Time.deltaTime * actualMovementSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FightEncounter"))
        {
            CheckForEncounter();
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Swamp"))
        {
            isSlowed = true;
        }

        else if (col.gameObject.CompareTag("HighGrass"))
        {
            isSlowed = true;
        }   
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Swamp"))
        {
            isSlowed = false;
        }

        else if (col.gameObject.CompareTag("HighGrass"))
        {
            isSlowed = false;
        }
    }

    private void CheckForEncounter()
    {
        FightManager.Instance.CheckForEncounter();
    }
}
