using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance = null;

    public int World;
    public int Level;
    public int Score;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
