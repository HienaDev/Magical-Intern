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
            book.GetComponent<AnimateBooks>().BookSelect();
        }
        else
        {
            

            tempBook.GetComponent<AnimateBooks>().Swapped(book.transform);
            book.GetComponent<AnimateBooks>().Swapped(tempBook.transform);

            bookshelfScript.SwapBookOrder(
                tempBook.GetComponent<CheckBookPosition>().BookPosition, 
                book.GetComponent<CheckBookPosition>().BookPosition);

            

            tempBook = null;
        }
    }
}
