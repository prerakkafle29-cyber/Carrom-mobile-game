using UnityEngine;

public class StrikerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 startPos;
    private Vector2 endPos;
    private bool isDragging = false;

    [Header("Shooting Controls")]
    public float maxForce = 15f;
    public float forceMultiplier = 5f;
    public Transform baselineStart;
    public Transform baselineEnd;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Slider control to position striker along baseline
    public void SetStrikerPosition(float sliderValue)
    {
        if (rb.velocity.magnitude < 0.05f)
        {
            float xPos = Mathf.Lerp(baselineStart.position.x, baselineEnd.position.x, sliderValue);
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        }
    }

    void OnMouseDown()
    {
        if (rb.velocity.magnitude < 0.05f)
        {
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;
        }
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void OnMouseUp()
    {
        if (isDragging)
        {
            isDragging = false;
            Vector2 direction = startPos - endPos; // Drag back to pull and shoot forward
            float distance = Vector2.Distance(startPos, endPos);

            float force = Mathf.Clamp(distance * forceMultiplier, 0, maxForce);
            rb.AddForce(direction.normalized * force, ForceMode2D.Impulse);
        }
    }
}
