using UnityEngine;

public class Platform : MonoBehaviour {

    public float height = 1f;
    public Rect rect;

    public bool autoSet = true;

	void Awake () {
        if (autoSet)
        {
            height = transform.localScale.y * 0.5f + transform.position.y;
            rect = new Rect(new Vector2(transform.position.x, transform.position.z), 
                new Vector2(transform.localScale.x, transform.localScale.z));
        }
	}

    public static float Distance(Platform a, Platform b)
    {
        float distance = float.PositiveInfinity;
        distance = Mathf.Min(distance, new Vector2(a.rect.max.x - b.rect.min.x, a.rect.max.y - b.rect.min.y).magnitude);
        distance = Mathf.Min(distance, new Vector2(a.rect.min.x - b.rect.max.x, a.rect.max.y - b.rect.min.y).magnitude);
        distance = Mathf.Min(distance, new Vector2(a.rect.min.x - b.rect.max.x, a.rect.min.y - b.rect.max.y).magnitude);
        distance = Mathf.Min(distance, new Vector2(a.rect.max.x - b.rect.min.x, a.rect.min.y - b.rect.max.y).magnitude);
        return distance;
    }
	
}
