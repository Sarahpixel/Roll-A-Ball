using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    public AudioClip pickUpSound;
    public AudioClip winSound;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPickUpSound()
    {
        PlaySound(pickUpSound);
    }

    public void PlayWinSound()
    {
        PlaySound(winSound);
    }

    void PlaySound(AudioClip _newSound)
    {
        //set the audio sources audioclip to be the passed in sound
        audioSource.clip = _newSound;
        //plays the audio source
        audioSource.Play();
    }

    public void PlayCollisionSound(GameObject _go)
    {
        if (_go.GetComponent<AudioSource>() != null)
        {
            _go.GetComponent<AudioSource>().Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}


