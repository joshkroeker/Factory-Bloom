using System;
using UnityEngine;

public class ArcSpawn : MonoBehaviour
{
    [Header("Arc Settings")]
    public float direction;
    public Vector3 origin;
    public float bezierPoint1 = 0.5f;
    public float bezierPoint2 = 1f;
    public float bezierHeight;
    
    float count = 0.0f;

    Vector2[] points;

    public Action OnFinishArc = delegate { };

    void Start()
    {
        points = new Vector2[3]
        {
            new Vector2(origin.x, origin.y),
            new Vector2(origin.x + bezierPoint1 * direction, bezierHeight),
            new Vector2(origin.x + bezierPoint2 * direction, origin.y)
        };
        
    }

    void OnDestroy()
    {
        foreach (var subscribers in OnFinishArc.GetInvocationList())
        {
            OnFinishArc -= subscribers as Action;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (count < 1f)
        {
            count += 1 * Time.deltaTime;
        }
        else
        {
            OnFinishArc?.Invoke();
            Destroy(this);
        }

        var m1 = Vector2.Lerp(points[0], points[1], count);
        var m2 = Vector2.Lerp(points[1], points[2], count);
        transform.position = Vector2.Lerp(m1, m2, count);
    }
}
