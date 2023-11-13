using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapBooks : MonoBehaviour
{
    private GameObject tempBook;

    private CheckBookshelfPuzzle bookshelfScript;


    private void Start()
    {
        bookshelfScript = GetComponentInParent<CheckBookshelfPuzzle>();
    }

    public void SwapBooksPosition(GameObject book)
    {
        if (tempBook == null)
        {
            tempBook = book;
        }
        else
        {
            Vector3 tempPosition = tempBook.transform.position;
            tempBook.transform.position = book.transform.position;
            book.transform.position = tempPosition;

            bookshelfScript.SwapBookOrder(
                tempBook.GetComponent<CheckBookPosition>().BookPosition, 
                book.GetComponent<CheckBookPosition>().BookPosition);

            tempBook = null;
        }
    }
}
