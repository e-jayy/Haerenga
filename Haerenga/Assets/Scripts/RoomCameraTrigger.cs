using UnityEngine;
using Unity.Cinemachine;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

public class RoomCameraTrigger : MonoBehaviour
{
    [Header("Camera To Activate")]
    [SerializeField] private CinemachineCamera roomCamera;

    [Header("Priority Settings")]
    [SerializeField] private int activePriority = 20;
    [SerializeField] private int inactivePriority = 10;
    [SerializeField] private float LockRoomDelay = 0.5f;  
    [Header("References")]
    [SerializeField] private GameObject RoomLock;
    [SerializeField] private GameObject[] objectsToActivate;
    public Transform respawnPoint;

    private void Start()
    {
        // Ensure this camera starts inactive
        if (roomCamera != null)
            roomCamera.Priority = inactivePriority;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        ActivateRoomCamera();

        if(other.CompareTag("Player"))
        {
            if (respawnPoint != null)
            {
                SceneController.Instance.SetRespawnPoint(respawnPoint.position);
            }
            if(objectsToActivate != null)
            {
                foreach (GameObject obj in objectsToActivate)
                {
                    if (obj != null)
                    obj.SetActive(true);
                }  
            }

            if (RoomLock != null)
            {
                StartCoroutine(LockRoom());
            }
        }
    }

    private IEnumerator LockRoom()
    {
        yield return new WaitForSeconds(LockRoomDelay);
        RoomLock.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        DeactivateRoomCamera();
    }

    private void ActivateRoomCamera()
    {

        // Activate this room's camera
        if (roomCamera != null)
            roomCamera.Priority = activePriority;
    }

    private void DeactivateRoomCamera()
    {
        if (roomCamera != null)
            roomCamera.Priority = inactivePriority;
    }
}