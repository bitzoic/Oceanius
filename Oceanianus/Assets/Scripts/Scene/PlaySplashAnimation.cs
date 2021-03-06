using UnityEngine;
using System.Collections;

public class PlaySplashAnimation : MonoBehaviour {

	public bool Dead = false;
	public float Timer = 0;
	public SpriteRenderer sprite;

	private Animator anim;

	void Start () {
		anim = gameObject.GetComponent<Animator> ();
	}

	void Update () {
		if (Dead == true) {
			anim.SetInteger("state", 1);
		}
		if (Dead == true && Timer < 30) {
			Timer = Timer + 1;
		} else if (Dead == true && Timer >= 30) {
			sprite.enabled = false;
		}
	}
}
