using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicGlasses : MonoBehaviour
{
    [SerializeField] private Interactive _glasses;
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private GameObject _magicalVisionPanel;

    private bool canUseGlasses = false;

    public void UseGlasses (bool canUse)
    {
        if (canUse)
        {
            if (_playerInventory.IsSelected(_glasses))
            {
                Debug.Log("Glasses selected");
                // Activate magical vision
                _magicalVisionPanel.SetActive(true);
            }
            else
            {
                Debug.Log("Glasses not selected");
                // Deactivate magical vision
                _magicalVisionPanel.SetActive(false);
            }
        }
        else
        {
            Debug.Log("You can't use the glasses");
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
