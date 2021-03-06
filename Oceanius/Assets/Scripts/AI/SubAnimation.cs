using UnityEngine;
using System.Collections;

public class SubAnimation : MonoBehaviour {

	public float Health = 100f;
	public bool Dead = false;

	private Animator anim;
	
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
	}

	void Update () {
		if (Health <= 66 && Health > 33) {
				anim.SetInteger ("state", 1);
		} else if (Health <= 33 && Health > 10) {
				anim.SetInteger ("state", 2);
		} else if (Health <= 10 && Health > 0) {
				anim.SetInteger ("state", 3);
		} else if(Health <= 0){
				anim.SetInteger ("state", 4);
		}
		if (Dead == true) {
			anim.SetInteger ("state", 4);
		}
	}
}
