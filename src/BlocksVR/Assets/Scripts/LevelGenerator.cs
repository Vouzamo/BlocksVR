using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LevelGenerator : MonoBehaviour
{
    private GameState State;
    private LevelManager LevelManager;

    public GameObject LevelInformation;

    public GameObject PlatformBlock;
    public GameObject IronBlock;
    public GameObject FeatherBlock;
    public GameObject BombBlock;
    public GameObject IceBlock;

    void Start()
    {
        State = GameState.Instance;
        LevelManager = LevelManager.Instance;

        Debug.Log(string.Format("Generate World {0} Level {1}", State.World, State.Level));

        Level level;
        if(LevelManager.TryGetLevel(out level))
        {
            Debug.Log(string.Format("Name: {0}, Description: {1}, Medals #: {2}, Blocks #: {3}", level.Name, level.Description, level.Medals.Length, level.Blocks.Length));

            // Freeze time (and physics)
            Time.timeScale = 0;

            // Information
            var information = (GameObject)Instantiate(LevelInformation);
            foreach(var text in information.GetComponents<Text>())
            {
                if(text.name == "Title")
                {
                    text.text = level.Name;
                }
                if(text.name == "Information")
                {
                    text.text = level.Description;
                }
            }

            // Blocks
            foreach(var data in level.Blocks.OrderBy(x => x.Type).ThenBy(x => x.Position.y))
            {
                GameObject block;

                switch(data.Type)
                {
                    case BlockType.Iron:
                        block = (GameObject)Instantiate(IronBlock, transform);
                        break;
                    case BlockType.Feather:
                        block = (GameObject)Instantiate(FeatherBlock, transform);
                        break;
                    case BlockType.Bomb:
                        block = (GameObject)Instantiate(BombBlock, transform);
                        break;
                    case BlockType.Ice:
                        block = (GameObject)Instantiate(IceBlock, transform);
                        break;
                    case BlockType.Platform:
                    default:
                        block = (GameObject)Instantiate(PlatformBlock, transform);
                        break;
                }

                block.transform.localPosition = data.Position;
                block.transform.localScale = data.Scale;
                
                if(data.Score > 0)
                {
                    var score = block.AddComponent<BlockScore>();
                    score.Score = data.Score;
                }
            }

            // Resume time (and physics)
            //Time.timeScale = 1;
        }
    }
}
