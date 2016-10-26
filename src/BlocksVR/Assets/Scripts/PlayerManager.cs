using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private GameState State;

    void Start()
    {
        State = GameState.Instance;
    }

    public void AwardPoints(int points)
    {
        State.Score += points;
    }

    public void ResetScore()
    {
        State.Score = 0;
    }
}
