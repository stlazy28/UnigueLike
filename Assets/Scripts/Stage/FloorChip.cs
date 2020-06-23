using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalInstance;

public class FloorChip : ChipEntity
{

    public override void Initialize(Sprite sprite)
    {
        base.Initialize(sprite);

        ChipTag = GlobalInstance.GetInstance.chipTagName[ChipTagList.Floor];
    }
}
