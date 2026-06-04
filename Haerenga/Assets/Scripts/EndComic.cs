using UnityEngine;
using System.Collections;

public class EndComic : MonoBehaviour
{
    public GameObject NPCHouse;
    public GameObject dialogueCanvasGO;
    public GameObject[] objectsToDeactivate;
    void Start()
    {
        StartCoroutine(TransitionToDialogue());
    }

    private IEnumerator TransitionToDialogue()
    {
        SceneController.Instance.transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1f);

        SceneController.Instance.transitionAnim.SetTrigger("Start");
        //yield return new WaitForSeconds(0.55f);

        
        DeactivateObjects();
        NPCHouse.SetActive(true);
        yield return new WaitForSeconds(0.55f);
        dialogueCanvasGO.SetActive(true);
    }

    // private void ActivateObjects()
    // {
    //     Debug.Log("Activating objects...");
    //     foreach (GameObject obj in objectsToActivate)
    //     {
    //         if (obj != null)
    //             obj.SetActive(true);
    //             StartCoroutine(WaitToActivate());
    //     }
    // }
    

    public void DeactivateObjects()
    {
        foreach (GameObject obj in objectsToDeactivate)
        {
            if (obj != null)
                obj.SetActive(false);
        }
    }
}
