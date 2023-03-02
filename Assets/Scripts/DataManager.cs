using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public int score;
    public int coins;

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
        public int coins;
    }

    public void SaveGameData() {
        SaveData data = new SaveData();
        data.score = score;
        data.coins = coins;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/score.json", json);
    }

    public void LoadData() {
        string path = Application.persistentDataPath + "/score.json";

        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            score = data.score;
            coins = data.coins;
        }
    }

    public void SetScore(int score) {
        this.score = score;
    }

    public void AddCoins(int coins) {
        this.coins += coins;
    }
}
