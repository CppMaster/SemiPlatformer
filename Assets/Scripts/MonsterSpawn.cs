using UnityEngine;

public class MonsterSpawn : MonoBehaviour {

    public GameObject monster;
    public float timeToSpawn = 1f;
    public float spawnDelay = 5f; 

    void Update ()
    {
        timeToSpawn -= Time.deltaTime;
        if(timeToSpawn < 0f)
        {
            Instantiate(monster, transform.position, Quaternion.identity);
            timeToSpawn += spawnDelay;
        }
    }
}
