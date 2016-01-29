using UnityEngine;

public class MapObject : MonoBehaviour {

    public Transform root;
    Platform underPlatform;
    public Platform UnderPlatform { get { return underPlatform; } }

    public Vector3 GetPosition()
    {
        return root == null ? transform.position : root.position;
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(new Ray(transform.position, Vector3.down), out hit, float.PositiveInfinity, 1 << LayerMask.NameToLayer("Ground")))
        {
            Platform platform = hit.collider.GetComponent<Platform>();
            if (platform != null) underPlatform = platform;
        }
    }

}
