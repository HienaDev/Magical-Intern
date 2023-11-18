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

    [SerializeField] private UnityEvent onSolve;

    private bool _position1;
    private bool _position2;
    private bool _position3;

    [SerializeField] private PlayerInventory _playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PutIngredientIn()
    {
        if (_playerInventory.Contains(_glasses.GetComponent<Interactive>()) &&
            _playerInventory.Contains(_cheese.GetComponent<Interactive>()) &&
            _playerInventory.Contains(_hourglass.GetComponent<Interactive>()))
        {

            _playerInventory.Remove(_glasses.GetComponent<Interactive>());
            _playerInventory.Remove(_cheese.GetComponent<Interactive>());
            _playerInventory.Remove(_hourglass.GetComponent<Interactive>());

            _glasses.SetActive(true);
            _cheese.SetActive(true);
            _hourglass.SetActive(true);

            _glasses.GetComponent<Animator>().SetTrigger("GoCauldron");
            _cheese.GetComponent<Animator>().SetTrigger("GoCauldron");
            _hourglass.GetComponent<Animator>().SetTrigger("GoCauldron");
            gameObject.GetComponent<Animator>().SetTrigger("GoCauldron");
        }
        else
            Debug.Log("Not ready");
    }



}
