using UnityEngine;
using System.Collections;

public class EndComic : MonoBehaviour
{
    public GameObject[] objectsToActivate;
    public GameObject[] objectsToDeactivate;
    void Start()
    {
        StartCoroutine(TransitionToDialogue());
    }

    private IEnumerator TransitionToDialogue()
    {
        SceneController.Instance.transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(0.55f);
    
        ActivateObjects();
        DeactivateObjects();

        SceneController.Instance.transitionAnim.SetTrigger("Start");
    }

    private void ActivateObjects()
    {
        Debug.Log("Activating objects...");
        foreach (GameObject obj in objectsToActivate)
        {
            if (obj != null)
                obj.SetActive(true);
        }
    }

    public void DeactivateObjects()
    {
        foreach (GameObject obj in objectsToDeactivate)
        {
            if (obj != null)
                obj.SetActive(false);
        }
    }
}
