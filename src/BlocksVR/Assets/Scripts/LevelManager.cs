using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public static LevelManager Instance = null;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private GameState State;

    public string WorldSelectScene;
    public string LevelSelectScene;
    public string LevelScene;

    private Level _data;
    public Level Data {
        get {
            if (_data == null)
            {
                _data = LoadLevel(State.World, State.Level);
            }

            return _data;
        }
    }

    void Start()
    {
        State = GameState.Instance;
    }

    Level LoadLevel(int world, int level)
    {
        var levelPath = string.Format("{0}\\{1}", world, level);

        var json = Resources.Load<TextAsset>(Path.Combine("Data", levelPath));

        return JsonUtility.FromJson<Level>(json.text);
    }

    public void WorldSelect()
    {
        State.Level = 0;

        var operation = SceneManager.LoadSceneAsync(WorldSelectScene);
        operation.allowSceneActivation = true;
    }

    public void LevelSelect(int world)
    {
        State.World = world;

        var operation = SceneManager.LoadSceneAsync(LevelSelectScene);
        operation.allowSceneActivation = true;
    }

    public void Level(int level) {
        State.Level = level;

        var operation = SceneManager.LoadSceneAsync(LevelScene);
        operation.allowSceneActivation = true;
    }

    public void Home()
    {
        var operation = SceneManager.LoadSceneAsync("Test");
        operation.allowSceneActivation = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
