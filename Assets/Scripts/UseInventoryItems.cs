using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseInventoryItems : MonoBehaviour
{
    [SerializeField] private Interactive _glasses;
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private GameObject _magicalVisionPanel;
    [SerializeField] private GameObject _clueSequence;
    [SerializeField] private InteractiveData _glassesData;

    [SerializeField] private Interactive _memoryPotion;
    [SerializeField] private GameObject[] chessPieces;

    private bool canUseGlasses = false;

    public void UseGlasses(bool canUse)
    {
        if (canUse)
        {
            if (_playerInventory.IsSelected(_glasses))
            {
                _magicalVisionPanel.SetActive(!_magicalVisionPanel.activeSelf);
                _clueSequence.SetActive(!_clueSequence.activeSelf);
            }

        }

    }

    public void UseMemoryPotion()
    {

        if (_playerInventory.IsSelected(_memoryPotion))
        {
            _playerInventory.Remove(_memoryPotion);

            foreach (GameObject cp in chessPieces)
            {
                cp.SetActive(true);
            }
        }

    }

    public void CanUseGlasses()
    {
        canUseGlasses = true;
        _glassesData.inventoryName = "magical glasses";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_playerInventory.IsSelected(_memoryPotion))
                UseMemoryPotion();

            if (_playerInventory.IsSelected(_glasses))
                UseGlasses(canUseGlasses);

        }
    }
}
