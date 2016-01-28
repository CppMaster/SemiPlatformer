using UnityEngine;

public class Punchable : MonoBehaviour
{

    public virtual void Punch(Puncher puncher)
    {
        Debug.Log(gameObject.name + " is punched by " + puncher.gameObject.name);
    }

}
