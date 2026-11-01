using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum GameMode { TwoPlayerLocal, VsAI }
    public GameMode currentMode = GameMode.VsAI;

    public int player1Score = 0;
    public int player2Score = 0;
    public int currentPlayer = 1; // 1 = Player 1, 2 = Player 2 (or AI)

    public BotAI botAI;

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

    public void AddScore(int points, string coinType)
    {
        if (currentPlayer == 1)
        {
            player1Score += points;
            Debug.Log("Player 1 scored! Total: " + player1Score);
        }
        else
        {
            player2Score += points;
            Debug.Log("Player 2 / AI scored! Total: " + player2Score);
        }

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayPocketScore();
        }
    }

    public void HandleFoul()
    {
        Debug.Log("Foul committed by Player " + currentPlayer);
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayFoul();
        }
        SwitchTurn();
    }

    public void SwitchTurn()
    {
        currentPlayer = (currentPlayer == 1) ? 2 : 1;
        Debug.Log("Turn switched to Player " + currentPlayer);

        // If it's Player 2's turn in AI mode, trigger Bot
        if (currentPlayer == 2 && currentMode == GameMode.VsAI && botAI != null)
        {
            botAI.MakeMove();
        }
    }
}
