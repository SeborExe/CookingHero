using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePausedUI : MonoBehaviour
{
    [SerializeField] private Button mainMenuButon;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button optionsButton;

    private void Start()
    {
        GameManager.Instance.OnGamePused += GameManager_OnGamePused;
        GameManager.Instance.OnGameUnpaused += GameManager_OnGameUnpaused;

        ChangeVisibility(false);
    }

    private void OnEnable()
    {
        mainMenuButon.onClick.AddListener(() => Loader.Load(Loader.Scene.MainMenu));
        resumeButton.onClick.AddListener(() => GameManager.Instance.PauseGame());
        optionsButton.onClick.AddListener(() =>
        {
            ChangeVisibility(false);
            OptionsUI.Instance.ChangeVisiblity(true, ChangeVisibility);
        });
    }

    private void OnDisable()
    {
        mainMenuButon.onClick.RemoveAllListeners();
        resumeButton.onClick.RemoveAllListeners();
        optionsButton.onClick.RemoveAllListeners();
    }

    private void GameManager_OnGameUnpaused(object sender, System.EventArgs e)
    {
        ChangeVisibility(false);
    }

    private void GameManager_OnGamePused(object sender, System.EventArgs e)
    {
        ChangeVisibility(true);
    }

    private void ChangeVisibility(bool show)
    {
        gameObject.SetActive(show);

        if (show == true)
        {
            resumeButton.Select();
        }
    }
}
