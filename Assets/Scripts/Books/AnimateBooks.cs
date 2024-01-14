using UnityEngine;
using UnityEngine.Events;

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
    private bool _swapping;

    private BoxCollider _collider;

    private bool _goingUp;

    private float _rotation;
    private int _rotations;

    [SerializeField] private UnityEvent _bookSelect;

    private AudioSource _floatingSound;


    private void Start()
    {
        _initialPositionX = transform.localPosition.x;
        _initialPositionY = transform.localPosition.y;

        _auxPosition = transform.localPosition;

        _swapping = false;

        _collider = GetComponent<BoxCollider>();

        _goingUp = true;

        _rotation = 0.2f;

        _rotations = 0;

        _floatingSound = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        _floatingSound.enabled = _swapping;

        if (_selected)
        {
            _auxPosition.x -= _movementIncrement;
        }
        
        if(_auxPosition.x < _finalPosition)
        {
            _selected = false;

            Floating();
        }

        if (_swapping)
        {

            Floating();

            if (_auxPosition.z < _newPosition.z)
            {
                _auxPosition.z += _movementIncrementSideways;

                if (_auxPosition.z > _newPosition.z)
                {
                    _auxPosition.x = _initialPositionX;
                    _swapping = false;
                    _collider.enabled = true;
                }
            }
            else if (_auxPosition.z > _newPosition.z)
            {
                _auxPosition.z -= _movementIncrementSideways;

                if (_auxPosition.z < _newPosition.z)
                {
                    _auxPosition.x = _initialPositionX;
                    _swapping = false;
                    _collider.enabled = true;
                }
            }
            else
            {
                
                _swapping = false;
                
            }
        }

       

        transform.localPosition = _auxPosition;
    }

    public void BookSelect()
    {
        _bookSelect.Invoke();
        _selected = true;
        _collider.enabled = false;
    }

    public void Swapped(Transform _newPosition)
    {

        _auxPosition.x -= 0.1f;
        _swapping = true;
        this._newPosition = _newPosition.localPosition;

        _collider.enabled = false;
    }


    public void Floating()
    {

        if (_auxPosition.y < _initialPositionY + _floatingHeight && _goingUp)
        {
            _auxPosition.y += _floatingSpeed;
        }
        else
        {
            _goingUp = false;
        }

        if (_auxPosition.y > _initialPositionY - _floatingHeight && !_goingUp)
        {
            _auxPosition.y -= _floatingSpeed;
        }
        else
        {
            _goingUp = true;
        }

        _rotations++;

       
        transform.Rotate(0f, 0f, _rotation);

        if (_rotations % 10 == 9)
            _rotation *= -1;
    }
 
}
