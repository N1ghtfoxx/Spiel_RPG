using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private static SpawnManager instance;
    [SerializeField] private Transform battleCharacterSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void SpawnObject(GameObject go)
    {
        Instantiate(go, battleCharacterSpawnPoint);
    }

}
