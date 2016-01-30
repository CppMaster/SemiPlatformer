using UnityEngine;

public class Destroyable : MapObject
{

    public float maxHP = 100f;
    protected float currentHP = 100f;
	public GameObject progressBarHp;

    protected virtual void Start()
    {
        currentHP = maxHP;
    }

    public virtual void Damage(Puncher puncher)
    {
		
        currentHP -= puncher.GetDamage();

        setMyHp(GetPercentHP());

        if (currentHP <= 0f)
        {
			currentHP = 0f;
			setMyHp(GetPercentHP());
			Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    public float GetPercentHP()
    {
        return currentHP / maxHP;
    }

	public void setMyHp(float myHp)
	{
        if (progressBarHp == null) return;
        myHp = Mathf.Clamp01(myHp);
		progressBarHp.transform.localScale = new Vector3 (myHp, progressBarHp.transform.localScale.y, progressBarHp.transform.localScale.z);
	}

    protected virtual void Update()
    {
        setMyHp(GetPercentHP());
    }

}
	