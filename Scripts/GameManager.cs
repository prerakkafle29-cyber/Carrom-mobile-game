using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int player1Score = 0;
    public int player2Score = 0;
    public int currentPlayer = 1; // 1 for Player 1, 2 for Player 2

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
            Debug.Log("Player 2 scored! Total: " + player2Score);
        }
    }

    public void HandleFoul()
    {
        Debug.Log("Foul committed by Player " + currentPlayer);
        // Switch turns or subtract points on a foul
        SwitchTurn();
    }

    public void SwitchTurn()
    {
        currentPlayer = (currentPlayer == 1) ? 2 : 1;
        Debug.Log("Turn switched to Player " + currentPlayer);
    }
}
