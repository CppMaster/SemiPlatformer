using UnityEngine;
using System.Collections;

public class Item : MapObject {

    public enum Type
    {
        HP,
        Speed,
        Power
    }

    public Type type;

    public void Pickup()
    {
        Destroy(gameObject);
    }
}
