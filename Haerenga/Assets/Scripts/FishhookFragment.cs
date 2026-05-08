using UnityEngine;

public class FishhookFragment : MonoBehaviour
{
    [SerializeField] private GameObject abilityInfoPanel;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private bool hasBeenCollected = false;
    [SerializeField] private bool collectHook;
    [SerializeField] private bool collectWallJump;
    private bool isPaused;
    public void start()
    {
        if(collectHook && PlayerManager.Instance.hookUnlocked)
        {
            Destroy(gameObject);
        }
        else if(collectWallJump && PlayerManager.Instance.wallJumpUnlocked)
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OpenPage();
            UnlockAbility();
        }
    }
    public void Update ()
    {
        if(InputManager.instance.JumpJustPressed && abilityInfoPanel.activeSelf)
        {
            ClosePage();
        }
    }

    private void OpenPage()
    {
        abilityInfoPanel.SetActive(true);
        Pause();
        hasBeenCollected = true;
    }  
    public void ClosePage()
    {
        abilityInfoPanel.SetActive(false);
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

    public void UnlockAbility()
    {
        if(collectHook)
        {
            Debug.Log("Unlocking Hook Ability");
            PlayerManager.Instance.UnlockHook();
        }
        else if(collectWallJump)
        {   
            Debug.Log("Unlocking Wall Jump Ability");
            PlayerManager.Instance.UnlockWallJump();
        }
    }
}

