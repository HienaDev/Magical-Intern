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
        if (_rotating && (Input.GetKeyUp(KeyCode.E) || Input.GetMouseButtonUp(0)))
        {
            _rotating = false;
            _playerScript.EnableMovement();
        }


        if (_rotating)
        {

            _rotateHorizontal.transform.Rotate(0f, Input.GetAxis("Mouse X") * _horizontalMouseSensitivity, 0f);

            if (_rotateHorizontal.transform.eulerAngles.y < 230)
                _rotateHorizontal.transform.eulerAngles = new Vector3(_rotateHorizontal.transform.eulerAngles.x, 230, _rotateHorizontal.transform.eulerAngles.z);

            if (_rotateHorizontal.transform.eulerAngles.y > 280)
                _rotateHorizontal.transform.eulerAngles = new Vector3(_rotateHorizontal.transform.eulerAngles.x, 280, _rotateHorizontal.transform.eulerAngles.z);

            _rotateVertical.transform.Rotate(0f, 0f, Input.GetAxis("Mouse Y") * _verticalMouseSensitivity);

            if (_rotateVertical.transform.eulerAngles.z < 320)
                _rotateVertical.transform.eulerAngles = new Vector3(_rotateVertical.transform.eulerAngles.x, _rotateVertical.transform.eulerAngles.y, 320);

            if (_rotateVertical.transform.eulerAngles.z > 350)
                _rotateVertical.transform.eulerAngles = new Vector3(_rotateVertical.transform.eulerAngles.x, _rotateVertical.transform.eulerAngles.y, 350);
        }
    }

    public void ActivateRotation()
    {
        _rotating = true;
        _playerScript.DisableMovement();
    }
}
