using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuckooSounds : MonoBehaviour
{

    [SerializeField] private AudioClip[] _tickingSounds;
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayTickingSound()
    {
        _audioSource.clip = _tickingSounds[Random.Range(0, _tickingSounds.Length)];

        _audioSource.Play();
    }
}
