using UnityEngine;
using System.Collections;

public class BotAI : MonoBehaviour
{
    public StrikerController striker;
    public float minForce = 5f;
    public float maxForce = 12f;

    public void MakeMove()
    {
        StartCoroutine(TakeShotRoutine());
    }

    private IEnumerator TakeShotRoutine()
    {
        // Wait briefly so the turn transition feels natural
        yield return new WaitForSeconds(1.5f);

        // Find all remaining coins on the board
        GameObject[] coins = GameObject.FindGameObjectsWithTag("WhiteCoin");
        if (coins.Length == 0)
        {
            coins = GameObject.FindGameObjectsWithTag("BlackCoin");
        }

        if (coins.Length > 0)
        {
            // Target the first available coin
            Transform targetCoin = coins[Random.Range(0, coins.Length)].transform;

            // Calculate direction toward the coin
            Vector2 aimDirection = (targetCoin.position - striker.transform.position).normalized;
            float shotForce = Random.Range(minForce, maxForce);

            // Apply force to the striker
            Rigidbody2D strikerRb = striker.GetComponent<Rigidbody2D>();
            if (strikerRb != null)
            {
                strikerRb.AddForce(aimDirection * shotForce, ForceMode2D.Impulse);
                Debug.Log("AI Bot took a shot!");
            }
        }
    }
}
