using UnityEngine;

public class LevelVillage_Trigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            SceneController.Instance.ResetSpawnData();
            SceneController.Instance.LoadScene("Level_Village");
        }
    }
}
