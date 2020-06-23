using UnityEngine;
using System;
using System.Collections.Generic;

public class GlobalInstance : SingletonMonobehaviour<GlobalInstance>
{
    public enum Direction
    {
        Up,
        Right,
        Down,
        Left
    }

    public Dictionary<Direction, Vector2> dirToVec { private set; get; } =
        new Dictionary<Direction, Vector2>()
        {
            { Direction.Up, new Vector2(0, 1)    },
            { Direction.Right, new Vector2(1, 0) },
            { Direction.Down, new Vector2(0, -1) },
            { Direction.Left, new Vector2(-1, 0) }
        };

    public enum ChipTagList
    {
        Floor,
        Wall,
        Enter
    }

    public Dictionary<ChipTagList, string> chipTagName { private set; get; } =
        new Dictionary<ChipTagList, string>()
        {
            { ChipTagList.Floor, "Floor"    },
            { ChipTagList.Wall, "Wall"      },
            { ChipTagList.Enter, "Enter"    }
        };
}