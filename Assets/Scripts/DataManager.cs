using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string PlayerName;
    public string HighScoreName;
    public int HighScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string HighScoreName;
        public int HighScore;
    }

    public void SaveScore()
    {
        if (HighScoreName != null)
        { 
            SaveData data = new SaveData();

            data.HighScoreName = HighScoreName;
            data.HighScore = HighScore;

            string jsonToSave = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savedata.json", jsonToSave);
        }

    }

    public void LoadScore()
    {
        if (File.Exists(Application.persistentDataPath + "/savedata.json"))
        {
            string jsonToLoad = File.ReadAllText(Application.persistentDataPath + "/savedata.json");

            SaveData data = JsonUtility.FromJson<SaveData>(jsonToLoad);

            HighScoreName = data.HighScoreName;
            HighScore = data.HighScore;
        }
        else
        {
            HighScoreName = null;
            HighScore = 0;
        }
    }
}
