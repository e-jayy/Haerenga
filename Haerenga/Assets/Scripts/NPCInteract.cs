using UnityEngine;

public class NPCInteract : MonoBehaviour
{
    private Collider2D npcCollider;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] GameObject[] _objectsToActivate;
    private void Start()
    {
        npcCollider = GetComponent<Collider2D>();

        if(PlayerManager.Instance.StarInfo1Unlocked && PlayerManager.Instance.StarInfo2Unlocked)
        {
            npcCollider.enabled = false; // Disable the collider to prevent interaction
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            foreach (GameObject obj in _objectsToActivate)
            {
                obj.SetActive(true);
            }
            npcCollider.enabled = false; // Disable the collider to prevent multiple triggers
        }
    }
}
