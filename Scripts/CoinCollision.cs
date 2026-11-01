using UnityEngine;

public class CoinCollision : MonoBehaviour
{
    public float minCollisionVelocity = 0.5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the impact speed is strong enough to trigger a sound
        if (collision.relativeVelocity.magnitude > minCollisionVelocity)
        {
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlayCoinHit();
            }
        }
    }
}
