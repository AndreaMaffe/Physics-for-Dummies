using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    Ding,
    Pop,
    Boom,
    HardPop,
    Toc
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private AudioSource audioSource;
    public AudioClip ding;
    public AudioClip pop;
    public AudioClip boom;
    public AudioClip hardPop;
    public AudioClip toc;

    public AudioClip[] lessons;

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
        }
    }

    public void PlayLesson(int lessonIndex)
    {
        audioSource.PlayOneShot(lessons[lessonIndex], 1f);
    }
}
