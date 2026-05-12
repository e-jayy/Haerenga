using UnityEngine;

public class SetCanoeSpawn : MonoBehaviour
{
    void Start()
    {
        if (PlayerManager.Instance.StarInfo1Unlocked && PlayerManager.Instance.StarInfo2Unlocked)
        {
            SceneController.Instance.SetRespawnPoint(transform.position);
        }
    }
}
