using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {

	public string scene;

	// Use this for initialization
	void Start () {
		Application.LoadLevel (scene);
	}
}
