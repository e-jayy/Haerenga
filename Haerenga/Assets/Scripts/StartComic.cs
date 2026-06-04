using UnityEngine;
using System.Collections;

public class StartComic : MonoBehaviour
{
    public GameObject[] objectsToActivate;
    public GameObject[] objectsToDeactivate;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(TransitionToComic());
        }
    }

    private IEnumerator TransitionToComic()
    {
        SceneController.Instance.transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(0.55f);
        SceneController.Instance.transitionAnim.SetTrigger("Start");
        ActivateObjects();
        DeactivateObjects();
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
