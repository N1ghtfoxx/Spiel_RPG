using UnityEngine;

public class FightManager : MonoBehaviour
{
    // kann von überall zugreifen aber nur hier bearbeiten
    public static FightManager Instance { get; private set; }
    [Range(0, 100), SerializeField] private int chnaceToEncounter;


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
    }

    public bool CheckForEncounter()
    {
        if (Random.Range(0, 100) < chnaceToEncounter)
        {
            // Encounter
            Debug.Log("Start Encounter");
            return true;
        }
        else
        {
            // No Encounter
            Debug.Log("No Encounter");
            return false;
        }
    }

}
