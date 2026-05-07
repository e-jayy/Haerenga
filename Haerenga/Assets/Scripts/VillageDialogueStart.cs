using UnityEngine;

public class VillageDialogueStart : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameObject[] _objectsToActivate;

    void Start()
    {
        if (_playerController != null)
        {
            _playerController.StopMovement();
            _playerController.enabled = false;
        }
        
        foreach (GameObject obj in _objectsToActivate)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }

    }
}