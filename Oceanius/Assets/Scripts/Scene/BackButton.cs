using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {

	public Canvas Helpy;
	public Canvas blah;

	void Start(){
		Helpy.enabled = false;
	}

	public void Credits(int index){
		Helpy.enabled = false;
		blah.enabled = true;
	}
}
