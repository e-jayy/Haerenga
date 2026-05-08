using UnityEngine;
using UnityEngine.Playables;

public class PlayNPCDialogeTimeline : MonoBehaviour
{
    [SerializeField] private PlayableDirector timeline;
    void Start()
    {
        timeline.Play();
    }
}
