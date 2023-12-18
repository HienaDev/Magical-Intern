using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RotateTelescope : MonoBehaviour
{

    private bool rotating;

    [SerializeField] private PlayerMovement playerScript;

    [SerializeField] private GameObject rotateHorizontal;
    [SerializeField] private GameObject rotateVertical;

    [SerializeField] private float maxRotation;

    private float _verticalMouseSensitivity;
    private float _horizontalMouseSensitivity;

    private void Start()
    {
        _verticalMouseSensitivity = playerScript.GetVerticalSensitivity();
        _horizontalMouseSensitivity = playerScript.GetSensitivity();
    }

    // Update is called once per frame
    void Update()
    {
        if (rotating && Input.GetKeyUp(KeyCode.E))
        {
            Debug.Log("pressed");
            rotating = false;
            playerScript.EnableMovement();
        }


        if (rotating)
        {
            //Vector3 rotationH = rotateHorizontal.transform.localEulerAngles;
            //Vector3 rotationV = rotateVertical.transform.localEulerAngles;

            

            //rotationV.z -= Input.GetAxis("Mouse Y") * _verticalMouseSensitivity;

            
            //rotationH.x -= Input.GetAxis("Mouse X") * _horizontalMouseSensitivity;

            rotateHorizontal.transform.Rotate(0f, Input.GetAxis("Mouse X") * _horizontalMouseSensitivity, 0f);


            rotateVertical.transform.Rotate(0f, 0f, Input.GetAxis("Mouse Y") * _verticalMouseSensitivity);

            Debug.Log(rotateHorizontal.transform.rotation);

            //Debug.Log(rotationH.x);

            //rotationH.x = Mathf.Clamp(rotationH.x, -70f, 70f);

            //rotateHorizontal.transform.localEulerAngles = rotationH;
            //rotateVertical.transform.localEulerAngles = rotationV;
        }
    }

    public void ActivateRotation()
    {
        rotating = true;
        playerScript.DisableMovement();
    }
}
