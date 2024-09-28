using UnityEngine;
using UnityEngine.UI;

public class MissionSelection : MonoBehaviour
{
    public MissionData[] missions;

    public GameObject PlayerObject; // Reference to the Player object in order to access attatched MissionScript

    public void SelectMission(int missionIndex)
    {
        MissionData selectedMission = missions[missionIndex];
        
        // Set mission conditions using the Mission script
        PlayerObject.GetComponent<Mission>().missionName = selectedMission.missionName;
        PlayerObject.GetComponent<Mission>().collectableType = selectedMission.collectableType;
        PlayerObject.GetComponent<Mission>().requiredCollectableCount = selectedMission.requiredCollectableCount;
        PlayerObject.GetComponent<Mission>().missionCompletion = false;
        
        Debug.Log("Mission selected: " + selectedMission.missionName);
    }
}
