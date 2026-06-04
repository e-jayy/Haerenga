using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ComicPanel : MonoBehaviour
{
    [Header("Fade Settings")]
    [SerializeField] private float fadeInDuration = 0.5f;

    [Header("Next Panel")]
    [SerializeField] private GameObject[] objectsToActivate;
    [SerializeField] private GameObject[] objectsToDeactivate;

    
    [Header("Audio")]
    [SerializeField] private AudioClip panelAudio;
    [SerializeField] [Range(0f, 1f)] private float audioVolume = 1f;
    public AudioSource audioSource;

    private Image panelImage;
    [SerializeField] private bool isRevealed = false;

    void Start()
    {
        panelImage = GetComponent<Image>();
        
        audioSource = GetComponent<AudioSource>();
        
        if (panelImage != null)
        {
            // Start fully transparent
            Color color = panelImage.color;
            color.a = 0f;
            panelImage.color = color;

            StartCoroutine(FadeIn());
        }
    }

    void Update()
    {
        if (isRevealed && InputManager.instance.JumpJustPressed)
        {
            ActivateObjects();
            DeactivateObjects();
        }
    }

    private IEnumerator FadeIn()
    {
        if (panelAudio != null && audioSource != null)
        {
            audioSource.volume = audioVolume;
            audioSource.PlayOneShot(panelAudio);
        }

        float elapsed = 0f;

        while (elapsed < fadeInDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsed / fadeInDuration);

            Color color = panelImage.color;
            color.a = alpha;
            panelImage.color = color;

            yield return null;
        }

        // Ensure fully opaque at end
        Color finalColor = panelImage.color;
        finalColor.a = 1f;
        panelImage.color = finalColor;

        isRevealed = true;
    }

    private void ActivateObjects()
    {
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