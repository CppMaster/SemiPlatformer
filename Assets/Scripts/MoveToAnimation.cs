using UnityEngine;

public class MoveToAnimation : MonoBehaviour {

    public Vector3 startPos;
    public Vector3 endPos;

    public float speed = 1f;
    float progress = 0f;

    void Start()
    {
        transform.localPosition = startPos;
    }
	
	void Update ()
    {
        progress += Time.deltaTime * speed;
        transform.localPosition = Vector3.Lerp(startPos, endPos, progress);

    }
}
