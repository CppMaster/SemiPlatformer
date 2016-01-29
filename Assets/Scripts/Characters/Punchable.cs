using UnityEngine;

public class Punchable : MonoBehaviour
{

    public float maxHP = 100f;
    float currentHP = 100f;

    public virtual void Punch(Puncher puncher)
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
