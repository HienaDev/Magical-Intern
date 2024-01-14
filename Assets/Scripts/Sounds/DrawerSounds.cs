using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DrawerSounds : MonoBehaviour
{

    [SerializeField] private AudioClip _drawerOpen;
    [SerializeField] private AudioClip _drawerClose;

    [SerializeField] private AudioSource _audioSourceDrawer;




    public void PlayOpenDrawer()
    {
        _audioSourceDrawer.clip = _drawerOpen;

        _audioSourceDrawer.Play();
    }

    public void PlayCloseDrawer()
    {
        _audioSourceDrawer.clip = _drawerClose;

        _audioSourceDrawer.Play();
    }
}
