using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public float fireRate = 0;
	public float BulletUpgrade = 10;
	public float Timer2 = 0;
	public float Timed2 = 6;
	public LayerMask whatToHit;
	public ParticleSystem particles;
	public float Timer = 0;
	public float Timed1 = 0.16f;
	public Transform BulletTrailPrefab;
	float timeToSpawnEffect = 0;
	public float effectSpawnRate = 10;
	public bool Menu = true;
	public bool Timed = true;
	public bool TimerEnabled = false;
	public bool PlayOnce = false;
	public AudioClip ShootSound;
	
	float timeToFire = 0;
	Transform firePoint;

	void Awake () {
		firePoint = transform.FindChild ("FirePoint");
	}

	void Update () {
		if (TimerEnabled == true) {
			//Timed2 += Time.deltaTime;
			if(Timer2 < 360){
				//Timer2 -= Timed2;
				Timer2 = Timer2 + 1;
			} else if (Timer2 >= 360){
				Timer2 = 0;
				TimerEnabled = false;
				fireRate = 2;
			}
		}
		if (particles.emissionRate == 100) {
			Timer += Time.deltaTime;
			if(Timer > Timed1){
				Timer -= Timed1;
				//Timer = Timer + 1;
			//} else if (Timer >= 10){
				Timer = 0;
				particles.emissionRate = 0;
			}
				}
			if (Input.GetButtonUp ("Fire1") && Time.time > timeToFire && Menu == false) {
				timeToFire = Time.time + 1/fireRate;
				Shoot();
			}
		}
	
	void Shoot () {
		if (Time.time >= timeToSpawnEffect) {
			Effect ();
			timeToSpawnEffect = Time.time + 1/effectSpawnRate;
		}
	}
	
	void Effect () {
		if (PlayOnce == false) {
			AudioSource.PlayClipAtPoint(ShootSound, transform.position);
			PlayOnce = true;
		}
		AudioSource.PlayClipAtPoint(ShootSound, transform.position);
		Instantiate (BulletTrailPrefab, firePoint.position, firePoint.rotation);
		particles.emissionRate = 100;
	}

	public void Upgrade(){
		if (Timed == true) {
			fireRate = BulletUpgrade;
			TimerEnabled = true;
		} 
	}
}
