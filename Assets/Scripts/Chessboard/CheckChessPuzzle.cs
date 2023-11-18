using UnityEngine;
using UnityEngine.Events;

public class CheckChessPuzzle : MonoBehaviour
{
    [SerializeField] private UnityEvent _onSolve;

    private int _rightPositionPieces = 0;

    public void CheckPuzzle()
    {
        _rightPositionPieces++;
        if(_rightPositionPieces >= 4)
        {
            GetComponent<Animator>().SetTrigger("Solved");
        }
    }
}
