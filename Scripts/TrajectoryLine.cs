using UnityEngine;

public class TrajectoryLine : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform strikerTransform;

    void Start()
    {
        if (lineRenderer != null)
        {
            lineRenderer.positionCount = 2;
            lineRenderer.enabled = false;
        }
    }

    // Call this while dragging the striker to show aiming direction
    public void RenderLine(Vector2 startPos, Vector2 endPos)
    {
        if (lineRenderer == null) return;

        lineRenderer.enabled = true;

        // Calculate reverse direction vector (shooting forward when pulled back)
        Vector2 shootDirection = startPos - endPos;
        Vector3 aimTarget = strikerTransform.position + (Vector3)shootDirection;

        lineRenderer.SetPosition(0, strikerTransform.position);
        lineRenderer.SetPosition(1, aimTarget);
    }

    // Hide the trajectory line when the shot is released
    public void HideLine()
    {
        if (lineRenderer != null)
        {
            lineRenderer.enabled = false;
        }
    }
}
