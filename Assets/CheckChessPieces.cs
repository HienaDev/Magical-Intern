using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckChessPieces : MonoBehaviour
{

    [SerializeField] private PlayerInventory _playerInventory;

    [SerializeField] private GameObject _chessPiece;

    public void CheckCorrectPiece()
    {
        if (_playerInventory.GetSelected().GetInteractiveName() == "ChessPiece" )
        {
            _playerInventory.Remove(_playerInventory.GetSelected());

            Debug.Log("corret piece");
        }
        else
        {
            Debug.Log(_playerInventory.GetSelected().GetInteractiveName());
            Debug.Log("Wrong piece");
        }    
    }
}
