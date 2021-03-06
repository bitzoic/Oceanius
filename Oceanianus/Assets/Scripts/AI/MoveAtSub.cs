using UnityEngine;
using System.Collections;

public class MoveAtSub : MonoBehaviour
{

		public float speed = 100;
		public float ShooterDiff1;
		public float ShooterDiff2;
		public float Timer = 0f;
		public float AttackLength = 0.5f;
		public float timer1 = 0f;
		public float Timer2 = 0f;
		public bool Clean = false;
		public bool IsShooter = false;
		public bool StopShooter = false;
		public bool Activated = false;
		public bool CloseToSub = false;
		public bool Attacking = false;
		public bool RunOnce = false;
		public Transform SubWindow;
		private Vector3 Player;
		private Vector2 Playerdirection;
		private float Xdif;
		private float Ydif;
		void Start ()
		{
				if (CloseToSub == true) {
						Activated = true;
				}
		}

	/*void Update(){
		if (RunOnce == false && Clean == true) {

			RunOnce = true;
				}
				if (Activated == true && Clean == true) {
						if (Timer2 < 180) {
								Timer2 = Timer2 + 1;
								if (Timer2 >= 180) {
								
								}
						}
				}
		}*/

		void FixedUpdate ()
		{
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
								/*if (Xdif > 0f) {
										if (timer1 <= 60) {
												timer1 = timer1 + 1;
												rigidbody2D.AddForce (Vector2.right * -TimeSpeed);
										} else {
												rigidbody2D.AddForce (Vector2.up * TimeSpeed);
										}
								} else if (Xdif < 0f) {
										if (timer1 <= 60) {
												timer1 = timer1 + 1;
												rigidbody2D.AddForce (Vector2.right * TimeSpeed);
										} else {
												rigidbody2D.AddForce (Vector2.up * TimeSpeed);
										}
								}*/				
							} else if (SubWindow.GetComponent<SubWindowAnimation> ().Dead && Clean == false){
								Player = GameObject.Find ("Submarine").transform.position;
								Xdif = Player.x - transform.position.x;
								Ydif = Player.y - transform.position.y;
								Playerdirection = new Vector2 (Xdif, Ydif);
								float TimeSpeed = Time.deltaTime * speed;
								rigidbody2D.AddForce (-Playerdirection.normalized * TimeSpeed);
							}

						if (Attacking == true) {
								Timer += Time.deltaTime;
								if (Timer > AttackLength) {
										Timer -= AttackLength;
										//Timer = Timer + 1;
										speed = 0;
										//} else if (Timer >= AttackLength) {
										Timer = 0;
										Attacking = false;
										speed = 100f;
								}
						}


						if (StopShooter == true) {
								Player = GameObject.Find ("Submarine").transform.position;
								ShooterDiff1 = Player.x - transform.position.x;
								ShooterDiff2 = Player.y - transform.position.y;
								if (ShooterDiff2 > 2.6f) {
										if (ShooterDiff1 >= 0) {
												rigidbody2D.AddForce (Vector2.right * -10);
												rigidbody2D.AddForce (Vector2.up * -8);
										} else if (ShooterDiff1 < 0) {
												rigidbody2D.AddForce (Vector2.right * 10);
												rigidbody2D.AddForce (Vector2.up * -8);
										}
								} else if (ShooterDiff2 > 2f) {
										if (ShooterDiff1 >= 0) {
												rigidbody2D.AddForce (Vector2.right * -10);
												rigidbody2D.AddForce (Vector2.up * -6);
										} else if (ShooterDiff1 < 0) {
												rigidbody2D.AddForce (Vector2.right * 10);
												rigidbody2D.AddForce (Vector2.up * -6);
										} 
								} else if (ShooterDiff1 >= 0) {
										rigidbody2D.AddForce (Vector2.right * -8);
										rigidbody2D.AddForce (Vector2.up * 10);
								} else if (ShooterDiff1 < 0) {
										rigidbody2D.AddForce (Vector2.right * 8);
										rigidbody2D.AddForce (Vector2.up * 10);
								} 
						}
				}
		}

		public void Cleaned ()
		{
				Clean = true;
		}

		void OnColisionEnter2D (Collision2D col)
		{
				if (col.gameObject.tag == "Submarine") {
						Attacking = true;
				}
		}

		void OnTriggerEnter2D (Collider2D col)
		{
				if (col.gameObject.tag == "SubForcefield") {
						if (IsShooter == true) {
								StartCoroutine (ShooterStop ());
						}
				}
		}

		public void Attack ()
		{
				Attacking = true;
		}
	
		IEnumerator ShooterStop ()
		{
				StopShooter = true;
				yield return new WaitForSeconds (0.5f);
				StopShooter = false;
		}
}
