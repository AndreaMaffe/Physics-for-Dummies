﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    Ding,
    Pop,
    Boom,
    HardPop,
    Toc,
    Tic
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource audioSource { get; set; }
    public AudioClip ding;
    public AudioClip pop;
    public AudioClip boom;
    public AudioClip hardPop;
    public AudioClip toc;
    public AudioClip tic;

    public AudioClip[] lessons;
    public AudioClip audioTest;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioTest != null)
            audioSource.PlayOneShot(audioTest);
    }

    public void PlaySound(SoundType soundType)
    {
        switch(soundType)
        {
            case SoundType.Ding: audioSource.PlayOneShot(ding, 1f);
                break;
            case SoundType.Pop: audioSource.PlayOneShot(pop, 1f);
                break;
            case SoundType.Boom: audioSource.PlayOneShot(boom, 1f);
                break;
            case SoundType.HardPop: audioSource.PlayOneShot(hardPop, 1f);
                break;
            case SoundType.Toc: audioSource.PlayOneShot(toc, 1f);
                break;
            case SoundType.Tic: audioSource.PlayOneShot(tic, 1f);
                break;
        }
    }

    public void PlayLesson(int lessonIndex)
    {
        if (audioSource.isPlaying)
            audioSource.Stop();
        else 
            audioSource.PlayOneShot(lessons[lessonIndex], 1f);
    }

    public void StopAudio()
    {
        if (audioSource.isPlaying)
            audioSource.Stop();
    }
}
