using UnityEngine.SceneManagement;
using System.Collections;
using Learn.PlayerController;
using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class ReplayMenu : MonoBehaviour
{
    Fader fader;
    private MenuInput _menuInput;
    private int _selectedIndex = 0;
    private float navigationSpeed = 0.3f;
    private float navigationLockout = 0f;
    public List<Button> MenuButtons;

    private void Awake()
    {
        _menuInput = PlayerInputManager.Instance.GetMenuInput();
    }

    private void Start()
    {
        fader = GetComponent<Fader>();
        EventSystem.current.SetSelectedGameObject(MenuButtons[_selectedIndex].gameObject, new BaseEventData(EventSystem.current));
        AudioManager.i.PlayMusic("Theme");
    }

    private void Update()
    {
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

        if (_selectedIndex <= -1)
            _selectedIndex = 2;

        if (_selectedIndex >= 3)
            _selectedIndex = 0;

        EventSystem.current.SetSelectedGameObject(MenuButtons[_selectedIndex].gameObject, new BaseEventData(EventSystem.current));
    }

    public void PlayGame()
    {
        StartCoroutine(fader.Fading("IntroScene"));
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
