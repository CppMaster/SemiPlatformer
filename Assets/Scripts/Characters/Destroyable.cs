using UnityEngine;

public class Destroyable : MapObject
{

    public float maxHP = 100f;
    protected float currentHP = 100f;

    protected virtual void Start()
    {
        currentHP = maxHP;
    }

    public virtual void Damage(Puncher puncher)
    {
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

}
