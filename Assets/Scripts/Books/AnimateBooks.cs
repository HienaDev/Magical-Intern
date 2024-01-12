using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class AnimateBooks : MonoBehaviour
{
    [SerializeField] private float _movementIncrement;
    [SerializeField] private float _finalPosition;
    [SerializeField] private float _movementIncrementSideways;

    [SerializeField] private float _floatingSpeed;
    [SerializeField] private float _floatingHeight;

    private bool    _selected = false;
    private float   _initialPositionX;
    private float   _initialPositionY;
    private Vector3 _auxPosition;

    private Vector3 _newPosition;
    private bool swapping;

    private BoxCollider _collider;

    private bool goingUp;

    private float rotation;
    private int rotations;

    private void Start()
    {
        _initialPositionX = transform.localPosition.x;
        _initialPositionY = transform.localPosition.y;

        _auxPosition = transform.localPosition;

        swapping = false;

        _collider = GetComponent<BoxCollider>();

        goingUp = true;

        rotation = 0.2f;

        rotations = 0;
    }

    private void FixedUpdate()
    {
        if (_selected)
        {
            _auxPosition.x -= _movementIncrement;
        }
        
        if(_auxPosition.x < _finalPosition)
        {
            _selected = false;
            Debug.Log("1:" + (_auxPosition.y < _initialPositionY + _floatingHeight));
            Debug.Log("2:" + (_auxPosition.y > _initialPositionY - _floatingHeight));

            Floating();
        }

        if (swapping)
        {
            Floating();

            if (_auxPosition.z < _newPosition.z)
            {
                _auxPosition.z += _movementIncrementSideways;

                if (_auxPosition.z > _newPosition.z)
                {
                    _auxPosition.x = _initialPositionX;
                    swapping = false;
                    _collider.enabled = true;
                }
            }
            else if (_auxPosition.z > _newPosition.z)
            {
                _auxPosition.z -= _movementIncrementSideways;

                if (_auxPosition.z < _newPosition.z)
                {
                    _auxPosition.x = _initialPositionX;
                    swapping = false;
                    _collider.enabled = true;
                }
            }
            else
            {
                swapping = false;
            }
        }

  

        transform.localPosition = _auxPosition;
    }

    public void BookSelect()
    {
        _selected = true;
        _collider.enabled = false;
    }

    public void Swapped(Transform _newPosition)
    {

        _auxPosition.x -= 0.1f;
        swapping = true;
        this._newPosition = _newPosition.localPosition;

        _collider.enabled = false;
    }


    public void Floating()
    {
        if (_auxPosition.y < _initialPositionY + _floatingHeight && goingUp)
        {
            _auxPosition.y += _floatingSpeed;
        }
        else
        {
            goingUp = false;
        }

        if (_auxPosition.y > _initialPositionY - _floatingHeight && !goingUp)
        {
            _auxPosition.y -= _floatingSpeed;
        }
        else
        {
            goingUp = true;
        }

        rotations++;

       
        transform.Rotate(0f, 0f, rotation);

        if (rotations % 10 == 9)
            rotation *= -1;
    }
 
}
