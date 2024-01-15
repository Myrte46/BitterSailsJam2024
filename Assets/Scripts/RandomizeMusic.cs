using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeMusic : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource audioSource;

    void Awake()
    {
        audioSource.clip = clips[Random.Range(0, clips.Length)];
        audioSource.Play();
    }
}
