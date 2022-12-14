using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

namespace DiTichCoDoHue
{
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

        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlayAudioOneShotByName(AudioList.Dragon);
            }
        }
        public void PlayAudioByIndex(int index) //Phát audio bằng Index
        {
            //TODO: validate index
            if (index >= audios.Length || index < 0)
            {
                return;
            }
            PlayAudio(audios[index].audioClip);
        }

        public void PlayAudioByAudioName(AudioList audioName) //Phát Audio bằng tên
        {
            foreach (var audio in audios)
            {
                if (audio.audioName == audioName)
                {
                    PlayAudio(audio.audioClip);
                    return;
                }
            }
            Debug.Log("Not Found!!!" + audioName);
        }

        public void PlayAudioOneShotByName(AudioList audioName) //Phát OneShot Audio bằng Tên
        {
            foreach (var audio in audios)
            {
                if (audio.audioName == audioName)
                {
                    PlayAudioOneShot(audio.audioClip);
                    return;
                }
            }
            Debug.Log("Not Found!!!" + audioName);
        }


        private void PlayAudio(AudioClip audioclip) //Phát Audio
        {
            audioSource.clip = audioclip;
            audioSource.Play();
            audioSource.loop = true;
        }

        private void PlayAudioOneShot(AudioClip audioOneShot) //Phát OneShot Audio
        {
            audioSource.PlayOneShot(audioOneShot, 0.75f);
        }
    }
}

