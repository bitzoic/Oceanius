using UnityEngine;
using System.Collections;

public class EnemyCuthulu : MonoBehaviour {

	public float speed = 200f;
	public float timer1 = 0f;
	public float AttackWait = 4.16f;
	public float timer2 = 0f;
	public float attacking = 1f;
	public float health = 10f;
	public bool Clean = true;
	public bool attack = false;
	public bool Activated = false;

	private Vector3 Player;
	private Vector2 Playerdirection;
	private float Xdif;
	private float Ydif;

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
						if(Clean == true){
							speed = 200f;
						}
		
						if (Clean == false) {
								if (attack == false) {
										timer1 += Time.deltaTime;
										if (timer1 > AttackWait) {
											timer1 -= AttackWait;
											//timer2 = timer2 + 1;
										//} else if (timer1 >= AttackWait) {
												attack = true;
												timer1 = 0f;
										}
								} else if (attack == true) {
										speed = 1500f;
										timer2 += Time.deltaTime;
										if (timer2 > attacking) {
												timer2 -= attacking;
												//timer2 = timer2 + 1;
										//} else if (timer2 >= attacking) {
												attack = false;
												speed = 200f;
												timer2 = 0f;
										}
								}
						}
				}
		}
	
	public void Cleaned(){
		Clean = true;
	}

}

