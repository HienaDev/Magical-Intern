using UnityEngine;
using Cinemachine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _mainCamera;
    [SerializeField] private CinemachineVirtualCamera _menuCamera;
    [SerializeField] private CinemachineBrain         _cinemachineBrain;
    [SerializeField] private GameObject               _objectToLookAt;
    [SerializeField] private GameObject               _objectToResetTheMenuCamera;
    [SerializeField] private GameObject               _originalObjectToLookAt;
    [SerializeField] private PlayerMovement           _playerMovement;
    [SerializeField] private GameObject               _inGameUI;
    [SerializeField] private GameObject               _mainMenuPanel;
    [SerializeField] private GameObject               _settingsPanel;
    [SerializeField] private GameObject               _creditsPanel;
    [SerializeField] private GameObject               _pauseMenuPanel;
    [SerializeField] private AudioSource[]            _allAudio;
    [SerializeField] private PlayerSounds             _playerSounds;

    private bool _isOnMainMenu = true;
    private bool _finalCredits = false;
    public bool _FinalCredits => _finalCredits;

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
        _menuCamera.m_Follow = _playerMovement.transform;
        _menuCamera.m_LookAt = _objectToLookAt.transform;

        _mainMenuPanel.SetActive(false);
        _playerMovement.HideCursor();

        Invoke("ChangeToGameCamera", 4f);
    }

    private void ChangeToGameCamera()
    {
        _mainCamera.enabled = true;
        _menuCamera.enabled = false;

        Invoke("ActivatePlayerMovementAndUI", _cinemachineBrain.m_DefaultBlend.m_Time);

        _isOnMainMenu = false;
    }

    private void ActivatePlayerMovementAndUI()
    {
        _playerMovement.enabled = true;
        _inGameUI.SetActive(true);
    }

    private void ActivateMainMenu()
    {
        _mainMenuPanel.SetActive(true);
    }

    public void GoToMainMenu()
    {
        _menuCamera.m_Follow = _objectToResetTheMenuCamera.transform;
        _menuCamera.m_LookAt = _originalObjectToLookAt.transform;

        _mainCamera.enabled = false;
        _menuCamera.enabled = true;

        _pauseMenuPanel.SetActive(false);
        _playerMovement.enabled = false;
        _inGameUI.SetActive(false);
        _isOnMainMenu = true;

        _playerMovement.enabled = false;
        _inGameUI.SetActive(false);

        Time.timeScale = 1f;

        Invoke("ActivateMainMenu", 2f);
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

        foreach(AudioSource audio in _allAudio)
        {
            audio.enabled = false;
        }
        _playerSounds.enabled = false;

        if (!_isOnMainMenu)
        {
            _inGameUI.SetActive(false);
            _finalCredits = true;
        }
    }

    public void CloseCredits()
    {
        _creditsPanel.SetActive(false);
        _mainMenuPanel.SetActive(true);

        foreach (AudioSource audio in _allAudio)
        {
            audio.enabled = true;
        }
        _playerSounds.enabled = true;
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
        Time.timeScale = 1f;
    }

    private void PauseGame()
    {
        _pauseMenuPanel.SetActive(true);
        _inGameUI.SetActive(false);
        _playerMovement.enabled = false;
        Time.timeScale = 0f;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isOnMainMenu && !_finalCredits)
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
            else if (!_isOnMainMenu && !_finalCredits)
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

    public void EndOfFinalCredits()
    {

        if (_finalCredits)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        _finalCredits = false;
        
        Debug.Log("End of final credits");
    }
}