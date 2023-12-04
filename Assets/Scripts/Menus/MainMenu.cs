using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Camera         mainCamera;
    [SerializeField] private Camera         menuCamera;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private GameObject     inGameUI;
    [SerializeField] private GameObject     mainMenuPanel;
    [SerializeField] private GameObject     settingsPanel;
    [SerializeField] private GameObject     creditsPanel;

    void Start()
    {
        mainCamera.enabled =     false;
        menuCamera.enabled =     true;
        playerMovement.enabled = false;
        inGameUI.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
    
    public void Play()
    {
        // TODO: Start Animation

        // TODO: After Animation:
        mainCamera.enabled =     true;
        menuCamera.enabled =     false;
        playerMovement.enabled = true;
        inGameUI.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void Settings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void Credits()
    {
        creditsPanel.SetActive(true);
    }

    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsPanel.activeSelf)
            {
                CloseSettings();
            }
            else if (creditsPanel.activeSelf)
            {
                CloseCredits();
            }
            else
            {
                Quit();
            }
        }
    }
}
