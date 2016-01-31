using UnityEngine;

public class ScaleFromZero : MonoBehaviour {

    public float speed = 1f;
    Vector3 targetScale;
    float progress = 0f;

    void Start () {
        targetScale = transform.localScale;
        transform.localScale = Vector3.zero;
    }
    
    void Update () {
        progress += Time.deltaTime * speed;
        transform.localScale = Vector3.Lerp(Vector3.zero, targetScale, progress);
    }
}
