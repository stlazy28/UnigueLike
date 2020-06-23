using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalInstance;

public class MapStore : MonoBehaviour
{

    [SerializeField]
    Sprite floorChip = null;
    public Sprite FloorChip { get { return floorChip; } }

    [SerializeField]
    Sprite wallChip = null;
    public Sprite WallChip { get { return wallChip; } }

    [SerializeField]
    Sprite enterChip = null;
    public Sprite EnterChip { get { return enterChip; } }

}