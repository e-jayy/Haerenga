using UnityEngine;

public class DisableCamera : MonoBehaviour
{
    [SerializeField] private GameObject disableCamera;
    private void Start()
    {
        if (disableCamera != null)
        {
            disableCamera.SetActive(false);
        }
    }
}
