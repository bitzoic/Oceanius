using UnityEngine;
using System.Collections;

public class MoveAtPlayer : MonoBehaviour {

	public float speed = 1;
	public bool Clean = false;
	public bool Activated  = false;
	public bool CloseToSub = false;
	
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
						if (Clean == false) {
								Player = GameObject.Find ("Player").transform.position;
								Xdif = Player.x - transform.position.x;
								Ydif = Player.y - transform.position.y;
								Playerdirection = new Vector2 (Xdif, Ydif);
								float TimeSpeed = Time.deltaTime * speed;
								rigidbody2D.AddForce (Playerdirection.normalized * TimeSpeed);
						} else if (Clean == true) {
								Player = GameObject.Find ("Player").transform.position;
								Xdif = Player.x - transform.position.x;
								Ydif = Player.y - transform.position.y;
								Playerdirection = new Vector2 (Xdif, Ydif);
								float TimeSpeed = Time.deltaTime * speed;
								rigidbody2D.AddForce (-Playerdirection.normalized * TimeSpeed);
						}
				}
		}
	public void Cleaned(){
		Clean = true;
	}
}
