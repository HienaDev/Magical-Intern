using UnityEngine;

public class Menus : MonoBehaviour
{
    [SerializeField] private Camera         _mainCamera;
    [SerializeField] private Camera         _menuCamera;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private GameObject     _inGameUI;
    [SerializeField] private GameObject     _mainMenuPanel;
    [SerializeField] private GameObject     _settingsPanel;
    [SerializeField] private GameObject     _creditsPanel;
    [SerializeField] private GameObject     _pauseMenuPanel;

    private bool _isOnMainMenu = true;

    void Start()
    {
        _mainCamera.enabled =     false;
        _menuCamera.enabled =     true;
        _playerMovement.enabled = false;
        _inGameUI.SetActive(false);
        _mainMenuPanel.SetActive(true);
    }

    public void Play()
    {
        // TODO: Start Animation

        // TODO: After Animation:
        _mainCamera.enabled =     true;
        _menuCamera.enabled =     false;
        _playerMovement.enabled = true;
        _inGameUI.SetActive(true);
        _mainMenuPanel.SetActive(false);
        _isOnMainMenu = false;
    }

    public void OpenSettings()
    {
        _settingsPanel.SetActive(true);

        if (_mainMenuPanel.activeSelf)
            _mainMenuPanel.SetActive(false);
        else if (_pauseMenuPanel.activeSelf)
            _pauseMenuPanel.SetActive(false);   
    }

    public void CloseSettings()
    {
        _settingsPanel.SetActive(false);

        if (_isOnMainMenu)
            _mainMenuPanel.SetActive(true);
        else if (!_isOnMainMenu)
            _pauseMenuPanel.SetActive(true);
    }

    public void OpenCredits()
    {
        _creditsPanel.SetActive(true);
        _mainMenuPanel.SetActive(false);
    }

    public void CloseCredits()
    {
        _creditsPanel.SetActive(false);
        _mainMenuPanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        _pauseMenuPanel.SetActive(false);
        _settingsPanel.SetActive(false);
        _inGameUI.SetActive(true);
        _playerMovement.enabled = true;
    }

    private void PauseGame()
    {
        _pauseMenuPanel.SetActive(true);
        _inGameUI.SetActive(false);
        _playerMovement.enabled = false;
    }

    public void GoToMainMenu()
    {
        _pauseMenuPanel.SetActive(false);
        _mainMenuPanel.SetActive(true);
        _playerMovement.enabled = false;
        _inGameUI.SetActive(false);
        _isOnMainMenu = true;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isOnMainMenu)
            {
                if (_creditsPanel.activeSelf)
                {
                    CloseCredits();
                }
                else if (_settingsPanel.activeSelf)
                {
                    CloseSettings();
                }
            }
            else if (!_isOnMainMenu)
            {
                if (_pauseMenuPanel.activeSelf || _settingsPanel.activeSelf)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }
    }
}
