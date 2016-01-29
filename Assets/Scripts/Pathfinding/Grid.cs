using UnityEngine;
using System.Collections.Generic;
using System;

public class PlatformComparator : Comparer<Platform>
{

    public Platform relative;

    public PlatformComparator(Platform r)
    {
        relative = r;
    }

    public override int Compare(Platform x, Platform y)
    {
        return Mathf.RoundToInt(Mathf.Sign(Platform.Distance(x, relative) - Platform.Distance(y, relative)));
    }
}

public class Grid : MonoBehaviour {

    public static Grid instance;
    Platform[] platforms;
    float[,] routes;
    public float maxHeightDiff = 3f;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        platforms = GameObject.FindObjectsOfType<Platform>();

        routes = new float[platforms.Length, platforms.Length];

        for(int a = 0; a < platforms.Length; ++a)
        {
            for(int b = 0; b < platforms.Length; ++b)
            {
                if(platforms[b].height - platforms[a].height > maxHeightDiff)
                {
                    routes[a, b] = float.PositiveInfinity;
                }
                else
                {
                    routes[a, b] = Platform.Distance(platforms[a], platforms[b]);
                }
                Debug.Log("Distance(" + a + "," + b + "): " + routes[a, b]);
            }
        }
    }

    
}
