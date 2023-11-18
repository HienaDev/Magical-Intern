using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckChessPieces : MonoBehaviour
{

    [SerializeField] private PlayerInventory _playerInventory;

    [SerializeField] private GameObject _chessPiece;

    [SerializeField] private UnityEvent _triggerChessPiece;

    public void CheckCorrectPiece()
    {
        if (_playerInventory.IsSelected(_chessPiece.GetComponent<Interactive>()))
        {
            _playerInventory.Remove(_chessPiece.GetComponent<Interactive>());

            Debug.Log("corret piece");
            _triggerChessPiece.Invoke();
        }
    }
}
