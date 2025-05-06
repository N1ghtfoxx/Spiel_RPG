using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsManager : MonoBehaviour
{

    public static CharacterStatsManager Instance { get; private set; }
    [SerializeField] private int ExperiencePoints;
    [SerializeField] private int Level;
    [SerializeField] private int Health;
    [SerializeField] private int MaxHealth;
    // vorhanden/ausgerüstet? ja/nein
    private Dictionary<string, bool> equipment;
    // wie viele? z.b. 5 Äpfel
    private Dictionary<string, int> items;


    // Start is called before the first frame update
    void Start()
    {
    
        if (Instance == null)
        {
            Instance = this;

            Load();
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
     
    }

    private void Load()
    {
        ExperiencePoints = 0;
        Level = 1;
        Health = 100;
        MaxHealth = 100;

        equipment = new Dictionary<string, bool>();
        items = new Dictionary<string, int>();
    }

}
