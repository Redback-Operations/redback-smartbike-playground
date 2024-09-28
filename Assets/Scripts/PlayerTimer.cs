using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTimer : MonoBehaviour
{
    private ScoreManager scoreManager;

    void Awake()
    {
        // Declares initial state of the mission
        scoreManager = FindObjectOfType<ScoreManager>();
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
