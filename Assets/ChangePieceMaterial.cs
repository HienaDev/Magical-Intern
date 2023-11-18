using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePieceMaterial : MonoBehaviour
{

    [SerializeField] private Material material;

    public void ChangeMaterial()
    {
        gameObject.GetComponent<MeshRenderer>().material = material;
    }
}
