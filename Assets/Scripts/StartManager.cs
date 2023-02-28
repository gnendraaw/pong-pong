using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public int score { get; private set; }
    public bool isGameActive = false;

    [System.Serializable]
    class SaveData
    {
        public int score;
    }

    public static StartManager Instance;

    void Awake()
    {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    void Update()
    {
        if (Input.touchCount > 0 && !isGameActive) {
            isGameActive = true;
            SceneManager.LoadScene(1);
        }
    }

    public void SaveScore(int score)
    {
        SaveData saveData = new SaveData();
        saveData.score = score;

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.persistentDataPath + "/score.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/score.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            score = data.score;
        }
    }
}
