using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileSelector : MonoBehaviour
{
    public ScoreManager scoreManager; // Reference to ScoreManager
    public List<string> profiles = new List<string> { "Profile1", "Profile2", "Profile3" }; // Example profiles
    public GameObject profileButtonPrefab; // A prefab button for each profile
    public Transform buttonContainer; // The UI container for the profile buttons

    private void Start()
    {
        CreateProfileButtons();
    }

    private void CreateProfileButtons()
    {
        // Clear existing buttons in the container if any
        foreach (Transform child in buttonContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (var profile in profiles)
        {
            GameObject buttonObj = Instantiate(profileButtonPrefab, buttonContainer);
            Button button = buttonObj.GetComponent<Button>();
            Text buttonText = buttonObj.GetComponentInChildren<Text>();
            buttonText.text = profile;

            // Add listener for button click to select profile
            button.onClick.AddListener(() => SelectProfile(profile));
        }
    }

    private void SelectProfile(string profile)
    {
        // Set the active profile in the ScoreManager
        scoreManager.SetProfile(profile);
        Debug.Log($"Profile selected: {profile}");
    }
}
