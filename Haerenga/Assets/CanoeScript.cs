using UnityEngine;

public class CanoeScript : MonoBehaviour
{
    private Collider2D canoeCollider;
    private bool goLevel2 = false;
    private bool goLevel3 = false;
    public GameObject cantGoPrompt;

    private void Start()
    {
        canoeCollider = GetComponent<Collider2D>();
        if (canoeCollider == null)
        {
            Debug.LogError("CanoeScript: No Collider2D found on the canoe object.");
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
                cantGoPrompt.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cantGoPrompt.SetActive(false);
        }
    }

    private void CheckStarInfo()
    {
        if(PlayerManager.Instance.StarInfo1Unlocked && PlayerManager.Instance.StarInfo2Unlocked &&
           PlayerManager.Instance.StarInfo3Unlocked && PlayerManager.Instance.StarInfo4Unlocked)
        {
            goLevel3 = true;
        }
        else if (PlayerManager.Instance.StarInfo1Unlocked && PlayerManager.Instance.StarInfo2Unlocked &&
           PlayerManager.Instance.StarInfo3Unlocked)
        {
            goLevel2 = true;
        }
    }
}
