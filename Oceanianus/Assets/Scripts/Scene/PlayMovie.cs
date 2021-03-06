using UnityEngine;
using System.Collections;

public class PlayMovie : MonoBehaviour {

	public MovieTexture movTexture;
	
	// Use this for initialization
	void Start () {
		renderer.material.mainTexture = movTexture;
		movTexture.Play();
	}
}
