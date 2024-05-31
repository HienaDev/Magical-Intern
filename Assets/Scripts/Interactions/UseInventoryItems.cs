using UnityEngine;
using Cinemachine;
using System.Collections;

public class UseInventoryItems : MonoBehaviour
{
    [SerializeField] private Interactive                _glasses;
    [SerializeField] private Interactive                _memoryPotion;    
    [SerializeField] private GameObject                 _magicalVisionPanel;
    [SerializeField] private GameObject                 _clueSequence;
    [SerializeField] private InteractiveData            _glassesData;
    [SerializeField] private GameObject[]               _chessPieces;
    [SerializeField] private CinemachineVirtualCamera   _mainCamera;
    [SerializeField] private Transform                  _chessBoardTransform;

    private bool            _canUseGlasses;
    private PlayerMovement  _playerMovement;
    private PlayerInventory _playerInventory;
    private PlayerSounds    _sounds;

    private void Start()
    {
        _canUseGlasses      = false;
        _playerMovement     = GetComponent<PlayerMovement>();
        _playerInventory    = GetComponent<PlayerInventory>();
        _sounds             = GetComponent<PlayerSounds>();
    }

    private void UseGlasses(bool canUse)
    {
        if (canUse)
        {
            if (_playerInventory.IsSelected(_glasses))
            {
                _sounds.PlayGlassesSound();
                _magicalVisionPanel.SetActive(!_magicalVisionPanel.activeSelf);
                _clueSequence.SetActive(!_clueSequence.activeSelf);
            }
        }
    }

    private void UseMemoryPotion()
    {
        if (_playerInventory.IsSelected(_memoryPotion))
        {
            _sounds.PlayDrinkSound();
            _playerInventory.Remove(_memoryPotion);

            foreach (GameObject cp in _chessPieces)
            {
                cp.SetActive(true);
            }
        }
    }

    private void LookAtChessBoard()
    {
        StartCoroutine(RotateTowardsChessBoard());
    }

     private IEnumerator RotateTowardsChessBoard()
    {
        _sounds.ChangeStepSound(0f);
        _playerMovement.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        _mainCamera.LookAt = _chessBoardTransform;

        float duration = 2.0f;
        float time = 0;
        Quaternion startRotation = transform.rotation;

        while (time < duration)
        {
            time += Time.deltaTime;
            Quaternion cameraRotation = _mainCamera.transform.rotation;
            transform.rotation = Quaternion.Slerp(startRotation, Quaternion.Euler(0, cameraRotation.eulerAngles.y, 0), time / duration);
            yield return null;
        }

        Quaternion finalCameraRotation = _mainCamera.transform.rotation;
        transform.rotation = Quaternion.Euler(0, finalCameraRotation.eulerAngles.y, 0);

        _mainCamera.LookAt = null;
        _playerMovement.enabled = true;
        _sounds.ChangeStepSound(0.2f);
    }

    public void CanUseGlasses()
    {
        _canUseGlasses = true;
        _glasses.isUsable = true;
        _glasses.SetInteractiveData(_glassesData);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_playerInventory.IsSelected(_memoryPotion))
            {
                UseMemoryPotion();
                LookAtChessBoard();
            }

            else if (_playerInventory.IsSelected(_glasses))
                UseGlasses(_canUseGlasses);
        }
    }
}