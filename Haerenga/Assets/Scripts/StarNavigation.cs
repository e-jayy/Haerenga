using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class StarNavigation : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] private float rotationSpeed = 180f; // degrees per second

    [Header("Direction Check")]
    [SerializeField] private int directionValue; // 0–360 target value
    [SerializeField] private float tolerance = 3f;
    [Space(20)]
    [SerializeField] private GameObject confirmChoiceCanvas;
    [SerializeField] private GameObject starUICanvas;
    [SerializeField] private GameObject _choiceMenuFirst;
    private float horizontalInput;
    public bool checkUIOn = false;

    private void Update()
    {
        if(checkUIOn) return;
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

    public void ConfirmDirection()
    {
        float currentZ = GetNormalizedZRotation();
        // Proper circular comparison (handles 0/360 wrap)
        float angleDiff = Mathf.DeltaAngle(currentZ, directionValue);

        if (Mathf.Abs(angleDiff) <= tolerance)
        {
            Debug.Log("congrats");
        }
        else
        {
            Debug.Log("fail");
        }
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
    public void CheckDirectionInput()
    {
        // Proper circular comparison (handles 0/360 wrap)


        float currentZ = GetNormalizedZRotation();
        float angleDiff = Mathf.DeltaAngle(currentZ, directionValue);

        if (Mathf.Abs(angleDiff) <= tolerance)
        {
            Debug.Log("congrats");
        }
        else
        {
            Debug.Log("fail");
        }
    }
}
