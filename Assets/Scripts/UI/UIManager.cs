using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject         _interactionPanel;
    [SerializeField] private TextMeshProUGUI    _interactionMessage;
    [SerializeField] private TextMeshProUGUI    _inventorySelectedItemText;
    [SerializeField] private Image[]            _inventorySlots;
    [SerializeField] private Image[]            _inventoryIcons;
    [SerializeField] private Color              _unselectedColor;
    [SerializeField] private Color              _selectedColor;

    void Start()
    {
        HideInteractionPanel();
        HideInventoryIcons();
        HideInventorySlots();
        SelectInventorySlot(-1);
    }

    public void HideInteractionPanel()
    {
        _interactionPanel.SetActive(false);
    }

    public void ShowInteractionPanel(string message)
    {
        _interactionMessage.text = message;
        _interactionPanel.SetActive(true);
    }

    public int GetInventorySlotCount()
    {
        return _inventorySlots.Length;
    }

    public void HideInventoryIcons()
    {
        foreach (Image image in _inventoryIcons)
            image.enabled = false;
    }

    public void HideInventorySlots()
    {
        foreach (Image image in _inventorySlots)
            image.enabled = false;
    }

    public void ShowInventoryIcon(int index, Sprite icon)
    {
        _inventoryIcons[index].sprite   = icon;
        _inventoryIcons[index].enabled  = true;
    }

    public void ShowInventorySlot(int index)
    {
        _inventorySlots[index].enabled = true;
    }

    public void SelectInventorySlot(int index)
    {
        foreach (Image image in _inventorySlots)
        {
            Color color = image.color;
            color = _unselectedColor;
            image.color = color;
        }

        if (index != -1)
        {
            Color color = _inventorySlots[index].color;
            color = _selectedColor;

            _inventorySlots[index].color = color;
        }
    }

    public void ShowSelectedItemName(string itemName)
    {
        _inventorySelectedItemText.text = itemName;
    }
}
