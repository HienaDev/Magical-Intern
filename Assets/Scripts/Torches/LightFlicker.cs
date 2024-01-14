using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{

    [SerializeField] private float _intensityChange;
    [SerializeField] private float _timerFlicker;
    [SerializeField] private float _timerPosition;
    [SerializeField] private float _positionChange;

    private float _justFlicked;
    private float _justMoved;
    private float _startingIntensity;
    private Vector3 _startingPosition;
    private Light _lightTorch;


    // Start is called before the first frame update
    void Start()
    {
        _lightTorch = GetComponent<Light>();   
        _startingIntensity = _lightTorch.intensity;
        _startingPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - _justFlicked > _timerFlicker)
        {
            _justFlicked = Time.time;
            _lightTorch.intensity = _startingIntensity + Random.Range(-_intensityChange, _intensityChange);
        }

        if (Time.time - _justMoved > _timerPosition)
        {
            _justMoved = Time.time;
            gameObject.transform.position = new Vector3(_startingPosition.x + Random.Range(-_positionChange, _positionChange), _startingPosition.y, _startingPosition.z);
        }
    }
}
