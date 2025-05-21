using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.InputSystem.InputAction;

public class BaseCharacterController : MonoBehaviour
{
    private Vector2 movementInput;
    [SerializeField] private float movementSpeed;
    [Range(0,1)][SerializeField] private float slowedFactor;
    private bool isSlowed;
    private bool isPlayerPaused; 
    private Vector3Int currentPosition;
    private Vector3Int lastEncounterPosition;
    private CharacterAnimationManager cam;

    public Tilemap tilemap
    {

        get
        {
            if (m_tilemap == null) m_tilemap = FindObjectOfType<Tilemap>();
            return m_tilemap;
        }
    }
    private Tilemap m_tilemap;

    private void Start()
    {
        isSlowed = false;
        isPlayerPaused = false;
        cam = GetComponent<CharacterAnimationManager>();
    }

    /// <summary>
    /// Movement is called by the input system when player moves the joystick or presses the arrow keys
    /// </summary>
    /// <param name="ctx">Context provided by Unity Input</param>
    public void Movement(CallbackContext ctx)
    {
        // movmentInput is set by unity events
        movementInput = ctx.ReadValue<Vector2>(); 
        if  (!isPlayerPaused) 
        {
            cam.SetAnimatorValues(movementInput.x, movementInput.y); 
        }
        else
        {
            cam.SetAnimatorValues(0, 0); 
        }

    }

    //This is now a FIXEDupdate
    private void FixedUpdate()
    {
        if (isPlayerPaused) return;
        //var actualMovementSpeed = isSlowed ? movementSpeed * slowedFactor : movementSpeed;
        var actualMovementSpeed = movementSpeed;
        if(isSlowed) actualMovementSpeed *= slowedFactor;

        transform.Translate(new Vector3(movementInput.x, movementInput.y, 0) * Time.deltaTime * actualMovementSpeed);
        currentPosition = tilemap.WorldToCell(transform.position);    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Swamp") || col.gameObject.CompareTag("HighGrass"))
        {
            isSlowed = true;
        }
  
        else if(col.gameObject.CompareTag("FightEncounter"))
        {
            if (currentPosition != lastEncounterPosition)
            {
                lastEncounterPosition = currentPosition;
                PausePlayer(FightManager.Instance.CheckForEncounter(this)); // Check if the player is in a fight encounter area
            }
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

    public void PausePlayer(bool isPaused)
    {
        isPlayerPaused = isPaused;
    }
}
