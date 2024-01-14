using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RotateTelescope : MonoBehaviour
{

    private bool _rotating;

    [SerializeField] private PlayerMovement _playerScript;

    [SerializeField] private GameObject _rotateHorizontal;
    [SerializeField] private GameObject _rotateVertical;

    private float _verticalMouseSensitivity;
    private float _horizontalMouseSensitivity;

    private void Start()
    {
        _verticalMouseSensitivity = _playerScript.GetVerticalSensitivity();
        _horizontalMouseSensitivity = _playerScript.GetSensitivity();
    }

    // Update is called once per frame
    void Update()
    {
        if (_rotating && Input.GetKeyUp(KeyCode.E))
        {
            _rotating = false;
            _playerScript.EnableMovement();
        }


        if (_rotating)
        {

            _rotateHorizontal.transform.Rotate(0f, Input.GetAxis("Mouse X") * _horizontalMouseSensitivity, 0f);


            _rotateVertical.transform.Rotate(0f, 0f, Input.GetAxis("Mouse Y") * _verticalMouseSensitivity);

        }
    }

    public void ActivateRotation()
    {
        _rotating = true;
        _playerScript.DisableMovement();
    }
}
