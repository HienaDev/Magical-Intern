using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountInteractions : MonoBehaviour
{

    private Interactive interactive;

    public bool RightPosition { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        interactive = GetComponent<Interactive>();
    }


    public void CheckReqs()
    {
        if (interactive.GetInteractionCount() % 12 == 9)
        {
            RightPosition = true;
        }
        else
        {
            RightPosition = false;
        }

        Debug.Log( gameObject.name + " " + interactive.GetReqsMet());
    }
}
