using System.Collections;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    // kann von überall zugreifen aber nur hier bearbeiten
    public static FightManager Instance { get; private set; }
    [Range(0, 100), SerializeField] private int chanceToEncounter;
    [SerializeField] GameObject fightCanvas; 
    private bool isFightActive;
    private BaseCharacterController characterController;


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
    
    public bool CheckForEncounter(BaseCharacterController characterController)
    {
        this.characterController = characterController;
        if (Random.Range(0, 100) < chanceToEncounter)
        {
            StartFight();
        }
        return isFightActive;
    }

    /// This method is called when the player enters a fight encounter
    private void StartFight()
        
    {
        StartCoroutine(FightCoroutine());
    }

    private IEnumerator FightCoroutine() //BSP.: vor der while wie viele Gegener, während Kampfberechnung, nach wie viel Belohnung
    {
        isFightActive = true;
        fightCanvas.SetActive(isFightActive);
        // load chars
        // LoadCharacter();
        // load random enemies
        // LoadRandomEnemies();
        // load items
        // LoadItems();
        // load backgroundImages
        // load music
        // load UI
        // LoadBackgroundImage Music UI();

        /* while(transition) {
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
        fightCanvas.SetActive(isFightActive);
        characterController.PausePlayer(isFightActive);

    }

    // private void LoadCharacter()
    // {
    //     lade Spieler
    //     lade Fähigkeiten und Stats aus CharacterStatsManager 
    // }

    // private void LoadRandomEnemies()
    // {
    //     erzeuge zufällige Gegner (evtl. aus Liste)
    //     lade Fähigkeiten und Stats aus CharacterStatsManager
    // }

    // private void LoadItems()
    // {
    //     lade Liste von Inventar/ Items 
    // }

    // private void BackgroundImage Music UI()
    // {
    //     lade Image Music UI 
    // }

}

