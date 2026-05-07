using UnityEngine;

public class VillageTransition : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SceneController.Instance.ResetSpawnData();
        SceneController.Instance.LoadScene("Level1_Tutorial");
    }
}
