using UnityEngine;

public class CheckReqsHands : MonoBehaviour
{
    [SerializeField] private CountInteractions _minuteHand;
    [SerializeField] private CountInteractions _hourHand;

    private Animator _cuckooAnimator;

    private void Awake()
    {
        _cuckooAnimator = GetComponent<Animator>();
    }
    public void CheckReqs()
    {
        if (_minuteHand.RightPosition == true && _hourHand.RightPosition == true)
        {
            _cuckooAnimator.SetTrigger("Cuckoo");
        }
    }
}
