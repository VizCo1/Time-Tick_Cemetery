using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{

    public enum Scene
    {
        MainMenuScene,
        LevelSelectorScene,
        Level_1,
        Level_2,
        LoadingScene,
        SettingsScene,
    }

    private static Scene _targetScene;

    public static void SetTargetScene(Scene targetScene)
    {
        _targetScene = targetScene;
    }
    public static void Load(Scene targetScene)
    {
        _targetScene = targetScene;

        SceneManager.LoadScene(Scene.LoadingScene.ToString());

    }

    public static void LoaderCallback()
    {
        SceneManager.LoadScene(_targetScene.ToString());
    }
}
