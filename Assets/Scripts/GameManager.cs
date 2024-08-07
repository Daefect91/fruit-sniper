using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public GameObject gameOverPanel;
    public bool gameOver = false;
    public int score;
    private NavigationManager navigationManager;

    void Start()
    {
        navigationManager = GameObject.Find("NavigationManager").GetComponent<NavigationManager>();
        if (ScoreManager.Instance != null && bestScoreText != null
            && ScoreManager.Instance.highScorePlayerName != null && !ScoreManager.Instance.highScorePlayerName.Equals(""))
        {
            bestScoreText.text = "Best Score: " + ScoreManager.Instance.highScorePlayerName + " - " + ScoreManager.Instance.highScore;
        }
    }

    public void StartGame()
    {
        ScoreManager.Instance.playerName = playerNameInput.text;
        navigationManager.LoadMain();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        Cursor.visible = true;
        if (ScoreManager.Instance.highScore < score)
        {
            highscoreText.gameObject.SetActive(true);
            ScoreManager.Instance.highScorePlayerName = ScoreManager.Instance.playerName;
            ScoreManager.Instance.highScore = score;
            ScoreManager.Instance.SaveHighScoreData();
        }
    }
}
