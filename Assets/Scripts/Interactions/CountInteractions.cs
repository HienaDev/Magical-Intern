using UnityEngine;

public class CountInteractions : MonoBehaviour
{

    private Interactive _interactive;

    [SerializeField] private int _numberOfInteractions;

    [SerializeField] private int _rightPosition;
    public bool RightPosition { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        _interactive = GetComponent<Interactive>();
    }


    public void CheckReqs()
    {
        RightPosition = _interactive.GetInteractionCount() % _rightPosition == _numberOfInteractions;
    }
}
