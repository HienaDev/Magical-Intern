using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeInteractive : MonoBehaviour
{

    [SerializeField] private InteractiveData newInteractive;
    private Interactive interactiveScript;

    private void Start()
    {
        interactiveScript = GetComponent<Interactive>();
    }
    public void ChangeInteractiveData()
    {
        interactiveScript.SetInteractiveData(newInteractive);
    }
}
