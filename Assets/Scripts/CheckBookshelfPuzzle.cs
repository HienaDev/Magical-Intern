using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class CheckBookshelfPuzzle : MonoBehaviour
{

    [HideInInspector] public int[] _bookOrder;
    [SerializeField] private int[] _rightBookOrder;

    [SerializeField] private UnityEvent _eventOnSolve;

    private bool _solved = false;

    // Start is called before the first frame update
    void Start()
    {
        _bookOrder = new int[] {1, 2, 3, 4, 5};
    }

    public void CheckPuzzle()
    {
        
   
        if (Enumerable.SequenceEqual(_bookOrder, _rightBookOrder) && !_solved)
        {
            _solved = true;
            _eventOnSolve.Invoke();
        }
    }


    public void SwapBookOrder(int p1, int p2)
    {

        int index1 = 0;
        int index2 = 0;

        for (int i = 0; i < _bookOrder.Length; i++)
        {
            if (_bookOrder[i] == p1)
            {
                index1 = i;

            }
            if (_bookOrder[i] == p2)
            {
                index2 = i;
            }

        }

        int temp = _bookOrder[index1];
        _bookOrder[index1] = _bookOrder[index2];
        _bookOrder[index2] = temp;


    }
}
