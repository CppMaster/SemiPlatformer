using UnityEngine;

public class Paralax : MonoBehaviour {

	public Transform[] layers;
    public float[] moveRatio;
    Vector3[] normalPositions;
    public float lerpSpeed = 1f;

    public Transform player;

    void Start()
    {
        normalPositions = new Vector3[layers.Length];
        for(int a = 0; a < layers.Length; ++a)
        {
            normalPositions[a] = layers[a].position;
        }
    }

	void Update ()
    {
	    for(int a = 0; a < layers.Length; ++a)
        {
            layers[a].position = Vector3.Lerp(layers[a].position, normalPositions[a] + Vector3.right * player.position.x * moveRatio[a], lerpSpeed * Time.deltaTime);
        }
	}
}
