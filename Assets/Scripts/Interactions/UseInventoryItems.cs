using UnityEngine;

public class UseInventoryItems : MonoBehaviour
{
    [SerializeField] private Interactive     _glasses;
    [SerializeField] private Interactive     _memoryPotion;
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private GameObject      _magicalVisionPanel;
    [SerializeField] private GameObject      _clueSequence;
    [SerializeField] private InteractiveData _glassesData;
    [SerializeField] private GameObject[]    _chessPieces;

    private bool _canUseGlasses = false;

    private PlayerSounds _sounds;

    private void Start()
    {
        _sounds = GetComponent<PlayerSounds>();
    }

    public void UseGlasses(bool canUse)
    {
        if (canUse)
        {

            if (_playerInventory.IsSelected(_glasses))
            {
                _sounds.PlayGlassesSound();
                _magicalVisionPanel.SetActive(!_magicalVisionPanel.activeSelf);
                _clueSequence.SetActive(!_clueSequence.activeSelf);
            }

        }
    }

    public void UseMemoryPotion()
    {
        if (_playerInventory.IsSelected(_memoryPotion))
        {
            _sounds.PlayDrinkSound();
            _playerInventory.Remove(_memoryPotion);

            foreach (GameObject cp in _chessPieces)
            {
                cp.SetActive(true);
            }
        }
    }

    public void CanUseGlasses()
    {
        _canUseGlasses = true;
        _glasses.isUsable = true;
        _glasses.SetInteractiveData(_glassesData);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_playerInventory.IsSelected(_memoryPotion))
                UseMemoryPotion();

            else if (_playerInventory.IsSelected(_glasses))
                UseGlasses(_canUseGlasses);
        }
    }
}
