using System.Collections;
using UnityEngine;

public class FightManager : MonoBehaviour
{
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
        var rectTransform = fightCanvas.GetComponentsInChildren<RectTransform>()[1];
        rectTransform.localPosition = Vector3.up * 1200f; // move the canvas out of the screen      

        while (rectTransform.localPosition.y > 0) {

            rectTransform.Translate(Vector3.down * Time.deltaTime * 100f);
            yield return new WaitForEndOfFrame();
         
         }

        rectTransform.localPosition = Vector3.zero; // move the canvas to the center of the screen

        // load chars
            // LoadCharacter();
        // load random enemies
            // LoadRandomEnemies();
        // load items
            // LoadItems();
        // load backgroundImages
                // LoadBackgroundImage();
        // load music
            // LoadMusic();
        // load UI
            // LoadUI();


        while (isFightActive)
        {
            // check whos turn 
                // bool isPlayerTurn = true; // or false
                // if (isPlayerTurn)
                // characterController.PlayerTurn();
                // else 
                // characterController.EnemyTurn();
            // Zugwechsel
            // check if fight is over
            // show and wait for end of fight   
            // set isFightActive to false <- GameOver? enemies are dead?
                // if CheckEnemiesDefeated() || CheckPlayerDefeated()
            yield return new WaitForSeconds(3f);
            isFightActive = false; // because: nobody got time for this
        }

        // End the fight an gain XP an gold
            // xpGain
            // goldGain
        // level up?
            // PlayerStatsManager.UpdateStats();
            // Level++;
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

    // private void LoadBackgroundImage /Music/ UI() //für jedes Element einzelne Methode!
    // {
    //     lade Image Music UI 
    // }

}

