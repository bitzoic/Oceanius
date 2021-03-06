using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int BulletSpeed = 230;
	public float DecaySpeed = 3f;
	public bool IsPlayer = false;
	public bool IsShooter = false;
	public bool PlayOnce = false;
	public SpriteRenderer sprite;
	public SpriteRenderer Splash;
	public Transform Splashy;
	public AudioClip HitSound;

	void Start(){
		renderer.enabled = false;
	}
	
	void Update () {
		if (gameObject.tag == "DeadBullet") {
			Splash.enabled = true;
			Splashy.GetComponent<PlaySplashAnimation>().Dead = true;
			if(PlayOnce == false){
				PlayOnce = true;
				AudioSource.PlayClipAtPoint(HitSound, transform.position);
			}
		}
		transform.Translate (Vector3.right * Time.deltaTime * BulletSpeed);
		Destroy (gameObject, DecaySpeed);
	}
	
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Submarine") {
			particleSystem.emissionRate = 0;
			BulletSpeed = 0;	
			StartCoroutine(killBullet());
			sprite.enabled = false;
		}		
		if (col.gameObject.tag == "Player" && IsPlayer == false) {
			particleSystem.emissionRate = 0;
			BulletSpeed = 0;	
			StartCoroutine(killBullet());
			sprite.enabled = false;
		}		
		if (col.gameObject.tag == "EnemyMelee") {
			particleSystem.emissionRate = 0;
			BulletSpeed = 0;	
			StartCoroutine(killBullet());
			sprite.enabled = false;
		}
		if (col.gameObject.tag == "EnemyShoot" && IsShooter == false) {
			particleSystem.emissionRate = 0;
			BulletSpeed = 0;	
			StartCoroutine(killBullet());
			sprite.enabled = false;
		}		
		if (col.gameObject.tag == "Wall") {
			Debug.Log("Wall Hit!");
			particleSystem.emissionRate = 0;
			BulletSpeed = 0;
			StartCoroutine(killBullet());
			sprite.enabled = false;
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Wall") {
			Debug.Log("Wall Hit!");
			particleSystem.emissionRate = 0;
			BulletSpeed = 0;
			StartCoroutine(killBullet());
			sprite.enabled = false;
		}
	}
	
	IEnumerator killBullet(){
		yield return new WaitForSeconds (0.01f);
		gameObject.tag = "DeadBullet";
	}
}
