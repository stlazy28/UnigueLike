using System.IO;
using System.Net;
using UnityEngine;
using static GlobalInstance;

[System.Serializable]
public class SaveData
{
    public Vector2Int pos;
    public Direction dir;
}

public class DataSaver : MonoBehaviour
{
    SaveData saveData = new SaveData();

    // Start is called before the first frame update
    void Start()
    {
        saveData.pos = new Vector2Int(3, 3);
        saveData.dir = Direction.Up;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            string jsonStr = JsonUtility.ToJson(saveData);

            string savePath = Application.dataPath + "/Save/savedata.json";
            StreamWriter writer = new StreamWriter(savePath);
            writer.Write(jsonStr);
            writer.Flush();
            writer.Close();

            Debug.Log("Saved game to " + savePath);
            Debug.Log("Contents: " + jsonStr);
        }
    }
}
