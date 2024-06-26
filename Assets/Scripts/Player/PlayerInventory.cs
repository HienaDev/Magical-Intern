using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private int       _maxItems;

    private PlayerInteraction   _playerInteraction;
    private List<Interactive>   _inventory;
    private int                 _selectedSlot;

    private PlayerSounds _sounds;

    void Start()
    {
        _playerInteraction  = GetComponent<PlayerInteraction>();
        _inventory          = new List<Interactive>();
        _selectedSlot       = -1;
        _sounds = GetComponent<PlayerSounds>();
    }

    public void Add(Interactive item)
    {
        _inventory.Add(item);

        _sounds.PlayPickUpSound();

        _uiManager.ShowInventoryIcon(_inventory.Count - 1, item.inventoryIcon);
        _uiManager.ShowInventorySlot(_inventory.Count - 1);

        if (_inventory.Count == 1)
            SelectInventorySlot(0);

        SelectInventorySlot(_inventory.Count - 1);
    }

    public void Remove(Interactive item)
    {
        _inventory.Remove(item);

        _uiManager.HideInventoryIcons();
        _uiManager.HideInventorySlots();

        for (int i = 0; i < _inventory.Count; ++i)
        {
            _uiManager.ShowInventoryIcon(i, _inventory[i].inventoryIcon);
            _uiManager.ShowInventorySlot(i);
        }

        if (_selectedSlot == _inventory.Count)
            SelectInventorySlot(_selectedSlot - 1);
    }

    public bool Contains(Interactive item)
    {
        foreach(Interactive i in _inventory)
        {
            if (i == item)
                return true;
        }
        return false;
    }

    public bool IsFull()
    {
        return _inventory.Count == _maxItems;
    }

    private void SelectInventorySlot(int index)
    {
        if (index != _selectedSlot)
        {
            _sounds.PlayScrollSound();
            _selectedSlot = index;
            _uiManager.SelectInventorySlot(index);
            _playerInteraction.ForceRefreshCurrentInteractive();
        }
    }

    public string GetSelectedInteractionMessage()
    {
        return _selectedSlot != -1 ? _inventory[_selectedSlot].GetInteractionMessage() : null;
    }

    public bool IsSelected(Interactive item)
    {
        return _selectedSlot != -1 && _inventory[_selectedSlot] == item;
    }

    public Interactive GetSelected()
    {
        return _selectedSlot != -1 ? _inventory[_selectedSlot] : null;
    }

    void Update()
    {
        CheckForPlayerSlotSelection();
        CheckIfTheItemIsUsable();
        UpdateCurrentSelectedItemName();
    }

    private void CheckForPlayerSlotSelection()
    {
        if (_inventory.Count != 0)
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)    
                SelectInventorySlot((_selectedSlot + 1) % _inventory.Count);
            else if (Input.GetAxis("Mouse ScrollWheel") > 0f)
                SelectInventorySlot((_selectedSlot - 1 + _inventory.Count) % _inventory.Count);
    }

    public void UpdateCurrentSelectedItemName()
    {
        if (_selectedSlot != -1)
            _uiManager.ShowSelectedItemName(_inventory[_selectedSlot].inventoryName);
        else
            _uiManager.ShowSelectedItemName(null);
    }

    public void CheckIfTheItemIsUsable()
    {
        if (_selectedSlot != -1 && _inventory[_selectedSlot].isUsable)
            _uiManager.ShowTextForUsableItem(_selectedSlot, _inventory[_selectedSlot]);
        else
            _uiManager.ShowTextForUsableItem(-1, null);
    }

    public void SelectedItemHaveChanged()
    {
        _playerInteraction.ForceRefreshCurrentInteractive();
    }

    public int GetItemCount(Interactive item)
    {
        int count = 0;

        foreach (Interactive i in _inventory)
        {
            if (i == item)
                count++;
        }

        return count;
    }
}