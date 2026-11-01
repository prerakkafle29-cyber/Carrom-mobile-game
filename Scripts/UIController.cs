using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    [Header("UI Text Displays")]
    public Text player1ScoreText;
    public Text player2ScoreText;
    public Text turnIndicatorText;
    public Text winMessageText;

    [Header("UI Panels")]
    public GameObject gameOverPanel;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        UpdateScoreUI(0, 0);
        UpdateTurnUI(1);
    }

    // Update player score numbers on screen
    public void UpdateScoreUI(int p1Score, int p2Score)
    {
        if (player1ScoreText != null)
            player1ScoreText.text = "Player 1: " + p1Score;

        if (player2ScoreText != null)
            player2ScoreText.text = "Player 2: " + p2Score;
    }

    // Update turn text display
    public void UpdateTurnUI(int currentPlayer)
    {
        if (turnIndicatorText != null)
        {
            if (GameManager.Instance != null && GameManager.Instance.currentMode == GameManager.GameMode.VsAI)
            {
                turnIndicatorText.text = (currentPlayer == 1) ? "Your Turn" : "Bot Thinking...";
            }
            else
            {
                turnIndicatorText.text = "Player " + currentPlayer + "'s Turn";
            }
        }
    }

    // Display Game Over panel and winner text
    public void ShowGameOver(string winnerName)
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        if (winMessageText != null)
        {
            winMessageText.text = winnerName + " Wins!";
        }
    }
}
