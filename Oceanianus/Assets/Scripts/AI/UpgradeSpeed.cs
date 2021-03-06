using UnityEngine;
using System.Collections;

public class UpgradeSpeed : MonoBehaviour {

	public Transform Player;
	public bool Menu = false;
	public bool Level1 = false;
	public Transform Sub;
	public SpriteRenderer Spritel;
	public AudioClip SoundEffect;

	void Start(){
		if (Level1 == true) {
			Spritel.enabled = false;
		}
	}

	void Update(){
		if (Menu == true) {
			if (!Sub.GetComponent<SinkSub> ().MenuRunning)
				Destroy(gameObject);
		}
		if (Level1 == true) {
			if (!Sub.GetComponent<SinkSub> ().MenuRunning){
				Spritel.enabled = true;
				Level1 = false;
			}
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			Player.GetComponent<Player>().UpgradeSpeed();
			Destroy(gameObject);
			AudioSource.PlayClipAtPoint(SoundEffect, transform.position);
		}
	}
}
