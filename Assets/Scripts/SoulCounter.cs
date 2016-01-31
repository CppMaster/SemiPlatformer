using UnityEngine;
using System.Collections;

public class SoulCounter : MonoBehaviour {

	UnityEngine.UI.Text text;
	public int count = 0; 


	// Use this for initialization
	void Start () {
		count = 0;
		text = GetComponent<UnityEngine.UI.Text>();
		UpdateText ();
	}


	void UpdateText(){
		text.text = "x " + count.ToString ();
	}

	public void AddSouls(int numberOfSouls){
		count += numberOfSouls;
		UpdateText ();
	}
}
