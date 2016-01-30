using UnityEngine;

public class Lootable : Destroyable {

    public GameObject[] lootItems;

    public override void Die()
    {
        base.Die();

        if(lootItems.Length > 0)
            Instantiate(lootItems[Random.Range(0, lootItems.Length)], transform.position, Quaternion.identity);
    }
}
