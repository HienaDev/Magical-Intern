using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Camera         _mainCamera;
    [SerializeField] private Camera         _menuCamera;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private GameObject     _inGameUI;
    [SerializeField] private GameObject     _mainMenuPanel;
    [SerializeField] private GameObject     _settingsPanel;
    [SerializeField] private GameObject     _creditsPanel;

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
        _playerMovement.ShowCursor();
    }

    public void Settings()
    {
        _settingsPanel.SetActive(true);
        _mainMenuPanel.SetActive(false);
    }

    public void CloseSettings()
    {
        _settingsPanel.SetActive(false);
        _mainMenuPanel.SetActive(true);
    }

    public void Credits()
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

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_settingsPanel.activeSelf)
            {
                CloseSettings();
            }
            else if (_creditsPanel.activeSelf)
            {
                CloseCredits();
            }
        }
    }
}
