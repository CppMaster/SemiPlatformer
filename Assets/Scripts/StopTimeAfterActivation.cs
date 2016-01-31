using UnityEngine;
using System.Collections;

public class StopTimeAfterActivation : MonoBehaviour {

    public float time = 1f;

    void Start () {
        StartCoroutine(StopTime());
    }

    IEnumerator StopTime()
    {
        yield return new WaitForSeconds(time);
        Time.timeScale = 0f;
    }
    
}
