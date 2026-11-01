using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [Header("Coin Prefabs")]
    public GameObject whiteCoinPrefab;
    public GameObject blackCoinPrefab;
    public GameObject queenPrefab;

    [Header("Board Center")]
    public Vector2 centerPosition = Vector2.zero;
    public float spacing = 0.5f;

    void Start()
    {
        SpawnCarromBoardLayout();
    }

    void SpawnCarromBoardLayout()
    {
        // 1. Spawn the Queen right in the center
        if (queenPrefab != null)
        {
            Instantiate(queenPrefab, centerPosition, Quaternion.identity);
            Debug.Log("Queen spawned in the center.");
        }

        // 2. Spawn surrounding inner ring of coins (alternating white and black)
        int innerRingCount = 6;
        float innerRadius = 0.6f;
        for (int i = 0; i < innerRingCount; i++)
        {
            float angle = i * Mathf.PI * 2 / innerRingCount;
            Vector2 spawnPos = centerPosition + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * innerRadius;

            GameObject coinToSpawn = (i % 2 == 0) ? whiteCoinPrefab : blackCoinPrefab;
            Instantiate(coinToSpawn, spawnPos, Quaternion.identity);
        }

        // 3. Spawn outer ring of coins
        int outerRingCount = 12;
        float outerRadius = 1.2f;
        for (int i = 0; i < outerRingCount; i++)
        {
            float angle = i * Mathf.PI * 2 / outerRingCount;
            Vector2 spawnPos = centerPosition + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * outerRadius;

            GameObject coinToSpawn = (i % 2 == 0) ? blackCoinPrefab : whiteCoinPrefab;
            Instantiate(coinToSpawn, spawnPos, Quaternion.identity);
        }

        Debug.Log("All Carrom coins successfully spawned in layout.");
    }
}
