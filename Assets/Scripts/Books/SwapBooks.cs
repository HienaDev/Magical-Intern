using UnityEngine;

public class SwapBooks : MonoBehaviour
{
    private GameObject           _tempBook;
    private CheckBookshelfPuzzle _bookshelfScript;

    private void Start()
    {
        _bookshelfScript = GetComponentInParent<CheckBookshelfPuzzle>();
    }

    public void SwapBooksPosition(GameObject book)
    {
        if (_tempBook == null)
        {
            _tempBook = book;
            book.GetComponent<AnimateBooks>().BookSelect();
        }
        else
        {
            _tempBook.GetComponent<AnimateBooks>().Swapped(book.transform);
            book.GetComponent<AnimateBooks>().Swapped(_tempBook.transform);

            _bookshelfScript.SwapBookOrder(
                _tempBook.GetComponent<CheckBookPosition>().BookPosition, 
                book.GetComponent<CheckBookPosition>().BookPosition);

            

            _tempBook = null;
        }
    }
}
