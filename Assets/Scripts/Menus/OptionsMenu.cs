using Learn.PlayerController;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    private MenuInput _menuInput;
    public Slider _musicSlider, _sfxSlider, _voiceSlider;
    public Button _exitButton;
    private List<Selectable> MenuItems;

    public Text musicVolume;
    public Text sfxVolume;
    public Text voiceVolume;

    public Image muteMusic;
    public Image muteSfx;
    public Image muteVoice;

    private int _selectedIndex = 0;
    private float navigationSpeed = 0.3f;
    private float navigationLockout = 0f;

    private void Awake()
    {
        _menuInput = GetComponent<MenuInput>();
        PlayerInputManager.Instance.OptionsOpen = true;
        MenuItems = new List<Selectable>();
    }

    private void Start()
    {
        MenuItems.Add(_musicSlider);
        MenuItems.Add(_sfxSlider);
        MenuItems.Add(_voiceSlider);
        MenuItems.Add(_exitButton);

        PlayerInputManager.Instance.PlayerControls.PlayerMovementMap.Disable();
        PlayerInputManager.Instance.PlayerControls.MenuMap.Enable();
        EventSystem.current.SetSelectedGameObject(MenuItems[_selectedIndex].gameObject, new BaseEventData(EventSystem.current));
    }

    private void Update()
    {
        navigationLockout -= Time.deltaTime;
        if (navigationLockout <= 0f && _menuInput.NavigationInput != Vector2.zero)
        {
            navigationLockout = navigationSpeed;
            Navigate(_menuInput.NavigationInput);
        }

        if (_menuInput.SelectPressed)
        {
            SelectButton();
        }
    }

    private void Navigate(Vector2 navigationInput)
    {
        if (0 <= _selectedIndex && _selectedIndex <= 2)
        {
            if (navigationInput.x < 0)
                ChangeValue(_selectedIndex, -1);
            else if (navigationInput.x > 0)
                ChangeValue(_selectedIndex, 1);
        }

        if (navigationInput.y < 0f)
            _selectedIndex += 1;
        if (navigationInput.y > 0f)
            _selectedIndex -= 1;

        if (_selectedIndex <= -1)
            _selectedIndex = 3;

        if (_selectedIndex >= 4)
            _selectedIndex = 0;

        EventSystem.current.SetSelectedGameObject(MenuItems[_selectedIndex].gameObject, new BaseEventData(EventSystem.current));
    }

    private void ChangeValue(int index, int v)
    {
        Slider slider = null;
        switch (index)
        {
            case 0:
                slider = _musicSlider;
                break;
            case 1:
                slider = _sfxSlider;
                break;
            case 2:
                slider = _voiceSlider;
                break;
        }

        float value = slider.value;
        value = Mathf.Clamp(value + v, 0f, 10f);

        slider.value = value;

        switch (index)
        {
            case 0:
                slider = _musicSlider;
                break;
            case 1:
                slider = _sfxSlider;
                break;
            case 2:
                slider = _voiceSlider;
                break;
        }
    }

    private void SelectButton()
    {
        switch (_selectedIndex)
        {
            case 0:
                ToggleMusic();
                break;
            case 1:
                ToggleSfx();
                break;
            case 2:
                ToggleVoice();
                break;
            case 3:
                Return();
                break;
        }
    }

    public void ToggleMusic()
    {
        float volume = AudioManager.i.musicSource.volume * 10;
        AudioManager.i.ToggleMusic();
        if (AudioManager.i.musicSource.mute)
        {
            musicVolume.text = "0";
            muteMusic.enabled = true;
        }
        else
        {
            musicVolume.text = $"{volume}";
            muteMusic.enabled = false;
        }

    }
    public void ToggleSfx()
    {
        float volume = AudioManager.i.sfxSource.volume * 10;
        AudioManager.i.ToggleSfx();
        if (AudioManager.i.sfxSource.mute)
        {
            sfxVolume.text = "0";
            muteSfx.enabled = true;
        }
        else
        {
            sfxVolume.text = $"{volume}";
            muteSfx.enabled = false;
        }
    }
    public void ToggleVoice()
    {
        float volume = AudioManager.i.voiceSource.volume * 10;
        AudioManager.i.ToggleVoice();
        if (AudioManager.i.voiceSource.mute)
        {
            voiceVolume.text = "0";
            muteVoice.enabled = true;
        }
        else
        {
            voiceVolume.text = $"{volume}";
            muteVoice.enabled = false;
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

        sfxVolume.text = _sfxSlider.value.ToString();
    }
    public void VoiceVolume()
    {
        AudioManager.i.VoiceVolume(_voiceSlider.value);

        voiceVolume.text = _voiceSlider.value.ToString();
    }

    public void Return()
    {
        PlayerInputManager.Instance.OptionsOpen = false;
        PlayerInputManager.Instance.PlayerControls.PlayerMovementMap.Enable();
        PlayerInputManager.Instance.PlayerControls.MenuMap.Disable();
        SceneManager.UnloadSceneAsync("OptionsMenu");
    }

}
