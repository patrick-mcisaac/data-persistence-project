using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;

    void Awake()
    {
        highScoreText.text = $"{SystemManager.Instance.highScorePlayer} : {SystemManager.Instance.highScore.ToString()}";
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
