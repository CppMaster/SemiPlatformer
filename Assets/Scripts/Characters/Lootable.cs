using UnityEngine;

public class Lootable : Destroyable {

    public GameObject[] lootItems;
	public int soulNumber = 0;
	protected SoulCounter soulCount;


	protected override void Start ()
	{
		base.Start ();

		soulCount = GameObject.FindObjectOfType<SoulCounter> ();
	}

    public override void Die()
    {
        base.Die();

        if(lootItems.Length > 0)
            Instantiate(lootItems[Random.Range(0, lootItems.Length)], transform.position, Quaternion.identity);


		if(soulCount != null)
			soulCount.AddSouls (soulNumber);

    }
}
