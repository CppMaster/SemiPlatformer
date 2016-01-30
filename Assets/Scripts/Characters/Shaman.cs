using UnityEngine;
using System.Collections;

public class Shaman : Destroyable {

    public static Shaman instance;

    void Awake()
    {
        instance = this;
    }

}
