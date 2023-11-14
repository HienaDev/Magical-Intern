using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Telescope : MonoBehaviour
{
    [SerializeField] private GameObject _telescopeVision;
    [SerializeField] private PlayerMovement _playerMovement;

    private bool _isWatching = false;

    public void LookingAtTheTelescope()
    {
        _isWatching = !_isWatching;

        if (_isWatching)
        {
            _telescopeVision.SetActive(true);
            _playerMovement.enabled = false;
        }
        else
        {
            _telescopeVision.SetActive(false);
            _playerMovement.enabled = true;
        }
    }
}
