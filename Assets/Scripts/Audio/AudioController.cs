using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public enum AudioList { Dragon = 0, Pic1 = 1, Pic2 = 2 };


[System.Serializable]
public class Audio
{
    public AudioList audioName;
    public AudioClip audioClip;
}

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;

    [SerializeField] private AudioSource audioSource;

    [SerializeField] private Audio[] audios;

    private void Awake()
    {
        Instance = this;
        PlayAudioByIndex();
    }

    public void PlayAudioByIndex(int index)
    {
        //TODO: validate index
        if(index > audios.Length || index < 0)
        {
            return;
        }
        PlayAudio(audios[index].audioClip);
    }

    public void PlayAudioByAudioName(AudioList audioName)
    {
        foreach (var audio in audios)
        {
            if (audio.audioName == audioName)
            {
                PlayAudio(audio.audioClip);
            }
        }
    }


    private void PlayAudio(AudioClip audioclip)
    {
        audioSource.clip = audioclip;
        audioSource.Play();
        audioSource.loop = true;
    }
}
