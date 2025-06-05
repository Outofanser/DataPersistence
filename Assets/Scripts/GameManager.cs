using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string PlayerName;
    public string TopName;
    public int TopScore;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }

        LoadTopScore();

    }

    [Serializable]
    class TopScoreData
    {
        public string Name;
        public int Score;
    }

    public void SaveTopScore()
    {
        TopScoreData data = new();
        data.Name = TopName;
        data.Score = TopScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/topscore.json", json);
    }
    public void LoadTopScore()
    {
        string path = Application.persistentDataPath + "/topscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            TopScoreData data = JsonUtility.FromJson<TopScoreData>(json);

            TopName = data.Name;
            TopScore = data.Score;
        }

    }

}
