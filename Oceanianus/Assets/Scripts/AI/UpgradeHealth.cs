using UnityEngine;
using System.Collections;

public class UpgradeHealth : MonoBehaviour {

	public Transform Submarine;
	public Transform Sub;
	public bool Menu = false;
	public bool Level1 = false;
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
			Submarine.GetComponent<SubHealth>().AddHealth();
			Destroy(gameObject);
			AudioSource.PlayClipAtPoint(SoundEffect, transform.position);
		}
	}
}