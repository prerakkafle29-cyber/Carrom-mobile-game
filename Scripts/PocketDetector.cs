using UnityEngine;

public class PocketDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WhiteCoin"))
        {
            Debug.Log("White coin potted!");
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("BlackCoin"))
        {
            Debug.Log("Black coin potted!");
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Queen"))
        {
            Debug.Log("Queen potted!");
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Striker"))
        {
            Debug.Log("Foul! Striker potted.");
            // Logic to handle foul and reset striker position
        }
    }
}
