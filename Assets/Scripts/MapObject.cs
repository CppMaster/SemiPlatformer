using UnityEngine;

public class MapObject : MonoBehaviour {

    public Transform root;

    public Vector3 GetPosition()
    {
        return root == null ? transform.position : root.position;
    }

}
