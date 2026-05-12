using System.Collections;
using UnityEngine;

public class VillageDialogueEnd : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameObject[] _objectsToActivate;
    [SerializeField] private GameObject[] _objectsToDeactivate;
    [SerializeField] private GameObject _notebookPromptGO;
    private bool isPaused;
    private Animator transitionAnim;

    void Start()
    {
        transitionAnim = SceneController.Instance.transitionAnim;
        StartCoroutine(TransitionToGameplay());
    }

    void Update()
    {
        if (_notebookPromptGO != null && _notebookPromptGO.activeSelf && InputManager.instance.JumpJustPressed)
        {
            ClosePrompt();
        }
    }
    private IEnumerator TransitionToGameplay()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(0.55f);
        transitionAnim.SetTrigger("Start");

        if(_playerController != null)
        {
            _playerController.enabled = true;
        }

        foreach (GameObject obj in _objectsToDeactivate)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }

        foreach (GameObject obj in _objectsToActivate)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }

        if (_notebookPromptGO != null)
        {
            OpenPrompt();
        }
    }

    private void OpenPrompt()
    {
        _notebookPromptGO.SetActive(true);
        Pause();
    }  
    public void ClosePrompt()
    {
        _notebookPromptGO.SetActive(false);
        Unpause();
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;

        if(_playerController != null)
        {
        _playerController.enabled = false;    
        }
    }

    public void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1f;

        if(_playerController != null)
        {
        _playerController.enabled = true;    
        }
    }

}
