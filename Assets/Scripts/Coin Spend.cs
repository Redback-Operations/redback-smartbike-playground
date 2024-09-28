using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinSpend : MonoBehaviour
{
    public int cost; //Cost of the item
    public TextMeshProUGUI coinCollectText; // References the UI text that displays the total coins 

    public bool purchased; 
    private ScoreManager scoreManager;
    private int coinCount;

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
    }

    void OnMouseDown()
    {
        if (coinCount >= cost && !purchased)
        {
            Debug.Log(cost + " coins spent");
            coinCount -= cost; 
            coinCollectText.text = ("Coins: " + coinCount);
            scoreManager.SaveCoinCollection(coinCount);
            purchased = true;
        }
        else
        {
            Debug.Log("Not available!");
        }
    }
}
