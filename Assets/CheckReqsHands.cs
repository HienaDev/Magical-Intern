using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckReqsHands : MonoBehaviour
{

    [SerializeField] private CountInteractions minuteHand;
    [SerializeField] private CountInteractions hourHand;

    private Animator cuckooAnimator;

    private void Awake()
    {
        cuckooAnimator = GetComponent<Animator>();
    }
    public void CheckReqs()
    {
        if (minuteHand.RightPosition == true && hourHand.RightPosition == true)
        {
            cuckooAnimator.SetTrigger("Cuckoo");
        }
    }
}
