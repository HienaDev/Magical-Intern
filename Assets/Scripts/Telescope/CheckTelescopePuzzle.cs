using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTelescopePuzzle : MonoBehaviour
{
    [SerializeField] private LayerMask _insigniaMask;

    // Update is called once per frame
    void Update()
    {
        
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 2, Color.red);

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, _insigniaMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            

            hit.collider.gameObject.GetComponent<ChangeInsignia>().ActivateShine();

        }
    }
}
