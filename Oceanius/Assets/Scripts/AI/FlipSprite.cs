using UnityEngine;
using System.Collections;

public class FlipSprite : MonoBehaviour {
	
	public bool ScaleOnce = false;
	public bool ScaledOnce = false;
	public bool ScaleOnce1 = false;
	public Transform SubWindow;

	// Update is called once per frame
	void Update () {
		if (ScaleOnce == true && ScaledOnce == false) {
			ScaleOnce = false;
			ScaledOnce = true;
			transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		}
		if (SubWindow.GetComponent<SubWindowAnimation> ().Dead && ScaleOnce1 == false && ScaledOnce == false) {
			ScaleOnce1 = true;
			transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		}
	}

	public void Cleaned(){
		ScaleOnce = true;
	}

}
