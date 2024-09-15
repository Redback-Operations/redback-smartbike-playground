using UnityEngine;

public class Compass : MonoBehaviour
{
    // Reference to the player's transform component
    public Transform PlayerTransform;

    // Reference to the Transform of the compass cylinder (3D model)
    public Transform CompassCylinder;

    // Initial Y rotation you want to apply
    private const float initialYRotation = -88.376f;

    void Start()
    {
        // Set the starting Y rotation to -88.376 degrees
        SetInitialRotation();
    }

    void Update()
    {
        // Calculate the rotation difference between the player and north (north is Y = 0 degrees)
        float playerRotationY = PlayerTransform.eulerAngles.y;

        // Rotate the compass cylinder in the opposite direction of the player's rotation
        CompassCylinder.localRotation = Quaternion.Euler(0f, playerRotationY, 0f);
    }

    // Method to set the initial rotation explicitly
    private void SetInitialRotation()
    {
        // Set the rotation in Quaternion to ensure no unwanted conversions
        CompassCylinder.localRotation = Quaternion.Euler(0f, initialYRotation, 0f);
    }
}
