using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    public static AudioManager i;
    public Sound[] musicSounds, sfxSounds, voiceSounds;
    public AudioSource musicSource, sfxSource, voiceSource;
    [SerializeField] public AudioClip typingSound;


    private void Awake()
    {
        if(i==null)
        {
            i = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("LevelMusic");
    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, m => m.name == name);

        if(s == null)
        {
            Debug.Log("Sound not found!");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySfx(string name)
    {
        Sound s = Array.Find(sfxSounds, m => m.name == name);

        if (s == null)
        {
            Debug.Log("Sfx not found!");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }
    public void PlayVoice(string name)
    {
        Sound s = Array.Find(voiceSounds, m => m.name == name);

        if (s == null)
        {
            Debug.Log("Voice not found!");
        }
        else
        {
            voiceSource.PlayOneShot(s.clip);
        }
    }

    public IEnumerator PlayTyping(int loopCount, int letterSpeed)
    {
        if (typingSound == null)
        {
            Debug.Log("Voice not found!");
        }
        else
        {
            for (int i = 0; i < loopCount/3; i++)
            {
                voiceSource.PlayOneShot(typingSound);
                yield return new WaitForSeconds(3f / letterSpeed);
            }
        }
    }
    public void StopVoice()
    {
        voiceSource?.Stop();
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
    public void ToggleSfx()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void ToggleVoice()
    {
        voiceSource.mute = !voiceSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume / 10;
    }

    public void SfxVolume(float volume)
    {
        sfxSource.volume = volume / 10;
    }
    public void VoiceVolume(float volume)
    {
        voiceSource.volume = volume / 10;
    }
}
