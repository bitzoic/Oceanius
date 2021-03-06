using UnityEngine;
using System.Collections;

public class LeavePlayer : MonoBehaviour {

	public Transform UIThing;
	public bool Enableded = false;

	void Update () {
		if (Enableded == true) {
			Enableded = false;
			UIThing.GetComponent<StayNearSubUI>().Enabled = false;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
			Enableded = true;
		}
	}
}
