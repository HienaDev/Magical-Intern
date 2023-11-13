using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class CheckBookshelfPuzzle : MonoBehaviour
{

    [HideInInspector] public int[] bookOrder;
    [SerializeField] private int[] rightBookOrder;

    [SerializeField] private UnityEvent eventOnSolve;


    // Start is called before the first frame update
    void Start()
    {
        bookOrder = new int[] {1, 2, 3, 4, 5};
    }

    public void CheckPuzzle()
    {
        
   
        if (Enumerable.SequenceEqual(bookOrder, rightBookOrder))
        {
            
            eventOnSolve.Invoke();
        }
    }


    public void SwapBookOrder(int p1, int p2)
    {

        int index1 = 0;
        int index2 = 0;

        for (int i = 0; i < bookOrder.Length; i++)
        {
            if (bookOrder[i] == p1)
            {
                index1 = i;

            }
            if (bookOrder[i] == p2)
            {
                index2 = i;
            }

        }

        int temp = bookOrder[index1];
        bookOrder[index1] = bookOrder[index2];
        bookOrder[index2] = temp;


    }
}
