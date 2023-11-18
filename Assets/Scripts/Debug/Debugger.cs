using UnityEngine;

public class Debugger : MonoBehaviour
{
    [SerializeField] private UseInventoryItems _magicGlassesScriptReference;
    [SerializeField] private GameObject        _glasses;
    [SerializeField] private GameObject        _chessPiece;
    [SerializeField] private GameObject        _cheese;
    [SerializeField] private GameObject        _hourglass;
    [SerializeField] private GameObject        _key;
    [SerializeField] private GameObject        _memoryPotion;

    private PlayerInventory _playerInventory;

    private void Start()
    {
        _playerInventory = GetComponent<PlayerInventory>();
    }

    void Update()
    {
        if (!_playerInventory.IsFull())
        {
            // Get small magical glasses
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Alpha1))
            {
                _playerInventory.Add(_glasses.GetComponent<Interactive>());
            }

            // Get chess piece
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Alpha2))
            {
                _playerInventory.Add(_chessPiece.GetComponent<Interactive>());
            }

            // Get cheese
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Alpha3))
            {
                _playerInventory.Add(_cheese.GetComponent<Interactive>());
            }

            // Get hourglass
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Alpha4))
            {
                _playerInventory.Add(_hourglass.GetComponent<Interactive>());
            }

            // Get memory potion
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Alpha5))
            {
                _playerInventory.Add(_memoryPotion.GetComponent<Interactive>());
            }

            // Get key
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Alpha6))
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
