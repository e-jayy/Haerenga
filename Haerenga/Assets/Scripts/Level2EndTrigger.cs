using UnityEngine;

public class Level2EndTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneController.Instance.LoadScene("Level_StarNav");
        }
    }
}
