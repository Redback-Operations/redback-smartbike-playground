using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public GameObject coin; // Declaration of what item needs collecting for the mission
    public TextMeshProUGUI coinCollectText; // References the UI text that displays the total coins 
    private int coinCount; //Count for the total coins
    private ScoreManager scoreManager; 
    // Start is called before the first frame update
    void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found in the scene!");
            return;
        }
    }

    void Start()
    {
        coinCount = scoreManager.LoadCoinCollection();
        coinCollectText.text = "Coins: " + coinCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the tag on the triggered collision is the same as on collectableType
        if (other.CompareTag(coin.tag))
        {
            CoinCollection(other.gameObject);
        }
    }

    private void CoinCollection(GameObject itemCollectable)
    {
        Debug.Log(itemCollectable.name + " collected");

        // Destroy collected object from the scene and add to counter
        Destroy(itemCollectable);
        coinCount++;
        coinCollectText.text = "Coins: " + coinCount;
        
        //Save to file new coin amount
        scoreManager.SaveCoinCollection(coinCount);
        print("Coin saved");
        
    }
}
