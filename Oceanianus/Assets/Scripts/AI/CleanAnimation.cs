using UnityEngine;
using System.Collections;

public class CleanAnimation : MonoBehaviour {
	
	public bool Clean = false;
	public float Timer = 0f;
	public float TimedOut = 0.33f;

	private Animator anim;

	void Start(){
		anim = gameObject.GetComponent<Animator> ();
	}

	void Update () {
		if (Clean == true) {
			anim.SetInteger("state", 1);
			Timer += Time.deltaTime;
			if(Timer > TimedOut){
				Timer -= TimedOut;
			//} else if(Timer >= 20){
				anim.SetInteger("state", 0);
				Clean = false;
			}
		}
	}
}
