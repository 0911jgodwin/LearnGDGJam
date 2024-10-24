using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using Learn.PlayerController;
using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    Fader fader;
    private MenuInput _menuInput;
    private int _selectedIndex = 0;
    private float navigationSpeed = 0.3f;
    private float navigationLockout = 0f;
    private bool soundOptionsOpen = false;
    public List<Button> MenuButtons;
    public bool optionsOpen = false;


    private void Awake()
    {
        _menuInput = GetComponent<MenuInput>();
    }

    private void Start()
    {
        fader = GetComponent<Fader>();
        EventSystem.current.SetSelectedGameObject(MenuButtons[_selectedIndex].gameObject, new BaseEventData(EventSystem.current));
    }

    void Update()
    {
        if(PlayerInputManager.Instance.OptionsOpen)
            optionsOpen = true;
        if (PlayerInputManager.Instance.OptionsOpen)
            return;
            
        if (optionsOpen)
        {
            optionsOpen = false;
            PlayerInputManager.Instance.PlayerControls.PlayerMovementMap.Disable();
            PlayerInputManager.Instance.PlayerControls.MenuMap.Enable();
            _selectedIndex = 0;
            _menuInput.Reenable();
            EventSystem.current.SetSelectedGameObject(MenuButtons[_selectedIndex].gameObject, new BaseEventData(EventSystem.current));
        }
            
        navigationLockout -= Time.deltaTime;
        if (navigationLockout <= 0f && _menuInput.NavigationInput != Vector2.zero)
        {
            Debug.Log("Test");
            Navigate(_menuInput.NavigationInput);
            navigationLockout = navigationSpeed;
        }

        if (_menuInput.SelectPressed)
        {
            SelectButton();
        }
    }

    private void SelectButton()
    {
        switch (_selectedIndex)
        {
            case 0:
                PlayGame();
                break;
            case 1:
                Options();
                break;
            case 2:
                QuitGame();
                break;
            default:
                break;
        }
    }

    private void Navigate(Vector2 navigationInput)
    {
        if (navigationInput.y < 0f)
            _selectedIndex += 1;
        if (navigationInput.y > 0f)
            _selectedIndex -= 1;

        if (_selectedIndex <= -1 )
            _selectedIndex = 2;

        if (_selectedIndex >= 3)
            _selectedIndex = 0;

        EventSystem.current.SetSelectedGameObject(MenuButtons[_selectedIndex].gameObject, new BaseEventData(EventSystem.current));
    }

    public void PlayGame()
    {
        StartCoroutine(fader.Fading("IntroScene"));
    }
    public void Options()
    {
        SceneManager.LoadSceneAsync("OptionsMenu", LoadSceneMode.Additive);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        // DELETE BEFORE FINAL BUILD
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
