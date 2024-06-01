using TMPro;
using UnityEngine;

public class PutIngredientsOnCauldron : MonoBehaviour
{
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private ChangeInsignia _insignia;
    [SerializeField] private GameObject _glasses;
    [SerializeField] private GameObject _cheese;
    [SerializeField] private GameObject _hourglass;
    [SerializeField] private GameObject _memoryPotion;
    [SerializeField] private GameObject _magicGlassesVision;
    [SerializeField] private GameObject _sequenceClue;

    [SerializeField] private Material _shinyMaterial;

    [SerializeField] private InteractiveData _cauldronScriptable;
    private bool _solved = false;

    private void Update()
    {
        if(!_solved)
            if (_playerInventory.Contains(_glasses.GetComponent<Interactive>()) &&
                _playerInventory.Contains(_cheese.GetComponent<Interactive>()) &&
                _playerInventory.Contains(_hourglass.GetComponent<Interactive>()) &&
                _insignia.GetMaterial().color == _shinyMaterial.color)
            {
                _cauldronScriptable.interactionMessages[0] = "Add the ingredients";
            }
            else
            {
                _cauldronScriptable.interactionMessages[0] = "The recipe isn't ready yet";
            }
    }

    public void PutIngredientIn()
    {

        if (_playerInventory.Contains(_glasses.GetComponent<Interactive>()) &&
            _playerInventory.Contains(_cheese.GetComponent<Interactive>()) &&
            _playerInventory.Contains(_hourglass.GetComponent<Interactive>()) &&
            _insignia.GetMaterial().color == _shinyMaterial.color)
        {
            _playerInventory.Remove(_glasses.GetComponent<Interactive>());
            _playerInventory.Remove(_cheese.GetComponent<Interactive>());
            _playerInventory.Remove(_hourglass.GetComponent<Interactive>());

            _glasses.SetActive(true);
            _cheese.SetActive(true);
            _hourglass.SetActive(true);

            // Disable magic glasses in case they are on
            _magicGlassesVision.SetActive(false);
            _sequenceClue.SetActive(false);

            _glasses.GetComponent<Animator>().SetTrigger("GoCauldron");
            _cheese.GetComponent<Animator>().SetTrigger("GoCauldron");
            _hourglass.GetComponent<Animator>().SetTrigger("GoCauldron");
            gameObject.GetComponent<Animator>().SetTrigger("GoCauldron");

            gameObject.GetComponent<Outline>().OutlineWidth = 0.001f;
            _cauldronScriptable.interactionMessages[0] = "";
            _solved = true;
        }
        

    }

    public void TriggerPotion() => _memoryPotion.SetActive(true);

    public bool GetSolved() => _solved;
}
