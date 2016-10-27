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

    private LevelData Data;

    void Start()
    {
        State = GameState.Instance;

        Data = LoadLevelData();
    }

    LevelData LoadLevelData()
    {
        var json = Resources.Load<TextAsset>(Path.Combine("Data", "levelData"));

        return JsonUtility.FromJson<LevelData>(json.text);
    }

    public bool TryGetWorld(out World world)
    {
        world = null;

        if(Data != null && Data.Worlds != null)
        {
            world = Data.Worlds.FirstOrDefault(x => x.Id == State.World);
        }
        
        return world != null;
    }

    public bool TryGetLevel(out Level level)
    {
        level = null;

        World world;
        if(TryGetWorld(out world))
        {
            if(world.Levels != null)
            {
                level = world.Levels.FirstOrDefault(x => x.Id == State.Level);
            }
        }

        return level != null;
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
