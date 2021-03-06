using UnityEngine;
using System.Collections;

public class SubWindowAnimation : MonoBehaviour {

	public float Health = 100;
	public float Timer = 0;
	public float Timer2 = 0;
	public SpriteRenderer Spritel;
	public bool Dead = false;

	private Animator anim;
	
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
	}

	void Update () {
		if (Dead == true) {
			anim.SetInteger("state", 2);
			Spritel.enabled = false;
		}
		if (Health <= 30 && Dead == false) {
			anim.SetInteger("state", 1);
			if(Timer < 30){
				Spritel.enabled = false;
				Timer = Timer + 1;
			} else if(Timer >= 30){
				Spritel.enabled = true;
				if(Timer2 < 30){
					Timer2 = Timer2 + 1;
				} else if (Timer2 >= 30){
					Timer = 0;
					Timer2 = 0;
				}
			}
		}
	}
}
