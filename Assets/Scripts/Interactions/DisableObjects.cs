using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObjects : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsThatStartDisabled;
    void Start()
    {
        foreach( GameObject g in objectsThatStartDisabled)
        {
            g.SetActive(false);
        }
    }


}
