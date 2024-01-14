using UnityEngine;

public class Debugger : MonoBehaviour
{
    [SerializeField] private GameObject        _glasses;
    [SerializeField] private GameObject        _chessPiece;
    [SerializeField] private GameObject        _cheese;
    [SerializeField] private GameObject        _hourglass;
    [SerializeField] private GameObject        _key;
    [SerializeField] private GameObject        _memoryPotion;

    private PlayerInventory   _playerInventory;
    private UseInventoryItems _magicGlassesScriptReference;

    private void Start()
    {
        _playerInventory = GetComponent<PlayerInventory>();
        _magicGlassesScriptReference = GetComponent<UseInventoryItems>();
    }

    void Update()
    {
        if (!_playerInventory.IsFull())
        {   
            // Get glasses (max 1)
            if (Input.GetKey(KeyCode.LeftShift) && 
                Input.GetKeyDown(KeyCode.Alpha1) && 
                !_playerInventory.Contains(_glasses.GetComponent<Interactive>()))
            {
                _playerInventory.Add(_glasses.GetComponent<Interactive>());
            }

            // Get chess piece (max 4)
            if (Input.GetKey(KeyCode.LeftShift) && 
                Input.GetKeyDown(KeyCode.Alpha2) && 
                _playerInventory.GetItemCount(_chessPiece.GetComponent<Interactive>()) < 4)
            {
                _playerInventory.Add(_chessPiece.GetComponent<Interactive>());
            }

            // Get cheese (max 1)
            if (Input.GetKey(KeyCode.LeftShift) && 
                Input.GetKeyDown(KeyCode.Alpha3) &&
                !_playerInventory.Contains(_cheese.GetComponent<Interactive>()))
            {
                _playerInventory.Add(_cheese.GetComponent<Interactive>());
            }

            // Get hourglass (max 1)
            if (Input.GetKey(KeyCode.LeftShift) && 
                Input.GetKeyDown(KeyCode.Alpha4) &&
                !_playerInventory.Contains(_hourglass.GetComponent<Interactive>()))
            {
                _playerInventory.Add(_hourglass.GetComponent<Interactive>());
            }

            // Get memory potion (max 1)
            if (Input.GetKey(KeyCode.LeftShift) && 
                Input.GetKeyDown(KeyCode.Alpha5) &&
                !_playerInventory.Contains(_memoryPotion.GetComponent<Interactive>()))
            {
                _playerInventory.Add(_memoryPotion.GetComponent<Interactive>());
            }

            // Get  key (max 1)
            if (Input.GetKey(KeyCode.LeftShift) && 
                Input.GetKeyDown(KeyCode.Alpha6) &&
                !_playerInventory.Contains(_key.GetComponent<Interactive>()))
            {
                _playerInventory.Add(_key.GetComponent<Interactive>());
            }

            // Activate magic glasses
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Alpha7))
            {
                _magicGlassesScriptReference.CanUseGlasses();
            }
        }
    }
}
