using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] _stepsSound;
    private AudioSource _audioSourceSteps;
    [SerializeField] private AudioMixerGroup _stepsMixer;

    [SerializeField] private AudioClip _pickUpSound;
    private AudioSource _audioSourcePickUp;
    [SerializeField] private AudioMixerGroup _pickUpMixer;

    [SerializeField] private AudioClip _scrollSound;
    private AudioSource _audioSourceScroll;
    [SerializeField] private AudioMixerGroup _scrollMixer;

    [SerializeField] private AudioClip _drinkSound;
    private AudioSource _audioSourceDrink;
    [SerializeField] private AudioMixerGroup _drinkMixer;

    [SerializeField] private AudioClip _glassesSound;
    private AudioSource _audioSourceGlasses;
    [SerializeField] private AudioMixerGroup _glassesMixer;

    [SerializeField] private float _timeBetweenSteps;

    private PlayerMovement _playerScript;



    private float justStep;

    // Start is called before the first frame update
    void Start()
    {
        _audioSourceSteps = gameObject.AddComponent<AudioSource>();
        _audioSourceSteps.outputAudioMixerGroup = _stepsMixer;

        _audioSourcePickUp = gameObject.AddComponent<AudioSource>();
        _audioSourcePickUp.outputAudioMixerGroup = _pickUpMixer;

        _audioSourceScroll = gameObject.AddComponent<AudioSource>();
        _audioSourceScroll.outputAudioMixerGroup = _scrollMixer;

        _audioSourceDrink = gameObject.AddComponent<AudioSource>();
        _audioSourceDrink.outputAudioMixerGroup = _drinkMixer;

        _audioSourceGlasses = gameObject.AddComponent<AudioSource>();
        _audioSourceGlasses.outputAudioMixerGroup = _glassesMixer;

        _audioSourcePickUp.spatialBlend = 1;
        _audioSourceSteps.spatialBlend = 1;
        _audioSourceDrink.spatialBlend = 1;

        _audioSourcePickUp.volume = 0.2f;
        _audioSourceSteps.volume = 0.2f;
        _audioSourceScroll.volume = 0.2f;
        _audioSourceDrink.volume = 0.2f;
        _audioSourceGlasses.volume = 0.4f;

        _audioSourcePickUp.clip = _pickUpSound;
        _audioSourceScroll.clip = _scrollSound;
        _audioSourceDrink.clip = _drinkSound;
        _audioSourceGlasses.clip = _glassesSound;

        _playerScript = GetComponent<PlayerMovement>();

        justStep = _timeBetweenSteps;
            


    }


    private void Update()
    {
        if (Time.time - justStep > _timeBetweenSteps)
        {
            justStep = Time.time;
            if (_playerScript.GetHasSpeed())
            {
                PlayStepsSound();

            }
        }
    }



    public void PlayStepsSound()
    {
        _audioSourceSteps.clip = _stepsSound[Random.Range(0, _stepsSound.Length)];

        _audioSourceSteps.Play();
    }

    public void ChangeStepSound(float value) => _audioSourceSteps.volume = value;

    public void PlayPickUpSound() => _audioSourcePickUp.Play();

    public void PlayScrollSound() => _audioSourceScroll.Play();

    public void PlayDrinkSound() => _audioSourceDrink.Play();

    public void PlayGlassesSound() => _audioSourceGlasses.Play();

}
