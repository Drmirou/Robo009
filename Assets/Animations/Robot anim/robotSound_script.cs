using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotSound_script : MonoBehaviour
{

    public AudioClip footSound;
    AudioSource footSoundSource;

    private void Start()
    {
        footSoundSource = GetComponent<AudioSource>();
    }
    public void FootSound()
    {
        footSoundSource.PlayOneShot(footSound);
    }
}
