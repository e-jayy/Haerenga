using UnityEngine;

public class CanoeRowAnimation : MonoBehaviour
{
    [Header("Bob Settings")]
    [SerializeField] private float bobHeight = 0.1f;
    [SerializeField] private float bobSpeed = 2f;

    [Header("Tilt Settings")]
    [SerializeField] private float tiltAngle = 3f;
    [SerializeField] private float tiltSpeed = 1.5f;

    [Header("Row Settings")]
    [SerializeField] private float rowDistance = 0.05f;
    [SerializeField] private float rowSpeed = 1.5f;

    private Vector3 startPosition;
    private Quaternion startRotation;

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    void Update()
    {
        float bobOffset = Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        
        float rowOffset = Mathf.Sin(Time.time * rowSpeed) * rowDistance;
        
        transform.position = startPosition + new Vector3(rowOffset, bobOffset, 0f);

        float tilt = Mathf.Sin(Time.time * tiltSpeed) * tiltAngle;
        transform.rotation = startRotation * Quaternion.Euler(0f, 0f, tilt);
    }
}