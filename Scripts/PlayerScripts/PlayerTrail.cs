using UnityEngine;

public class PlayerTrail : MonoBehaviour 
{
    public TrailRenderer trailRenderer;
    public float trailPositionY = 1.0f;
    public float trailWidth = 2.0f;
    public bool isFlat = true;

    void Start () {
        trailRenderer.transform.parent = transform;
        SetTrailPositionAndWidth();
    }

    void LateUpdate () {
        SetTrailPositionAndWidth();
    }

    void SetTrailPositionAndWidth() 
    {
        if (trailRenderer == null) 
        {
            return;
        }
        Vector3 trailPosition = transform.position;
        trailPosition.y = trailPositionY;
        trailRenderer.transform.position = trailPosition;

        SetTrailWidth();
        trailRenderer.time = Mathf.Clamp(trailRenderer.time + Time.deltaTime, 0f, 2f);
    }

    private void SetTrailWidth()
    {
        trailRenderer.widthMultiplier = trailWidth;
        if (isFlat)
        {
            trailRenderer.alignment = LineAlignment.View;
        }
        else
        {
            trailRenderer.alignment = LineAlignment.TransformZ;
        }
    }
}
