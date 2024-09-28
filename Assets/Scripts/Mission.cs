using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mission : MonoBehaviour
{
    public string missionName; // Defines the mission goal to be displayed to the user
    public GameObject collectableType; // Declaration of what item needs collecting for the mission
    public TextMeshProUGUI missionNameText; // References the UI text that displays the mission goal
    public TextMeshProUGUI collectableCountText; // References the UI text that updates the collectable count
    public TextMeshProUGUI highScoreText; // References the UI text that updates the highscore
    public TextMeshProUGUI playTimeText; //References total time the player has in game
    public int requiredCollectableCount; 
    public bool missionCompletion;
    private int collectableCount;
    private int highscore;
    private ScoreManager scoreManager; 

    void Awake()
    {
        // Declares initial state of the mission
        scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found in the scene!");
            return;
        }
    }

    void Start()
    {
        //Initial mission state
        missionCompletion = false;
        collectableCount = 0;

        // Updates the highscore
        highscore = scoreManager.LoadHighScore(); // Ensure highscore is up to date
        highScoreText.text = "Highscore: " + highscore;
        UpdateUI();
    }

    void Update()
    {
        //Updates total player time
        playTimeText.text = "Time: " + scoreManager.GetPlayerTime();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the tag on the triggered collision is the same as on collectableType
        if (other.CompareTag(collectableType.tag))
        {
            CollectItem(other.gameObject);
        }
    }

    // Handles what to do with the item once collision is triggered with it
    private void CollectItem(GameObject itemCollectable)
    {
        Debug.Log(itemCollectable.name + " collected");

        // Destroy collected object from the scene and add to counter
        Destroy(itemCollectable);
        collectableCount++;
        
        // Checks to see if mission complete condition is met
        if (collectableCount >= requiredCollectableCount)
        {
            Debug.Log("Mission Complete");
            missionCompletion = true;
        }

        // Update score and UI
        UpdateScore();
        UpdateUI();
    }

    // Changes the UI for the player based on the defined mission
    private void UpdateUI()
    {
        //Mission Name
        missionNameText.text = "Mission: " + missionName; // Tells player the goal

        //Updates High Score
        UpdateScore();
        
        // Checks to see if goal has been achieved
        if (!missionCompletion)
            collectableCountText.text = collectableType.name + " Collected: " + collectableCount + " / " + requiredCollectableCount; // Displays mission progress
        else
            // If mission goal is completed
            collectableCountText.text = collectableType.name + " Collected: " + requiredCollectableCount + " / " + requiredCollectableCount + " Completed!";
    }

    private void UpdateScore()
    {
        print("working");
        if (collectableCount > highscore)
        {
            scoreManager.SaveHighScore(collectableCount);
            highscore = collectableCount; // Update highscore after saving
            highScoreText.text = "Highscore: " + highscore;
        }
    }
}
