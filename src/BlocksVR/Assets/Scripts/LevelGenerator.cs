using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private GameState State;

    void Start()
    {
        State = GameState.Instance;

        Debug.Log(string.Format("Generate World {0} Level {1}", State.World, State.Level));
    }
}
