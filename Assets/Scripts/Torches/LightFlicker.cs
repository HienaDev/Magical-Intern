using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{

    [SerializeField] private float intensityChange;
    [SerializeField] private float timerFlicker;
    [SerializeField] private float timerPosition;
    [SerializeField] private float positionChange;

    private float justFlicked;
    private float justMoved;
    private float startingIntensity;
    private Vector3 startingPosition;
    private Light lightTorch;


    // Start is called before the first frame update
    void Start()
    {
        lightTorch = GetComponent<Light>();   
        startingIntensity = lightTorch.intensity;
        startingPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - justFlicked > timerFlicker)
        {
            justFlicked = Time.time;
            lightTorch.intensity = startingIntensity + Random.Range(-intensityChange, intensityChange);
        }

        if (Time.time - justMoved > timerPosition)
        {
            justMoved = Time.time;
            gameObject.transform.position = new Vector3(startingPosition.x + Random.Range(-positionChange, positionChange), startingPosition.y, startingPosition.z);
        }
    }
}
