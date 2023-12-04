using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{

    [SerializeField] private float flickerIntensity;
    [SerializeField] private float flickersPerSecond;
    [SerializeField] private float speedRandomness;

    private float time;
    private float startingIntensity;
    private Light light;


    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();   
        startingIntensity = light.intensity;    
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * (1 - Random.Range(-speedRandomness, speedRandomness)) * Mathf.PI;

        light.intensity = startingIntensity + Mathf.Sin(time * flickersPerSecond) * flickerIntensity;
    }
}
