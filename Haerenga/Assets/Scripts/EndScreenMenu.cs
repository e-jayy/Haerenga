using UnityEngine;
using UnityEngine.EventSystems;

public class EndScreenMenu : MonoBehaviour
{
    [SerializeField] private GameObject _endMenuFirst;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(_endMenuFirst);
    }
    public void OnStartPress()
    {
        SceneController.Instance.ResetSpawnData();
        SceneController.Instance.LoadScene("Start_Scene");
    }

    public void OnQuitPress()
    {
        SceneController.Instance.QuitGame();
    }
}
