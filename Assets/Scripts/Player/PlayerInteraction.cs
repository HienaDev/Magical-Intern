using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private UIManager  _uiManager;
    [SerializeField] private float      _maxInteractionDistance;

    private Transform   _cameraTransform;
    private Interactive _currentInteractive;
    private bool        _refreshCurrentInteractive;
    private bool        _interactionPanelShown;

    void Start()
    {
        _cameraTransform            = GetComponentInChildren<Camera>().transform;
        _currentInteractive         = null;
        _refreshCurrentInteractive  = false;
        _interactionPanelShown      = true;
    }

    void Update()
    {
        UpdateCurrentInteractive();
        CheckForPlayerInteraction();
    }

    private void UpdateCurrentInteractive()
    {
        if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward,
            out RaycastHit hitInfo, _maxInteractionDistance))
        { 
            CheckObjectForInteraction(hitInfo.collider);
            //Debug.Log(hitInfo.collider.gameObject.name); Displays on console what object we're looking at
        }
        else if (_currentInteractive != null)
            ClearCurrentInteractive();
    }

    private void CheckObjectForInteraction(Collider collider)
    {
        Interactive interactive = collider.GetComponent<Interactive>();

        if (interactive == null || !interactive.isOn)
        {
            if (_currentInteractive != null)
                ClearCurrentInteractive();
        }
        else if (interactive != _currentInteractive || _refreshCurrentInteractive)
            SetCurrentInteractive(interactive);
    }

    private void ClearCurrentInteractive()
    {
        _currentInteractive.SetOutline(false);
        _currentInteractive = null;
        _uiManager.HideInteractionPanel();
        _uiManager.ShowSelectedItemCrosshair(false);
    }

    private void SetCurrentInteractive(Interactive interactive)
    {
        if (_currentInteractive != null)
            _currentInteractive.SetOutline(false);
            
        _currentInteractive         = interactive;
        _refreshCurrentInteractive  = false;
        _uiManager.ShowSelectedItemCrosshair(true);

        string interactionMessage = interactive.GetInteractionMessage();

        if (_currentInteractive != null)
            _currentInteractive.SetOutline(true);

        if ((_interactionPanelShown && 
            interactionMessage != null && 
            interactionMessage.Length > 0) || 
            (interactive.interactiveData.canShowTheInteractionMessageContinuously
             && interactionMessage != null && 
             interactionMessage.Length > 0))
        {
            _uiManager.ShowInteractionPanel(interactionMessage);
        }
        else
        {
            _uiManager.HideInteractionPanel();
        }
    }

    private void CheckForPlayerInteraction()
    {
        if ((_currentInteractive != null) && 
        (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Mouse0)))
        {
            _currentInteractive.Interact();
            _refreshCurrentInteractive = true;
            _interactionPanelShown = false;
        }
    }

    public void ForceRefreshCurrentInteractive()
    {
        _refreshCurrentInteractive = true;
    }
}