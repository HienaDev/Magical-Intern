using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject     _pauseMenuPanel;
    [SerializeField] private GameObject     _mainMenuPanel;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private GameObject     _inGameUI;

    // Update is called once per frame
    void Update()
    {
        // if the main menu is not active and the player presses escape
        if (!_mainMenuPanel.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            // if the pause menu is active
            if (_pauseMenuPanel.activeSelf)
            {
                // resume the game
                Resume();
            }
            else
            {
                // pause the game
                Pause();
            }
        }
    }

    public void Resume()
    {
        _pauseMenuPanel.SetActive(false);
        _inGameUI.SetActive(true);
        _playerMovement.enabled = true;
    }

    private void Pause()
    {
        _pauseMenuPanel.SetActive(true);
        _inGameUI.SetActive(false);
        _playerMovement.enabled = false;
        _playerMovement.ShowCursor();
    }

    public void MainMenu()
    {
        _pauseMenuPanel.SetActive(false);
        _mainMenuPanel.SetActive(true);
        _playerMovement.enabled = false;
        _inGameUI.SetActive(false);
    }
}
