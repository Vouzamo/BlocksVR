using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    private GameState State;

    public string WorldSelectScene;
    public string LevelSelectScene;
    public string LevelScene;

    void Start()
    {
        State = GameState.Instance;
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
