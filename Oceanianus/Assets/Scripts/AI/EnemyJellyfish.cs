using UnityEngine;
using System.Collections;

public class EnemyJellyfish : MonoBehaviour {

	public float speed = 100f;
	public float timer1 = 0f;
	public float Timed = 20;
	public bool Clean = true;
	public bool Activated = false;
	public bool CloseToSub = false;
	public bool SpeedIncrease = false;
	public Transform SubWindow;
	
	private Vector3 Player;
	private Vector2 Playerdirection;
	private float Xdif;
	private float Ydif;
	
	
	void Start(){
		if (CloseToSub == true) {
			Activated = true;
		}
	}
	
	void FixedUpdate () {
		if (Activated == true) {
			if (Clean == false && !SubWindow.GetComponent<SubWindowAnimation> ().Dead) {
				Player = GameObject.Find ("Submarine").transform.position;
				Xdif = Player.x - transform.position.x;
				Ydif = Player.y - transform.position.y;
				Playerdirection = new Vector2 (Xdif, Ydif);
				float TimeSpeed = Time.deltaTime * speed;
				rigidbody2D.AddForce (Playerdirection.normalized * TimeSpeed);
			} else if (Clean == true) {
				Player = GameObject.Find ("Submarine").transform.position;
				Xdif = Player.x - transform.position.x;
				Ydif = Player.y - transform.position.y;
				Playerdirection = new Vector2 (Xdif, Ydif);
				float TimeSpeed = Time.deltaTime * speed;
				rigidbody2D.AddForce (-Playerdirection.normalized * TimeSpeed);
			} else if (SubWindow.GetComponent<SubWindowAnimation> ().Dead && Clean == false){
				Player = GameObject.Find ("Submarine").transform.position;
				Xdif = Player.x - transform.position.x;
				Ydif = Player.y - transform.position.y;
				Playerdirection = new Vector2 (Xdif, Ydif);
				float TimeSpeed = Time.deltaTime * speed;
				rigidbody2D.AddForce (-Playerdirection.normalized * TimeSpeed);
			}
			//timer1 += Time.deltaTime;
			if(timer1 < Timed){
				timer1 = timer1 +1f;
				speed = 20;
				//timer1 -= Timed;
			} else if(timer1 >= Timed){
				timer1 = 0f;
				speed = 1000f;
			}
		}
	}
	
	public void Cleaned(){
		Clean = true;
	}
}
