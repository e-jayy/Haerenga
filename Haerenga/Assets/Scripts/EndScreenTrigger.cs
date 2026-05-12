using UnityEngine;

public class EndScreenTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            SceneController.Instance.LoadScene("End_Scene");
        }
    }
}
