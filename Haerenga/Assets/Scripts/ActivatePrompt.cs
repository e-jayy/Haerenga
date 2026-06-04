using UnityEngine;

public class ActivatePrompt : MonoBehaviour
{
    [SerializeField] private GameObject GOToActivate;
    private bool isPaused;
    [SerializeField] private PlayerController _playerController;
    void Start()
    {
        if(GOToActivate != null)
        {
            ActivateGO();
        }
    }

    void Update()
    {
        if(InputManager.instance.JumpJustPressed && GOToActivate != null && GOToActivate.activeSelf)
        {
            if(GOToActivate != null)
            {
                DeactivateGO();
            }
        }
    }

    void ActivateGO()
    {
        GOToActivate.SetActive(true);
        Pause();
    }

    void DeactivateGO()
    {
        GOToActivate.SetActive(false);
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
        
        Destroy(gameObject);
    }
}