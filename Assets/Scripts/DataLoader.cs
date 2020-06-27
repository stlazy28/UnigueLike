using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static SaveData loadSaveData()
    {
        string savePath = Application.dataPath + "/Save/savedata.json";
        StreamReader reader = new StreamReader(savePath);
        string datastr = reader.ReadToEnd();
        reader.Close();

        return JsonUtility.FromJson<SaveData>(datastr);
    }
}
