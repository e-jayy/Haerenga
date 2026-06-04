using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundAudio : MonoBehaviour
{
    public static BackgroundAudio Instance;

    private string createdInScene;  


    private void Awake()
    {
        createdInScene = SceneManager.GetActiveScene().name;

        // If this is a different scene, destroy the old instance and use this one
        if (Instance != null && Instance.createdInScene != createdInScene)
        {
            Destroy(Instance.gameObject);
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }

        // If instance already exists in the SAME scene, destroy duplicate
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // First instance
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // If loading a different scene, destroy this GameObject
        if (scene.name != createdInScene)
        {
            if (Instance == this)
                Instance = null;
            Destroy(gameObject);
        }
        // If loading the same scene, keep playing (do nothing)
    }
}