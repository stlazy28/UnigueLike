using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject _chipEntityPrefab = null;

    MapStore[] _mapStores = new MapStore[0];

    [SerializeField]
    Vector2Int _size = new Vector2Int(5, 5);

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        if(_chipEntityPrefab == null)
        {
            Debug.LogError("ChipEntityPrefab is not set to StageGenerator", gameObject);
        }

        _mapStores = GetComponentsInChildren<MapStore>();
        if(_mapStores.Length == 0)
        {
            Debug.LogError("MapStore does not exist as a child", gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// MapStoreからチップデータを読み込みステージを生成する
    /// </summary>
    /// <param name="index">使うMapStoreのインデクス</param>
    /// <param name="_stageData">生成したステージを出力</param>
    public void generateStage(ref ChipEntity[,] _stageData, int index = 0)
    {
        Array.Clear(_stageData, 0, _stageData.Length);
        _stageData = new ChipEntity[_size.y, _size.x];

        Sprite floorSprite = _mapStores[index].FloorChip;
        Sprite wallSprite = _mapStores[index].WallChip;

        for (int y = _size.y - 1; y >= 0; y--)
        {
            for (int x = _size.x - 1; x >= 0; x--)
            {
                GameObject chip = Instantiate(_chipEntityPrefab, new Vector2(x, y), Quaternion.identity);
                ChipEntity chipEntity;

                if (x == 0 || x == _size.x - 1)
                {   // 左右端の縦ラインの壁
                    chipEntity = chip.AddComponent<WallChip>();
                    chipEntity.Initialize(wallSprite);

                }
                else if (y == 0 || y == _size.y-1)
                {
                    // 上下端の横ラインの壁
                    chipEntity = chip.AddComponent<WallChip>();
                    chipEntity.Initialize(wallSprite);
                }
                else
                {
                    
                    chipEntity = chip.AddComponent<FloorChip>();
                    chipEntity.Initialize(floorSprite);
                }

                // マップチップの親をStageManagerにする
                chip.transform.parent = transform.parent;

                _stageData[y, x] = chipEntity;
            }
        }
    }


}
