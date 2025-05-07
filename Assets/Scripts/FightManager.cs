using System.Collections;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    // kann von überall zugreifen aber nur hier bearbeiten
    public static FightManager Instance { get; private set; }
    [Range(0, 100), SerializeField] private int chnaceToEncounter;
    [SerializeField] GameObject fightCanvas; 
    private bool isFightActive;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        isFightActive = false;
    }
    
    public bool CheckForEncounter()
    {
        // Check if the player is in a fight encounter area
        if (Random.Range(0, 100) < chnaceToEncounter)
        {
            // Encounter
            StartFight();
        }
        return isFightActive;
    }

    /// This method is called when the player enters a fight encounter
    private void StartFight()
        
    {
        // Pause the game
        fightCanvas.SetActive(true);
        isFightActive = true;
        StartCoroutine(FightCoroutine());
    }

    private IEnumerator FightCoroutine() //BSP.: vor der while wie viele Gegener, während Kampfberechnung, nach wie viel Belohnung
    {
        // load chars
        // load random enemies
        // load items
        // load backgroundImages
        // load music
        // load UI

        /*while(transition( {
         * 
         * DoStuff();
         * yield return new WaitForEndOfFrame();
         * 
         *  }*/

        while (isFightActive)
        {
            // check whos turn 
            // make players/ enemies turn   
            // show and wait for end of fight   
            // set isFightActive to false <- GameOver? enemies are dead?
            yield return new WaitForSeconds(3f);
            isFightActive = false; // because: nobody got time for this
        }

        // End the fight an gain XP an gold
        // level up?
    }

}
