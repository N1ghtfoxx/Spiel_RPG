using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

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

        while (rectTransform.localPosition.y > 0)
        {

            rectTransform.Translate(Vector3.down * Time.deltaTime * 100f);
            yield return new WaitForEndOfFrame();

        }

        rectTransform.localPosition = Vector3.zero; // move the canvas to the center of the screen

        // Manage with SpawnManager!
        // load chars
        // LoadCharacters();

        // load random enemies

        // load items
        // LoadItems();

        // TODO
        // load backgroundImages
        // LoadBackgroundImage();

        // load music
        // LoadMusic();

        // load UI
        // LoadUI();

        // Fight-Loop
        //  bool PlayerTurn = true;
        //  while (isFightActive)
        //  {
        //      check whos turn 
        //      if (PlayerTurn)
        //      {
        //          characterController.PlayerTurn();
        //      }
        //      else
        //      {
        //          characterController.EnemyTurn();
        //      }

        // after every turn check if fight is over
        // if (CheckEnemiesDefeated() || CheckPlayerDefeated())
        //     {
        //          ShowEndOfFightUI();
        //          yield return new WaitForSeconds(3f);
        //          isFightActive = false;
        //     }
        //  }

        // End the fight an gain XP an gold
        // GainRewards();
        // characterController.PausePlayer(isFightActive);
        // fightCanvas.SetActive(isFightActive);


    }

    /* check, if all enemies are defeated
     * bool CheckEnemiesDefeated()
     * {
     *     foreach (Character e in enemies)
     *     {
     *         if(e.Health > 0) return false;
     *     }
     *     return true;
     * }
     */

    /* check, if player is defeated
     * bool CheckPlayerDefeated()
     * {
     *     return player.Health <= 0;
     * }
     */

    /* show end of fight UI
     * void ShowEndOfFightUI()
     * {
     *     if(CheckPlayerDefeated())
     *     {
     *         Debug.Log("Game Over");
     *     }
     *     else
     *     {
     *         Debug.Log("You won the fight");
     *     }
     * }
     */

    /* gain rewards 
     * void GainRewards()
     * {
     *     int totalXp = 0;
     *     int totalGold = 0;
     *     foreach (Character e in enemies)
     *     {
     *         totalXp += e.Level * 10;
     *         totalGold += e.Level * 5;
     *     }
     *     player.Xp += totalXp;
     *     player.Gold += totalGold;
     *     Debug.Log("You gained: " + totalXp + " XP and " + totalGold + " Gold.");
     *     
     * Level-Up
     * 
     *     int xpToLevelUp = player.Level * 100;
     *     if (player.Xp >= xpToLevelUp)
     *     {
     *          player.Level++;
     *          Debug.Log("You leveled up! You are now level " + player.Level);
     *      }*/
}
    



