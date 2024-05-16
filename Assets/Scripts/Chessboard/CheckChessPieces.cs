using UnityEngine;
using UnityEngine.Events;

public class CheckChessPieces : MonoBehaviour
{

    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private GameObject      _chessPiece;
    [SerializeField] private Material        _material;
    [SerializeField] private UnityEvent      _rightPiece;
    [SerializeField] private string pieceColor;

    public void CheckCorrectPiece()
    {
        if (_playerInventory.GetSelected()?.GetInteractiveName() == $"{pieceColor} Chess Piece" )
        {
            _playerInventory.Remove(_playerInventory.GetSelected());

            ReplacePieceWithRealPiece();
        }  
    }

    private void ReplacePieceWithRealPiece()
    {
        _rightPiece.Invoke();

        gameObject.GetComponent<Outline>().enabled = false;

        gameObject.GetComponent<BoxCollider>().enabled = false;

        gameObject.GetComponent<MeshRenderer>().material = _material;

    }
}
