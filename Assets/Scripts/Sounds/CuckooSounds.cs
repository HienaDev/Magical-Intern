using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuckooSounds : MonoBehaviour
{

    [SerializeField] private AudioClip[] tickingSounds;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayTickingSound()
    {
        audioSource.clip = tickingSounds[Random.Range(0, tickingSounds.Length)];

        audioSource.Play();
    }
}
