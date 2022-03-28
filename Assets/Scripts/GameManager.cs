using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton Pattern
    // There can only be one instance of GameManager
    GameManager Instance { get; set; }

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(Instance);
        }

        Instance = this;

        DontDestroyOnLoad(Instance);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
