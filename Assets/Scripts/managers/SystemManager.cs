using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;
using System.IO;



public class SystemManager : MonoBehaviour
{
    public TextMeshProUGUI playerNameInput;
    public string playerName;
    public static SystemManager Instance;
    public int highScore = 0;
    public string highScorePlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }

    // Update is called once per frame
    class SaveData
    {
        public int points;
        public string player;
    }

    public void StartGame()
    {
        playerName = $"{playerNameInput.text}";
        SceneManager.LoadScene(1);
    }

    public void SaveHighScore()
    {
        MainManager mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
        SaveData data = new SaveData();

        data.points = mainManager.getPoints();
        data.player = playerName;

        if (data.points > highScore)
        {
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
            highScore = data.points;
            highScorePlayer = data.player;
        }
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.points;
            highScorePlayer = data.player;
        }
    }
}
