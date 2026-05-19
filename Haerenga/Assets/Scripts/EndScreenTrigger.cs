using UnityEngine;

public class EndScreenTrigger : MonoBehaviour
{
    void Start()
    {
        SceneController.Instance.LoadScene("End_Scene");
    }
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         SceneController.Instance.LoadScene("End_Scene");
    //     }
    // }
}
