using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public int score;

    void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadData();
    }

    [System.Serializable]
    class SaveData {
        public int score;
    }

    public void SaveScore(int score) {
        SaveData data = new SaveData();
        data.score = score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/score.json", json);
    }

    public void LoadData() {
        string path = Application.persistentDataPath + "/score.json";

        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            score = data.score;
        }
    }
}
