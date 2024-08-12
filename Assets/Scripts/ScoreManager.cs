using System;
using System.IO;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public string playerName;
    public string highScorePlayerName;
    public int highScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScoreData();
    }

    [Serializable]
    class HighScoreData
    {
        public string highScorePlayerName;
        public int highScore;
    }

    public void SaveHighScoreData()
    {
        HighScoreData highScoreData = new()
        {
            highScorePlayerName = highScorePlayerName,
            highScore = highScore
        };
        string jsonData = JsonUtility.ToJson(highScoreData);
        File.WriteAllText(Application.persistentDataPath + "/scores.json", jsonData);
    }

    public void LoadHighScoreData()
    {
        string path = Application.persistentDataPath + "/scores.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScoreData highScoreData = JsonUtility.FromJson<HighScoreData>(json);
            highScorePlayerName = highScoreData.highScorePlayerName;
            highScore = highScoreData.highScore;
        }
        if (highScorePlayerName != null && !highScorePlayerName.Equals("") && bestScoreText != null)
        {
            bestScoreText.text = "Best Score: " + highScorePlayerName + " - " + highScore;
        }
    }

    public static ScoreManager Instance { get; private set; }
}
