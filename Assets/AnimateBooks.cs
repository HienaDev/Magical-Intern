using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class AnimateBooks : MonoBehaviour
{

    private bool _selected = false;
    [SerializeField] private float _movementIncrement;
    
    [SerializeField] private float _finalPosition;
    private float _initialPosition;


    private Vector3 _auxPosition;

    private void Start()
    {
        _initialPosition = transform.localPosition.x;
      
        _auxPosition = transform.localPosition;
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
        }

        Debug.Log("aux: " + _auxPosition + " final " + _finalPosition);

        transform.localPosition = _auxPosition;
    }

    public void BookSelect()
    {
        _selected = true;
    }

    public void Swapped(Transform _newPosition)
    {
        _auxPosition = _newPosition.localPosition;
        _auxPosition.x = -0.15f;
    }
}
