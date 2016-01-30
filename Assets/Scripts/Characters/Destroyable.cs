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
		setMyHp (GetPercentHP());
        currentHP -= puncher.punchDamage;

        if(currentHP < 0f)
        {
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
		progressBarHp.transform.localScale = new Vector3 (myHp, progressBarHp.transform.localScale.y, progressBarHp.transform.localScale.z);
	}

}
	