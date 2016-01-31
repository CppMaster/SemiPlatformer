using UnityEngine;
using System.Collections;

public class ActivateAfterTime : MonoBehaviour {

    public GameObject toActivate;
    public float time = 1;

    void Start () {
        StartCoroutine(Activate());	
    }
    
    IEnumerator Activate()
    {
        yield return new WaitForSeconds(time);
        toActivate.SetActive(toActivate);
    }
}
