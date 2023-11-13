using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicGlasses : MonoBehaviour
{
    private Interactive _glasses;
    private PlayerInventory _playerInventory;
    public bool canUseGlasses = false;
    
    void Start()
    {
        _glasses = GetComponent<Interactive>();
        _playerInventory = GetComponent<PlayerInventory>();
    }

    public void UseGlasses (bool canUse)
    {
        if (canUse)
        {
            // Check if the player have the glasses selected on the inventory
            if (_playerInventory.IsSelected(_glasses))
            {
                Debug.Log("You can use the glasses");
            }
            else
            {
                Debug.Log("You can't use the glasses");
            }
        }
        else
        {
            Debug.Log("You can't use the glasses");
        }
    }

    void Update()
    {
        UseGlasses(canUseGlasses);
    }
}
