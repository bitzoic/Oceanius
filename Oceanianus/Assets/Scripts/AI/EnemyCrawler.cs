using UnityEngine;
using System.Collections;

public class EnemyCrawler : MonoBehaviour {

	public bool GoingToShoot = false;
	public bool waitForShot = false;
	public bool Activated = false;
	public bool CloseToSub = false;
	public bool GoingRight = true;
	public float speed = 1f;
	public float WaitToShootTimer = 0f;
	public float WaitToShoot = 4.16f;
	public float WaitToMoveTimer = 0f;
	public float WaitToMove = 1.16f;
	public float TimeSpeed;

	void Start(){
		if (CloseToSub == true) {
			Activated = true;
				}
	}

	void FixedUpdate(){
		if (Activated == true){
			float TimeSpeed = Time.deltaTime * speed;
			rigidbody2D.AddForce (Vector2.right * TimeSpeed);
		}
	}
	
	void Update () {
		if (Activated == true) {
						if (GoingToShoot == false) {
								WaitToShootTimer += Time.deltaTime;
								if (WaitToShootTimer > WaitToShoot) {
										WaitToShootTimer -= WaitToShoot;
										//WaitToShootTimer = WaitToShootTimer + 1f;
								//} else if (WaitToShootTimer >= WaitToShoot) {
										GoingToShoot = true;
										WaitToShootTimer = 0f;
								}
						} else if (GoingToShoot == true) {
								if (waitForShot == false) {
										if (GoingRight == false) {
												speed = 0.3f;
										} else if (GoingRight == true) {
												speed = -0.3f;
										}
										waitForShot = true;
								}
						}
		
						if (waitForShot == true) {
								WaitToMoveTimer += Time.deltaTime;
								if (WaitToMoveTimer > WaitToMove) {
									WaitToMoveTimer -= WaitToMove;
									//WaitToMoveTimer = WaitToMoveTimer + 1f;
								//} else if (WaitToMoveTimer >= WaitToMove) {
										WaitToMoveTimer = 0f;
										waitForShot = false;
										gameObject.GetComponent<ShootOnce> ().Shoot ();
										GoingToShoot = false;
										if (GoingRight == true) {
												speed = 1f;
										} else if (GoingRight == false) {
												speed = -1f;
										}
								}
						}
				}
	}

	
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "RightCrawlerHit") {
			GoingRight = false;
			speed = -1f;
		}
		if(col.gameObject.tag == "LeftCrawlerHit"){
			GoingRight = true;
			speed = 1f;
		}
	}
}
