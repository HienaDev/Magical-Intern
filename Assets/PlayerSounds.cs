using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] stepsSound;
    private AudioSource audioSource;

    [SerializeField] private float timeBetweenSteps;

    private PlayerMovement playerScript;



    private float justStep;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        playerScript = GetComponent<PlayerMovement>();

        justStep = timeBetweenSteps;


        Debug.Log("step");
    }


    private void Update()
    {
        if (Time.time - justStep > timeBetweenSteps)
        {
            justStep = Time.time;
            if (playerScript.GetHasSpeed())
            {
                PlayStepsSound();
                Debug.Log("step");
            }
        }
    }



    public void PlayStepsSound()
    {
        audioSource.clip = stepsSound[Random.Range(0, stepsSound.Length)];

        audioSource.Play();
    }
}
