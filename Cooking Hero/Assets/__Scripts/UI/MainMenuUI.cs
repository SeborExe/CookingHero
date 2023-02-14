using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        Time.timeScale= 1.0f;
    }

    private void OnEnable()
    {
        playButton.onClick.AddListener(() => Loader.Load(Loader.Scene.GameScene));
        quitButton.onClick.AddListener(() => Application.Quit());
    }
}
