using UnityEngine;
using TMPro;

public class Starcompass : MonoBehaviour
{
    [SerializeField] private Transform rotatingObject;
    [SerializeField] private RectTransform UIElement;

    [Header("Direction Text")]
    [SerializeField] private TMP_Text directionText;
    [SerializeField] private string[] stepTexts = new string[32];

    private void Update()
    {
        if (rotatingObject == null || UIElement == null) return;

        float z = rotatingObject.eulerAngles.z;
        float normalizedRotation = (z + 360f) % 360f;

        int step = Mathf.RoundToInt(normalizedRotation / (360f / 32f));
        step = step % 32;

        float stepRotation = step * (360f / 32f);

        UIElement.rotation = Quaternion.Euler(0f, 0f, stepRotation);

        // Set text for current segment
        if (directionText != null && stepTexts.Length > step)
        {
            directionText.text = stepTexts[step];
        }
    }
}