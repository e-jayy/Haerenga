using UnityEngine;
using Unity.Cinemachine;

public class CameraZoomAndPan : MonoBehaviour
{
    // [Header("Zoom")]
    // [SerializeField] private float zoomSpeed = 5f;
    // [SerializeField] private float minZoom = 3f;
    // [SerializeField] private float maxZoom = 8f;

    [Header("Vertical Movement")]
    [SerializeField] private float panSpeed = 5f;
    [SerializeField] private float minY = -5f;
    [SerializeField] private float maxY = 10f;
    [Space(20)]
    [SerializeField] private StarNavigation StarNavigation;
    private float verticalInput;

    private CinemachineCamera vcam;

    private void Awake()
    {
        vcam = GetComponent<CinemachineCamera>();
    }

    private void Update()
    {
        if(StarNavigation.checkUIOn || StarNavigation.incorrectUIOn) return;
        //HandleZoom();
        HandleVerticalMovement();
    }

    // private void HandleZoom()
    // {
    //     float scroll = Input.GetAxis("Mouse ScrollWheel");
    //     if (scroll != 0f)
    //     {
    //         float currentSize = vcam.Lens.OrthographicSize;
    //         currentSize -= scroll * zoomSpeed;
    //         currentSize = Mathf.Clamp(currentSize, minZoom, maxZoom);
    //         vcam.Lens.OrthographicSize = currentSize;
    //     }
    // }

    private void HandleVerticalMovement()
    {
        float vertical = 0f;
        verticalInput = InputManager.instance.MoveInput.y;

        if (verticalInput > 0.1f)
            vertical = 1f;
        else if (verticalInput < -0.1f)
            vertical = -1f;

        if (vertical != 0f)
        {
            Vector3 pos = transform.position;
            pos.y += vertical * panSpeed * Time.deltaTime;
            pos.y = Mathf.Clamp(pos.y, minY, maxY);
            transform.position = pos;
        }
    }
}