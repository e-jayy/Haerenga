using UnityEngine;

public class SetHasBeenToLevel : MonoBehaviour
{
    [SerializeField] private bool isLevel2;
    [SerializeField] private bool isLevel3;

    void Start()
    {
        if (isLevel2)
        {
            PlayerManager.Instance.SetHasBeenToLevel2();
        }
        else if (isLevel3)
        {
            // PlayerManager.Instance.SetHasBeenToLevel3();
        }
    }


}
