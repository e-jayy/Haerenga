using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void OnStartPress()
    {
        SceneController.Instance.LoadScene("Cutscene_Dialogue");
    }

    public void OnQuitPress()
    {
        SceneController.Instance.QuitGame();
    }
}
