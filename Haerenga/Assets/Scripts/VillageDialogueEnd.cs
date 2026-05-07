using System.Collections;
using UnityEngine;

public class VillageDialogueEnd : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameObject[] _objectsToActivate;
    [SerializeField] private GameObject[] _objectsToDeactivate;
    [SerializeField] private Animator transitionAnim;

    void Start()
    {
        StartCoroutine(TransitionToGameplay());
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
    }
}
