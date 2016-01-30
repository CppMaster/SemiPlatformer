using UnityEngine;

public class ScalePulse : MonoBehaviour {

	Vector3 normalScale;
	public float amplitude = 0.5f;
	public float frequency = 1f;

	void Start () {
		normalScale = transform.localScale;	
	}

	void Update () {
		transform.localScale = normalScale * (1 + Mathf.Sin(Time.time * frequency) * amplitude);
	}
}
