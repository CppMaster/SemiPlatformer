using UnityEngine;
public class ActivateOnDestroy : MonoBehaviour {

	public GameObject toActivate;

	void OnDestroy()
	{
        if(toActivate != null)
		    toActivate.SetActive(true);
	}
}
