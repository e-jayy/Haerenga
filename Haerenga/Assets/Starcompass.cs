using UnityEngine;

public class Starcompass : MonoBehaviour
{
    [SerializeField] private Transform rotatingObject; // The object that rotates 0-360
    [SerializeField] private RectTransform uiElement;   // The UI element to rotate in steps

    private void Update()
    {
        if (rotatingObject == null || uiElement == null) return;

        // Get the normalized rotation (0-360)
        float z = rotatingObject.eulerAngles.z;
        float normalizedRotation = (z + 360f) % 360f;

        // Calculate which of the 32 steps we're in
        int step = Mathf.RoundToInt(normalizedRotation / (360f / 32f));
        
        // Wrap step to 0-31 range
        step = step % 32;

        // Convert step back to rotation angle
        float stepRotation = step * (360f / 32f);

        // Apply to UI element
        uiElement.rotation = Quaternion.Euler(0f, 0f, stepRotation);
    }
}