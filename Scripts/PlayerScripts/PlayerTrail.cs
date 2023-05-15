using UnityEngine;

public class PlayerTrail : MonoBehaviour 
{
    public TrailRenderer trailRenderer;
    public float trailPositionY = 1.0f;
    public float trailWidth = 2.0f;
    public bool isFlat = true;

    void Start () {
        // Прикріплення TrailRenderer до гравця
        trailRenderer.transform.parent = transform;
        // Встановлення позиції та ширини TrailRenderer
        SetTrailPositionAndWidth();
    }

    void LateUpdate () {
        // Оновлення позиції та ширини TrailRenderer зі змінним trailPositionY та trailWidth
        SetTrailPositionAndWidth();
    }

    void SetTrailPositionAndWidth() 
    {
        if (trailRenderer == null) 
        {
            return;
        }
        // Встановлення позиції TrailRenderer
        Vector3 trailPosition = transform.position;
        trailPosition.y = trailPositionY;
        trailRenderer.transform.position = trailPosition;

        // Встановлення ширини та плоскості TrailRenderer
        trailRenderer.widthMultiplier = trailWidth;
        if (isFlat)
        {
            trailRenderer.alignment = LineAlignment.View;
        }
        else
        {
            trailRenderer.alignment = LineAlignment.TransformZ;
        }

        // Встановлення плавної появи лінії
        trailRenderer.time = Mathf.Clamp(trailRenderer.time + Time.deltaTime, 0f, 2f);
    }
}
