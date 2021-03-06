using UnityEngine;
using System.Collections;

public class EnemyMorayEeel : MonoBehaviour {

	public bool MoveOut = false;
	public bool IsAttacking = false;
	public bool Clean = false;
	public bool Activated = false;
	public float Timer = 0;

	private Animator anim;

	void Start () {
		anim = gameObject.GetComponent<Animator> ();
	}

	void Update () {
		if (MoveOut == true) {
			anim.SetInteger("state", 1);
			MoveOut = false;
			Activated = true;
		}
		if(IsAttacking == true && Clean == false && Activated == true){
			if(Timer < 30){
				Timer = Timer + 1;
			} else if (Timer >= 30){
				Timer = 0;
				IsAttacking = false;
			}
			anim.SetInteger("state", 3);
		}
		if (IsAttacking == false && Clean == false && Activated == true) {
			anim.SetInteger("state", 2);
			}
		 if(Clean == true){
			anim.SetInteger("state", 4);
			}
		}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Submarine") {
			IsAttacking = true;
		}
	}
}




