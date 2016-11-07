using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LevelGenerator : MonoBehaviour
{
    private GameState State;
    private LevelManager LevelManager;

    public GameObject LevelInformation;

    public GameObject PlatformBlock;
    public GameObject ScoreBlock1;
    public GameObject ScoreBlock2;
    public GameObject ScoreBlock3;
    public GameObject ScoreBlock4;
    public GameObject ScoreBlock5;
    public GameObject ScoreBlock6;
    public GameObject ScoreBlock7;
    public GameObject ScoreBlock8;
    public GameObject ScoreBlock9;
    public GameObject GrowBlock;
    public GameObject ShrinkBlock;
    public GameObject ExplodeBlock;
    public GameObject IceBlock;
    public GameObject RubberBlock;
    public GameObject Block;

    void Start()
    {
        State = GameState.Instance;
        LevelManager = LevelManager.Instance;

        Debug.Log(string.Format("Generate World {0} Level {1}", State.World, State.Level));

        Level level = LevelManager.Data;
        if(level != null)
        {
            Debug.Log(string.Format("Name: {0}, Description: {1}, Medals #: {2}, Blocks #: {3}", level.Name, level.Description, level.Medals.Length, level.Blocks.Length));

            // Freeze time (and physics)
            Time.timeScale = 0;

            // Information
            var information = Instantiate(LevelInformation);
            foreach(var text in information.GetComponentsInChildren<Text>())
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
                    case BlockType.Platform:
                        block = (GameObject)Instantiate(PlatformBlock, transform);
                        break;
                    case BlockType.Score1:
                        block = (GameObject)Instantiate(ScoreBlock1, transform);
                        break;
                    case BlockType.Score2:
                        block = (GameObject)Instantiate(ScoreBlock2, transform);
                        break;
                    case BlockType.Score3:
                        block = (GameObject)Instantiate(ScoreBlock3, transform);
                        break;
                    case BlockType.Score4:
                        block = (GameObject)Instantiate(ScoreBlock4, transform);
                        break;
                    case BlockType.Score5:
                        block = (GameObject)Instantiate(ScoreBlock5, transform);
                        break;
                    case BlockType.Score6:
                        block = (GameObject)Instantiate(ScoreBlock6, transform);
                        break;
                    case BlockType.Score7:
                        block = (GameObject)Instantiate(ScoreBlock7, transform);
                        break;
                    case BlockType.Score8:
                        block = (GameObject)Instantiate(ScoreBlock8, transform);
                        break;
                    case BlockType.Score9:
                        block = (GameObject)Instantiate(ScoreBlock9, transform);
                        break;
                    case BlockType.Grow:
                        block = (GameObject)Instantiate(GrowBlock, transform);
                        break;
                    case BlockType.Shrink:
                        block = (GameObject)Instantiate(ShrinkBlock, transform);
                        break;
                    case BlockType.Explode:
                        block = (GameObject)Instantiate(ExplodeBlock, transform);
                        break;
                    case BlockType.Ice:
                        block = (GameObject)Instantiate(IceBlock, transform);
                        break;
                    case BlockType.Rubber:
                        block = (GameObject)Instantiate(RubberBlock, transform);
                        break;
                    default:
                        block = (GameObject)Instantiate(Block, transform);
                        break;
                }

                block.transform.localPosition = data.Position;
                if(data.Scale != Vector3.zero)
                {
                    block.transform.localScale = data.Scale;
                }
                else
                {
                    block.transform.localScale = new Vector3(1, 1, 1);
                }
            }

            // Resume time (and physics)
            Time.timeScale = 1;
        }
    }
}
