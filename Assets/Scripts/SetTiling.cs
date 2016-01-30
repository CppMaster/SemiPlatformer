using UnityEngine;
using System.Collections;

public class SetTiling : MonoBehaviour {

	const float zScale = 0.4f;

	public enum Dimention
	{
		X,Y,Z
	}

	public Dimention xTiling = Dimention.X;
	public Dimention yTiling = Dimention.Y;

	void Start ()
	{
		Renderer renderer = GetComponent<Renderer>();
		renderer.material = new Material(renderer.material);

		Vector2 tiling = Vector2.one;
		switch(xTiling)
		{
			case Dimention.X:
				tiling.x = transform.lossyScale.x;
				break;
			case Dimention.Y:
				tiling.x = transform.lossyScale.y;
				break;
			case Dimention.Z:
				tiling.x = transform.lossyScale.z * zScale;
				break;
		}

		switch (yTiling)
		{
			case Dimention.X:
				tiling.y = transform.lossyScale.x;
				break;
			case Dimention.Y:
				tiling.y = transform.lossyScale.y;
				break;
			case Dimention.Z:
				tiling.y = transform.lossyScale.z * zScale;
				break;
		}

		renderer.material.mainTextureScale = tiling;
	}
	
}
