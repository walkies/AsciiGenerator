using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Audio")]
public class ScriptableAudio : ScriptableObject
{
    public AudioClip[] Clip;
    [Range(0f,2f)]
    public float Pitch;
    [Range(0f, 100f)]
    public float Volume;
    private AudioSource Source;
    

    public void SetSource(AudioSource Source2)
    {
        for (int i = 0; i < Clip.Length; i++)
        {
            Source = Source2;
            Source.clip = Clip[i];
        }
    }

    public void Play()
    {
        for (int i = 0; i < Clip.Length; i++)
        {
            Source.PlayOneShot(Clip[i]);
        }
    }
}
/*
 * Scriptable objects created as New Audio
 * Contains variables for audioclips
 * Set source of Audio
 * Play function 
 */
