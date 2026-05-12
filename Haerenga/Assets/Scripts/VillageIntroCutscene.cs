using System.Collections;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.Playables;

public class VillageIntroCutscene : MonoBehaviour
{
    [SerializeField] private PlayableDirector timeline;
    [SerializeField] private GameObject[] _objectsToActivate;
    [SerializeField] private GameObject[] _objectsToDeactivate;
    [SerializeField]private Animator transitionAnim;
    private void Start()
    {
        transitionAnim = SceneController.Instance.transitionAnim;
        if(!PlayerManager.Instance.starInfo1Unlocked && !PlayerManager.Instance.starInfo2Unlocked)
        {
            timeline.Play();
        }
        else
        {
            transitionAnim.SetTrigger("Start");

            foreach (GameObject obj in _objectsToActivate)
            {
                if (obj != null)
                {
                    obj.SetActive(true);
                }
            }
            foreach (GameObject obj in _objectsToDeactivate)
            {
                if (obj != null)
                {
                    obj.SetActive(false);
                }
            }
            
            //StartCoroutine(DisableGameobject());
        }
    }

    private IEnumerator DisableGameobject()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
