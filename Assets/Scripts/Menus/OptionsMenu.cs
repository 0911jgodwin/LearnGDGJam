using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider, _voiceSlider;

    public Text musicVolume;
    public Text sfxVolume;
    public Text voiceVolume;
    public void ToggleMusic()
    {
        float volume = AudioManager.i.musicSource.volume * 10;
        AudioManager.i.ToggleMusic();
        if (AudioManager.i.musicSource.mute)
        {
            musicVolume.text = "0";
        }
        else
        {
            musicVolume.text = $"{volume}";
        }

    }
    public void ToggleSfx()
    {
        float volume = AudioManager.i.sfxSource.volume * 10;
        AudioManager.i.ToggleSfx();
        if (AudioManager.i.sfxSource.mute)
        {
            sfxVolume.text = "0";
        }
        else
        {
            sfxVolume.text = $"{volume}";
        }
    }
    public void ToggleVoice()
    {
        float volume = AudioManager.i.voiceSource.volume * 10;
        AudioManager.i.ToggleVoice();
        if (AudioManager.i.voiceSource.mute)
        {
            voiceVolume.text = "0";
        }
        else
        {
            voiceVolume.text = $"{volume}";
        }
    }
    public void MusicVolume()
    {
        AudioManager.i.MusicVolume(_musicSlider.value);

        musicVolume.text = _musicSlider.value.ToString();
    }
    public void SfxVolume()
    {
        AudioManager.i.SfxVolume(_sfxSlider.value);

        sfxVolume.text = _musicSlider.value.ToString();
    }
    public void VoiceVolume()
    {
        AudioManager.i.VoiceVolume(_voiceSlider.value);

        voiceVolume.text = _musicSlider.value.ToString();
    }

    public void Return()
    {
        SceneManager.UnloadSceneAsync("OptionsMenu");
    }

}
