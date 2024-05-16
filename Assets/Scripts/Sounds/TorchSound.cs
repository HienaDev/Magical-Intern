using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchSound : MonoBehaviour
{

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.time = Random.Range(0.0f, audioSource.clip.length);
        Debug.Log(audioSource.time);
        audioSource.Play();
    }


}
