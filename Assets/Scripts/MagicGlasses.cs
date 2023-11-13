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

    private bool canUseGlasses = false;

    public void UseGlasses (bool canUse)
    {
        if (canUse)
        {
            if (_playerInventory.IsSelected(_glasses))
            {
                _magicalVisionPanel.SetActive(true);
                _clueSequence.SetActive(true);
            }
            else
            {
                _magicalVisionPanel.SetActive(false);
                _clueSequence.SetActive(false);
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
    }

    void Update()
    {
        UseGlasses(canUseGlasses);
    }
}
