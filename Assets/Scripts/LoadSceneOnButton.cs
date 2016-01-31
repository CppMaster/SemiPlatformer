using UnityEngine;
using System.Collections;

public class LoadSceneOnButton : MonoBehaviour {

    public string sceneName;

	public void OnMouseDown()
    {
        Application.LoadLevel(sceneName);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Application.LoadLevel(sceneName);

		if (Input.GetButtonDown( "Fire2"))
			Application.LoadLevel(sceneName);
    }
}
