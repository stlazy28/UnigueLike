using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalInstance ;

public abstract class CharacterManager : MonoBehaviour
{
    StageManager _stageManager = null;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        GameObject stageManagerObj = GameObject.Find("StageManager");
        if(stageManagerObj == null)
        {
            Debug.LogError("Cannot find object 'StageManager'", gameObject);
        }
        _stageManager = stageManagerObj.GetComponent<StageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 移動先に移動可能かどうかを確認
    /// </summary>
    /// <param name="nextPos">移動先</param>
    /// <returns>移動可能であればtrue</returns>
    public virtual bool CanMove(Vector2Int nextPos)
    {
        GlobalInstance GI = GlobalInstance.GetInstance;
        string chipTag = _stageManager.GetChipTag(nextPos);

        if (chipTag.Equals(GI.chipTagName[ChipTagList.Wall]))
        {
            return false;
        }

        return true;
    }
}
