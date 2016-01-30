using UnityEngine;
using System.Collections;

public class PlayerHp : MonoBehaviour {

	public float max_Hp = 100f;
	public float current_Hp = 0f;
	public GameObject healthBar; 
	// Use this for initialization
	void Start () {
		current_Hp = max_Hp;
		InvokeRepeating ("RemoveHp", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void RemoveHp() {
		current_Hp -= 10f;
		float calcHp = current_Hp / max_Hp;
		setMyHp (calcHp);

		if (current_Hp == 0f) {
			
			CancelInvoke ("RemoveHp");
		}

	}

	public void setMyHp(float myHp)
	{
		healthBar.transform.localScale = new Vector3 (myHp, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}
}
