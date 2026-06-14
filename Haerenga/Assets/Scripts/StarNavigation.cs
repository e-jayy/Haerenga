using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class StarNavigation : MonoBehaviour
{
    [Header("Show Constellation")]
    [SerializeField] private GameObject Constellation;
    [SerializeField] private float fadeInDuration = 60f;
    [SerializeField] private float fadeTargetAlpha = 90f/255f;
    [SerializeField] private SpriteRenderer constellationSpriteRenderer;

    [Header("Rotation")]
    [SerializeField] private float rotationSpeed = 180f; // degrees per second

    [Header("Direction Check")]
    [SerializeField] [Range(0, 360)] private int villageValue;
    [SerializeField] [Range(0, 360)] private int level2Value;
    [SerializeField] [Range(0, 360)] private int level3Value; // 0–360 target value
    [SerializeField] private float tolerance = 3f;
    private bool hasFailedToSail = false;
    [Space(20)]
    
    [SerializeField] private GameObject confirmChoiceCanvas;
    [SerializeField] private GameObject incorrectChoiceCanvas;
    [SerializeField] private GameObject starUICanvas;
    [SerializeField] private GameObject _choiceMenuFirst;
    [SerializeField] private MenuManager Menu;
    private float horizontalInput;
    public bool checkUIOn = false;
    public bool incorrectUIOn = false;
    private bool hasEnabledChoiceUI = false;
    private Animator transitionAnim;

    private void Start()
    {
        transitionAnim = SceneController.Instance.transitionAnim;
    }

    private void Update()
    {
        if(hasFailedToSail)
        {
            ShowConstellation();
        }
        if (incorrectUIOn)
        {
            if (InputManager.instance.JumpJustPressed)
            {
                CloseIncorrectChoiceUI();
            }
        }

        if (checkUIOn && !Menu.isPaused && !hasEnabledChoiceUI)
        {
            EnableChoiceUISelection();
            hasEnabledChoiceUI = true;
        }

        // Reset when condition is no longer true
        if (!checkUIOn || Menu.isPaused)
        {
            hasEnabledChoiceUI = false;
        }

        if (checkUIOn || incorrectUIOn || Menu.isPaused) return;

        RotateMap();
        ChooseDirection();
    }

    private void RotateMap()
    {
        horizontalInput = InputManager.instance.MoveInput.x;

        float rotationAmount = 0f;

        if (horizontalInput > 0.1f)
            rotationAmount -= rotationSpeed * Time.deltaTime; // clockwise

        if (horizontalInput < -0.1f)
            rotationAmount += rotationSpeed * Time.deltaTime; // counter-clockwise

        if (rotationAmount != 0f)
        {
            transform.Rotate(0f, 0f, rotationAmount);
        }
    }

    private void ChooseDirection()
    {
        if (InputManager.instance.JumpJustPressed)
        {
            Debug.Log("Jump pressed, checking direction...");
            EnableChoiceUI();
        }
    }

    private void EnableChoiceUISelection()
    {
            EventSystem.current.SetSelectedGameObject(_choiceMenuFirst);
    }

    public void ConfirmDirection()
    {
        float currentZ = GetNormalizedZRotation();

        // Check village direction
        float villageAngleDiff = Mathf.DeltaAngle(currentZ, villageValue);
        if (Mathf.Abs(villageAngleDiff) <= tolerance &&
        PlayerManager.Instance.StarInfo1Unlocked && PlayerManager.Instance.StarInfo2Unlocked)
        {
            Debug.Log("Sailing to village!");
            SailToVillage();
            return; // Exit after successful navigation
        }

        // Check level 2 direction
        float level2AngleDiff = Mathf.DeltaAngle(currentZ, level2Value);
        if (Mathf.Abs(level2AngleDiff) <= tolerance &&
        PlayerManager.Instance.StarInfo1Unlocked && PlayerManager.Instance.StarInfo2Unlocked
        && PlayerManager.Instance.StarInfo3Unlocked && !PlayerManager.Instance.StarInfo4Unlocked) 
        {
            Debug.Log("Sailing to level 2!");
            SailToLevel2();
            return; // Exit after successful navigation
        }

        // Check level 3 direction
        float level3AngleDiff = Mathf.DeltaAngle(currentZ, level3Value);
        if (Mathf.Abs(level3AngleDiff) <= tolerance &&
        PlayerManager.Instance.StarInfo1Unlocked && PlayerManager.Instance.StarInfo2Unlocked
        && PlayerManager.Instance.StarInfo3Unlocked && PlayerManager.Instance.StarInfo4Unlocked)
        {
            Debug.Log("Sailing to level 3!");
            SailToLevel3();
            return; // Exit after successful navigation
        }

        StartCoroutine(FailedToSail());
    }

    private IEnumerator FailedToSail()
    {
        Debug.Log("Failed to sail in any direction, returning to star UI");
        Debug.Log("fail");
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(0.55f);
        transitionAnim.SetTrigger("Start");
        hasFailedToSail = true;
        DisableChoiceUI();
        OpenIncorrectChoiceUI();
    }

    private void OpenIncorrectChoiceUI()
    {
        incorrectUIOn = true;
        incorrectChoiceCanvas.SetActive(true);
        starUICanvas.SetActive(false);
    }

    private void CloseIncorrectChoiceUI()
    {
        StartCoroutine(DisableIncorrectUIBool());
        incorrectChoiceCanvas.SetActive(false);
        starUICanvas.SetActive(true);
    }   

    private IEnumerator DisableIncorrectUIBool()
    {
        yield return new WaitForSeconds(0.1f);
        incorrectUIOn = false;
    }

    private void SailToVillage()
    {
        // Village-specific logic
        SceneController.Instance.LoadScene("Level_Village");
    }

    private void SailToLevel2()
    {
        // Level 2-specific logic
        SceneController.Instance.LoadScene("Level2_Overgrown");
    }

    private void SailToLevel3()
    {
        // Level 3-specific logic
        SceneController.Instance.LoadScene("Level3_Coral");
    }
    
    private void EnableChoiceUI()
    {
        checkUIOn = true;
        confirmChoiceCanvas.SetActive(true);
        starUICanvas.SetActive(false);
        EventSystem.current.SetSelectedGameObject(_choiceMenuFirst);
    }

    public void DisableChoiceUI()
    {
        Debug.Log("Disabling choice UI, returning to star UI");
        confirmChoiceCanvas.SetActive(false);
        starUICanvas.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        StartCoroutine(DisableCheckUIBool());
    }

    private IEnumerator DisableCheckUIBool()
    {
        yield return new WaitForSeconds(0.1f);
        checkUIOn = false;
    }

    private float GetNormalizedZRotation()
    {
        float z = transform.eulerAngles.z;
        return (z + 360f) % 360f;
    }
    public void ShowConstellation()
    {
        Constellation.SetActive(true);
        StartCoroutine(FadeObject(Constellation, 0f, fadeTargetAlpha, fadeInDuration));
    }

    private IEnumerator FadeObject(GameObject obj, float startAlpha, float endAlpha, float duration)
    {
        float elapsed = 0f;
        
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / duration);
            SetAlpha(obj, newAlpha);
            yield return null;
        }
        
        SetAlpha(obj, endAlpha);
    }
    private void SetAlpha(GameObject obj, float alpha)
    {
        if (constellationSpriteRenderer != null)
        {
            Color color = constellationSpriteRenderer.color;
            color.a = alpha;
            constellationSpriteRenderer.color = color;
        }
    }
}
