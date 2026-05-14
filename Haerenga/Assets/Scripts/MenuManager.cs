using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    [Header("Menu Objects")]
    [SerializeField] private GameObject _mainMenuCanvasGO;
    [SerializeField] private GameObject _settingsMenuCanvasGO;
    [SerializeField] private GameObject _keyboardMenuCanvasGO;
    [SerializeField] private GameObject _controllerMenuCanvasGO;
    [SerializeField] private GameObject _inventoryCanvasGO;

    [Header("Inventory Information")]
    [SerializeField] private GameObject _starInfo1Inventory;
    [SerializeField] private GameObject _starInfo2Inventory;
    [SerializeField] private GameObject _starInfo3Inventory;
    [SerializeField] private GameObject _starInfo4Inventory;

    [Header("Player Scripts")]
    [SerializeField] private PlayerController _playerController;

    [Header("First Selected Options")]
    [SerializeField] private GameObject _mainMenuFirst;
    [SerializeField] private GameObject _settingsMenuFirst;
    [SerializeField] private GameObject _keyboardMenuFirst;
    [SerializeField] private GameObject _controllerMenuFirst;
    [SerializeField] private GameObject _inventoryMenuFirst;

    public bool isPaused;

    private void Start()
    {
        _mainMenuCanvasGO.SetActive(false);
        _settingsMenuCanvasGO.SetActive(false);
        _keyboardMenuCanvasGO.SetActive(false);
        _controllerMenuCanvasGO.SetActive(false);
        _inventoryCanvasGO.SetActive(false);
    }

    private void Update()
    {
        if(InputManager.instance.MenuOpenCloseInput)
        {
            if(!isPaused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }
    }

    #region Pause/Unpause Functions

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;

        if(_playerController != null)
        {
        _playerController.enabled = false;    
        }
        
        OpenMainMenu();
    }

    public void Unpause()
    {
        StartCoroutine(UnpauseCoroutine());
        Time.timeScale = 1f;

        if(_playerController != null)
        {
        _playerController.enabled = true;    
        }

        CloseAllMenus();
    }

    private IEnumerator UnpauseCoroutine()
    {
        yield return new WaitForSeconds(0.5f); // Wait for one frame to ensure all UI actions are processed

        isPaused = false;
    }
    
    #endregion

    #region Canvas Activation Functions

    private void OpenMainMenu()
    {
        _mainMenuCanvasGO.SetActive(true);
        _settingsMenuCanvasGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(_mainMenuFirst);
    }

    private void OpenSettingsMenuHandle()
    {
        _mainMenuCanvasGO.SetActive(false);
        _settingsMenuCanvasGO.SetActive(true);

        EventSystem.current.SetSelectedGameObject(_settingsMenuFirst);
    }

    private void OpenKeyboardConfigPressHandle()
    {
        _keyboardMenuCanvasGO.SetActive(true);
        _settingsMenuCanvasGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(_keyboardMenuFirst);
    }

    private void OpenControllerConfigPressHandle()
    {
        _controllerMenuCanvasGO.SetActive(true);
        _settingsMenuCanvasGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(_controllerMenuFirst);
    }

    private void OpenInventoryMenuHandle()
    {
        _inventoryCanvasGO.SetActive(true);
        _mainMenuCanvasGO.SetActive(false);
        CheckInventory();

        EventSystem.current.SetSelectedGameObject(_inventoryMenuFirst);
    }

    private void CloseAllMenus()
    {
        _mainMenuCanvasGO.SetActive(false);
        _settingsMenuCanvasGO.SetActive(false);
        _keyboardMenuCanvasGO.SetActive(false);
        _controllerMenuCanvasGO.SetActive(false);
        _inventoryCanvasGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
    }

    #endregion

    #region Main Menu Button Functions

    public void OnSettingsPress()
    {
        OpenSettingsMenuHandle();
    }

    public void OnKeyboardConfigPress()
    {
        OpenKeyboardConfigPressHandle();
    }

    public void OnControllerConfigPress()
    {
        OpenControllerConfigPressHandle();
    }

    public void OnInventoryPress()
    {
        OpenInventoryMenuHandle();
    }

    public void OnResumePress()
    {
        Unpause();
    }

    public void OnMenuPress()
    {
        Unpause();
        SceneController.Instance.LoadScene("Start_Scene");
    }

    #endregion

    #region Settings Menu Button Functions


    public void OnSettingsBackPress()
    {
        OpenMainMenu();
    }

    public void OnKeyboardConfigBackPress()
    {
        _keyboardMenuCanvasGO.SetActive(false);
        _settingsMenuCanvasGO.SetActive(true);

        EventSystem.current.SetSelectedGameObject(_settingsMenuFirst);
    }

    public void OnControllerConfigBackPress()
    {
        _controllerMenuCanvasGO.SetActive(false);
        _settingsMenuCanvasGO.SetActive(true);

        EventSystem.current.SetSelectedGameObject(_settingsMenuFirst);
    }

    public void OnInventoryBackPress()
    {
        _inventoryCanvasGO.SetActive(false);
        _mainMenuCanvasGO.SetActive(true);

        EventSystem.current.SetSelectedGameObject(_mainMenuFirst);
    }

    #endregion

    #region Inventory Check Functions

    public void CheckInventory()
    {
        if(PlayerManager.Instance.StarInfo1Unlocked)
        {
            _starInfo1Inventory.SetActive(true);
        }
        else
        {
            _starInfo1Inventory.SetActive(false);
        }

        if(PlayerManager.Instance.StarInfo2Unlocked)
        {
            _starInfo2Inventory.SetActive(true);
        }
        else
        {
            _starInfo2Inventory.SetActive(false);
        }

        if(PlayerManager.Instance.StarInfo3Unlocked)
        {
            _starInfo3Inventory.SetActive(true);
        }
        else
        {
            _starInfo3Inventory.SetActive(false);
        }

        if(PlayerManager.Instance.StarInfo4Unlocked)
        {
            _starInfo4Inventory.SetActive(true);
        }
        else
        {
            _starInfo4Inventory.SetActive(false);
        }
    }
    #endregion
}
