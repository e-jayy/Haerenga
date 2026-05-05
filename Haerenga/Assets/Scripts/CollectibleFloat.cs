using UnityEngine;

public class CollectibleFloat : MonoBehaviour
{
    [Header("Float Settings")]
    [SerializeField] private float floatHeight = 0.3f;
    [SerializeField] private float floatSpeed = 2f;

    [Header("Spin Settings")]
    [SerializeField] private float spinSpeed = 180f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Float up and down using a sine wave
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Spin around Y axis to simulate 3D spin on a 2D sprite
        transform.Rotate(0f, spinSpeed * Time.deltaTime, 0f);
    }
}