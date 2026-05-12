using UnityEngine;

public class CanoeScript : MonoBehaviour
{
    private Collider2D canoeCollider;
    private bool goLevel2 = false;
    private bool goLevel3 = false;
    public GameObject cantGoPrompt;
    [SerializeField] private PlayerController _playerController;
    private bool isPaused;

    private void Start()
    {
        canoeCollider = GetComponent<Collider2D>();
        if (canoeCollider == null)
        {
            Debug.LogError("CanoeScript: No Collider2D found on the canoe object.");
        }
    }
    public void Update()
    {
        if (cantGoPrompt.activeSelf && InputManager.instance.JumpJustPressed)
        {
            CloseCantGoPrompt();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entered canoe trigger");
            CheckStarInfo();

            if(goLevel3)
            {
                SceneController.Instance.ResetSpawnData();
                SceneController.Instance.LoadScene("Level3_Coral");
            }
            else if (goLevel2)
            {
                SceneController.Instance.ResetSpawnData();
                SceneController.Instance.LoadScene("Level2_Overgrown");
            }
            else
            {
                OpenCantGoPrompt();
            }
        }
    }

    private void OpenCantGoPrompt()
    {
        cantGoPrompt.SetActive(true);
        Pause();
    }

    private void CloseCantGoPrompt()
    {
        cantGoPrompt.SetActive(false);
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

    private void CheckStarInfo()
    {
        if(PlayerManager.Instance.StarInfo1Unlocked && PlayerManager.Instance.StarInfo2Unlocked &&
           PlayerManager.Instance.StarInfo3Unlocked && PlayerManager.Instance.StarInfo4Unlocked &&
           PlayerManager.Instance.HasBeenToLevel2)
        {
            goLevel3 = true;
        }
        else if (PlayerManager.Instance.StarInfo1Unlocked && PlayerManager.Instance.StarInfo2Unlocked &&
                 PlayerManager.Instance.StarInfo3Unlocked && !PlayerManager.Instance.HasBeenToLevel2)
        {
            goLevel2 = true;
        }
    }
}
