using UnityEngine;
using UnityEngine.EventSystems;

public class StartMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _startMenuCanvasGO;
    [SerializeField] private GameObject _startMenuFirst;
    void Start()
    {
        _startMenuCanvasGO.SetActive(true);
        EventSystem.current.SetSelectedGameObject(_startMenuFirst);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
