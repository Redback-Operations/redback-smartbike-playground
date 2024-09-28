using UnityEngine;

[CreateAssetMenu(fileName = "NewMissionData", menuName = "MissionData")]
public class MissionData : ScriptableObject
{
    public string missionName;
    public GameObject collectableType;
    public int requiredCollectableCount;
}