using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    private static Scene targetScene;

    public enum Scene
    {
        MainMenu,
        GameScene,
        LoadingScreen
    }

    public static void Load(Scene targetScene)
    {
        Loader.targetScene = targetScene;

        SceneManager.LoadScene(Scene.LoadingScreen.ToString());
    }

    public static void LoaderCallback()
    {
        SceneManager.LoadScene(targetScene.ToString());
    }
}
