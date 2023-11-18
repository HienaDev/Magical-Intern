using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicGlasses : MonoBehaviour
{
    [SerializeField] private Interactive _glasses;
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private GameObject _magicalVisionPanel;
    [SerializeField] private GameObject _clueSequence;
    [SerializeField] private InteractiveData _glassesData;

    private bool canUseGlasses = false;

    public void UseGlasses (bool canUse)
    {
        if (canUse)
        {
            if (_playerInventory.IsSelected(_glasses) && Input.GetKeyDown(KeyCode.E))
            {
                _magicalVisionPanel.SetActive(!_magicalVisionPanel.activeSelf);
                _clueSequence.SetActive(!_magicalVisionPanel.activeSelf);
            }

        }
        else
        {
            return;
        }
    }

    public void CanUseGlasses()
    {
        canUseGlasses = true;
        _glassesData.inventoryName = "magical glasses";
    }

    void Update()
    {
        UseGlasses(canUseGlasses);
    }
}
