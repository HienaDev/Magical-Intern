using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] stepsSound;
    private AudioSource audioSourceSteps;
    [SerializeField] private AudioMixerGroup stepsMixer;

    [SerializeField] private AudioClip pickUpSound;
    private AudioSource audioSourcePickUp;
    [SerializeField] private AudioMixerGroup pickUpMixer;

    [SerializeField] private float timeBetweenSteps;

    private PlayerMovement playerScript;



    private float justStep;

    // Start is called before the first frame update
    void Start()
    {
        audioSourceSteps = gameObject.AddComponent<AudioSource>();
        audioSourcePickUp = gameObject.AddComponent<AudioSource>();

        audioSourcePickUp.spatialBlend = 1;
        audioSourceSteps.spatialBlend = 1;

        audioSourcePickUp.volume = 0.2f;
        audioSourceSteps.volume = 0.2f;

        playerScript = GetComponent<PlayerMovement>();

        justStep = timeBetweenSteps;
            


    }


    private void Update()
    {
        if (Time.time - justStep > timeBetweenSteps)
        {
            justStep = Time.time;
            if (playerScript.GetHasSpeed())
            {
                PlayStepsSound();

            }
        }
    }



    public void PlayStepsSound()
    {
        audioSourceSteps.clip = stepsSound[Random.Range(0, stepsSound.Length)];

        audioSourceSteps.Play();
    }

    public void PlayPickUpSound()
    {
        audioSourcePickUp.clip = pickUpSound;

        audioSourcePickUp.Play();
    }
}
