using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;

public class PutIngredientsOnCauldron : MonoBehaviour
{

    [SerializeField] private GameObject _glasses;
    [SerializeField] private GameObject _cheese;
    [SerializeField] private GameObject _hourglass;
    [SerializeField] private GameObject _memoryPotion;

    [SerializeField] private GameObject _magicGlassesVision;

    private bool _position1;
    private bool _position2;
    private bool _position3;

    [SerializeField] private PlayerInventory _playerInventory;

    [SerializeField] private CountInteractions _insignia;

    public void PutIngredientIn()
    {
        if (_playerInventory.Contains(_glasses.GetComponent<Interactive>()) &&
            _playerInventory.Contains(_cheese.GetComponent<Interactive>()) &&
            _playerInventory.Contains(_hourglass.GetComponent<Interactive>()) &&
            _insignia.RightPosition)
        {

            _playerInventory.Remove(_glasses.GetComponent<Interactive>());
            _playerInventory.Remove(_cheese.GetComponent<Interactive>());
            _playerInventory.Remove(_hourglass.GetComponent<Interactive>());

            _glasses.SetActive(true);
            _cheese.SetActive(true);
            _hourglass.SetActive(true);

            // Disable magic glasses in case they are on
            _magicGlassesVision.SetActive(false);

            _glasses.GetComponent<Animator>().SetTrigger("GoCauldron");
            _cheese.GetComponent<Animator>().SetTrigger("GoCauldron");
            _hourglass.GetComponent<Animator>().SetTrigger("GoCauldron");
            gameObject.GetComponent<Animator>().SetTrigger("GoCauldron");
        }
        else
            Debug.Log("Not ready");

        Debug.Log(_insignia.RightPosition);

    }

    public void TriggerPotion() => _memoryPotion.SetActive(true);



}
