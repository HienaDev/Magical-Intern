using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTelescopePuzzle : MonoBehaviour
{
    [SerializeField] private LayerMask insigniaMask;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Hello");
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 2, Color.red);

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, insigniaMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log(hit.collider.gameObject.name);

            hit.collider.gameObject.GetComponent<ChangeInsignia>().ActivateShine();

        }
    }
}
