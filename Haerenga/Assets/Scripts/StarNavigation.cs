using UnityEngine;

public class StarNavigation : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] private float rotationSpeed = 180f; // degrees per second

    [Header("Direction Check")]
    [SerializeField] private int directionValue; // 0–360 target value
    [SerializeField] private float tolerance = 3f;
    private float horizontalInput;

    private void Update()
    {
        RotateMap();

        CheckDirectionInput();
    }

    private void RotateMap()
    {
        horizontalInput = InputManager.instance.MoveInput.x;

        float rotationAmount = 0f;

        if (horizontalInput > 0.1f)
            rotationAmount -= rotationSpeed * Time.deltaTime; // clockwise

        if (horizontalInput < -0.1f)
            rotationAmount += rotationSpeed * Time.deltaTime; // counter-clockwise

        if (rotationAmount != 0f)
        {
            transform.Rotate(0f, 0f, rotationAmount);
        }
    }

    private void CheckDirectionInput()
    {
        if (!Input.GetKeyDown(KeyCode.Space))
            return;

        float currentZ = GetNormalizedZRotation();

        // Proper circular comparison (handles 0/360 wrap)
        float angleDiff = Mathf.DeltaAngle(currentZ, directionValue);

        if (Mathf.Abs(angleDiff) <= tolerance)
        {
            Debug.Log("congrats");
        }
        else
        {
            Debug.Log("fail");
        }
    }

    private float GetNormalizedZRotation()
    {
        float z = transform.eulerAngles.z;
        return (z + 360f) % 360f;
    }
}
