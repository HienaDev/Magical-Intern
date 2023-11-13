using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactive : MonoBehaviour
{
    [SerializeField] private InteractiveData _interactiveData;

    private InteractionManager  _interactionManager;
    private PlayerInventory     _playerInventory;
    private List<Interactive>   _requirements;
    private List<Interactive>   _dependents;
    private Animator            _animator;
    private Outline             _outline;
    private bool                _requirementsMet;
    private int                 _interactionCount;
    
    public bool isOn;
    public UnityEvent onPicked;
    public UnityEvent onRequirementsMet;
    public UnityEvent onInteracted;

    public InteractiveData interactiveData
    {
        get { return _interactiveData; }
    }

    public string inventoryName
    {
        get { return _interactiveData.inventoryName; }
    }

    public Sprite inventoryIcon
    {
        get { return _interactiveData.inventoryIcon; }
    }

    private bool IsType(InteractiveData.Type type)
    {
        return _interactiveData.type == type;
    }

    void Awake()
    {

        _interactionManager = InteractionManager.instance;
        _playerInventory    = _interactionManager.playerInventory;
        _requirements       = new List<Interactive>();
        _dependents         = new List<Interactive>();
        _animator           = GetComponent<Animator>();
        _outline            = GetComponent<Outline>();
        _requirementsMet    = _interactiveData.requirements.Length == 0;
        _interactionCount   = 0;

        isOn = _interactiveData.startsOn;

        _interactionManager.RegisterInteractive(this);
    }

    public void AddRequirement(Interactive requirement)
    {
        _requirements.Add(requirement);
    }

    public void AddDependent(Interactive dependent)
    {
        _dependents.Add(dependent);
    }

    public string GetInteractionMessage()
    {
        if (IsType(InteractiveData.Type.Pickable) && !_playerInventory.Contains(this) && _requirementsMet)
            return _interactionManager.pickMessage.Replace("%", _interactiveData.inventoryName);
        else if (!_requirementsMet)
        {
            if (PlayerHasRequirementSelected())
                return _playerInventory.GetSelectedInteractionMessage();
            else
                return _interactiveData.requirementsMessage;
        }
        else if (interactiveData.interactionMessages.Length > 0)
            return interactiveData.interactionMessages[_interactionCount % interactiveData.interactionMessages.Length];
        else
            return null;
    }

    private bool PlayerHasRequirementSelected()
    {
        foreach (Interactive requirement in _requirements)
            if (_playerInventory.IsSelected(requirement))
                return true;

        return false;
    }

    public void Interact()
    {
        if (_requirementsMet)
            InteractSelf(true);
        else if (PlayerHasRequirementSelected())
            UseRequirementInInventory();
    }

    private void InteractSelf(bool direct)
    {
        if (direct && IsType(InteractiveData.Type.Indirect))
            return;
        else if (IsType(InteractiveData.Type.Pickable))
        {
            _playerInventory.Add(this);
            gameObject.SetActive(false);
            onPicked.Invoke();
        }
        else if (IsType(InteractiveData.Type.InteractOnce) || IsType(InteractiveData.Type.InteractMulti))
        {
            ++_interactionCount;
            CheckDependentsRequirements();
            InteractIndirectDependents();

            if (IsType(InteractiveData.Type.InteractOnce))
                isOn = false;
            
        }

        if(IsType(InteractiveData.Type.Pickable))
            onPicked.Invoke();
        else
            onInteracted.Invoke();

        if (_animator != null && !IsType(InteractiveData.Type.Pickable))
            _animator.SetTrigger("Interact");
    }

    private void CheckDependentsRequirements()
    {
        foreach (Interactive dependent in _dependents)
            dependent.CheckRequirements();
    }

    private void CheckRequirements()
    {
        foreach (Interactive requirement in _requirements)
        {
            if (!requirement._requirementsMet ||
               (!requirement.IsType(InteractiveData.Type.Indirect) && requirement._interactionCount == 0))
            {
                _requirementsMet = false;
                return;
            }
        }

        _requirementsMet = true;
        onRequirementsMet.Invoke();

        if (_animator != null)
            _animator.SetTrigger("RequirementsMet");

        CheckDependentsRequirements();
    }

    private void InteractIndirectDependents()
    {
        foreach (Interactive dependent in _dependents)
            if (dependent._requirementsMet && dependent.IsType(InteractiveData.Type.Indirect))
                dependent.InteractSelf(false);
    }

    private void UseRequirementInInventory()
    {
        Interactive requirement = _playerInventory.GetSelected();

        _playerInventory.Remove(requirement);

        ++requirement._interactionCount;

        if (requirement._animator != null)
        {
            requirement.gameObject.SetActive(true);
            requirement._animator.SetTrigger("Interact");
        }

        CheckRequirements();
    }

    public void SetOutline(bool enabled)
    {
        if (_outline != null)
            _outline.enabled = enabled;
    }

    public int GetInteractionCount() => _interactionCount;

    public bool GetReqsMet() => _requirementsMet;

    public void SetRequirementsMet(bool toggle) => _requirementsMet = toggle;
}