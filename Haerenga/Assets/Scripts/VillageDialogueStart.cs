using UnityEngine;

public class VillageDialogueStart : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameObject[] _objectsToActivate;

    void Start()
    {
        foreach (GameObject obj in _objectsToActivate)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }

        if (_playerController != null)
        {
            _playerController.enabled = false;
            _playerController.StopMovement();
        }
    }
}