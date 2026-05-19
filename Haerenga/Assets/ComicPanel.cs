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

    private Image panelImage;
    private bool isRevealed = false;

    void Start()
    {
        panelImage = GetComponent<Image>();
        
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