using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private GameState State;
    public LevelManager LevelManager;

    void Start()
    {
        State = GameState.Instance;
        LevelManager = LevelManager.Instance;

        Debug.Log(string.Format("Generate World {0} Level {1}", State.World, State.Level));

        Level level;
        if(LevelManager.TryGetLevel(out level))
        {
            Debug.Log(string.Format("Name: {0}, Description: {1}, Medals #: {2}, Blocks #: {3}", level.Name, level.Description, level.Medals.Length, level.Blocks.Length));
        }
    }
}
