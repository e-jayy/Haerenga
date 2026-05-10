using UnityEngine;

public class StarInfoPage : MonoBehaviour
{
    [SerializeField] private GameObject starInfoPanel;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private bool hasBeenCollected = false;
    [SerializeField] private bool StarInfo1;
    [SerializeField] private bool StarInfo2;
    [SerializeField] private bool StarInfo3;
    [SerializeField] private bool StarInfo4;
    private bool isPaused;

    public void Start()
    {
        if(StarInfo1 && PlayerManager.Instance.starInfo1Unlocked)
        {
            Destroy(gameObject);
        }
        else if(StarInfo2 && PlayerManager.Instance.starInfo2Unlocked)
        {
            Destroy(gameObject);
        }
        else if(StarInfo3 && PlayerManager.Instance.starInfo3Unlocked)
        {
            Destroy(gameObject);
        }
        else if(StarInfo4 && PlayerManager.Instance.starInfo4Unlocked)
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OpenPage();
            UnlockStarInfo();
        }
    }
    public void Update ()
    {
        if(InputManager.instance.JumpJustPressed && starInfoPanel.activeSelf)
        {
            ClosePage();
        }
    }

    private void OpenPage()
    {
        starInfoPanel.SetActive(true);
        Pause();
        hasBeenCollected = true;
    }  
    public void ClosePage()
    {
        starInfoPanel.SetActive(false);
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

    public void UnlockStarInfo()
    {
        if(StarInfo1)
        {
            Debug.Log("Unlocking Star Info 1");
            PlayerManager.Instance.UnlockStarInfo1();
        }
        else if(StarInfo2)
        {
            PlayerManager.Instance.UnlockStarInfo2();
        }
        else if(StarInfo3)
        {
            PlayerManager.Instance.UnlockStarInfo3();
        }
        else if(StarInfo4)
        {
            PlayerManager.Instance.UnlockStarInfo4();
        }
    }
}
