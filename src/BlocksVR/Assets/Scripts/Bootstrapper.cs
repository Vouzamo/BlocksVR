using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    public GameObject Manager;

    void Awake()
    {
        if(GameState.Instance == null)
        {
            Instantiate(Manager);
        }
    }
}
