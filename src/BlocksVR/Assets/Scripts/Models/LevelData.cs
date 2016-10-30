using System;
using UnityEngine;

[Serializable]
public class LevelData
{
    public World[] Worlds;
}

[Serializable]
public class World
{
    public int Id;
    public string Name;
    public string Description;
    public Level[] Levels;
}

[Serializable]
public class Level
{
    public int Id;
    public string Name;
    public string Description;
    public int Ammo;
    public Medal[] Medals;
    public Block[] Blocks;
}

public enum MedalType
{
    None,
    Bronze,
    Silver,
    Gold
}

[Serializable]
public class Medal
{
    public MedalType Type;
    public int Score;
}

public enum BlockType
{
    Platform,
    Score1,
    Score2,
    Score3,
    Score4,
    Score5,
    Score6,
    Score7,
    Score8,
    Score9,
    Grow,
    Shrink,
    Explode,
    Block
}

[Serializable]
public class Block
{
    public BlockType Type;
    public Vector3 Position;
    public Vector3 Scale;
    public int Score;
}
