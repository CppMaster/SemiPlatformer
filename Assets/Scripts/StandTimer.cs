using UnityEngine;
using System.Collections;

public class StandTimer : MonoBehaviour {

	public UnityEngine.UI.Text secondTime;
	private int count = 0;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("CountSecondTime", 1f, 1f);
	}
	


	void CountSecondTime() {
		count += 1;
		secondTime.text = count.ToString ();
		//diplaySecond.text = count.ToString ();
	}
}
