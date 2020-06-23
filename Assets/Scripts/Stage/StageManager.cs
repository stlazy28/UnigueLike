using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    StageGenerator _stageGenerator = null;

    ChipEntity[,] _stageData = { };

    // Start is called before the first frame update
    void Start()
    {
        _stageGenerator = GetComponentInChildren<StageGenerator>();

        if(_stageGenerator == null)
        {
            Debug.LogError("StageGenerator does not exist as a child", gameObject);
        }

        _stageGenerator.generateStage(ref _stageData);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetChipTag(Vector2Int pos)
    {
        ChipEntity chip = _stageData[pos.y, pos.x];

        return chip.ChipTag;
    }


}
