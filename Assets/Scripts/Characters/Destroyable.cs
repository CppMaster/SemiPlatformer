using UnityEngine;

public class Destroyable : MapObject
{

    public float maxHP = 100f;
    float currentHP = 100f;

    protected override void Start()
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

}
