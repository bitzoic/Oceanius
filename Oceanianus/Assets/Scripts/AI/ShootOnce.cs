using UnityEngine;
using System.Collections;

public class ShootOnce : MonoBehaviour {
	
	float timeToSpawnEffect = 0;
	Transform firePoint;
	Transform firePoint2;
	Transform firePoint3;
	Transform firePoint4;
	Transform firePoint5;
	Transform firePoint6;
	Transform firePoint7;
	Transform firePoint8;
	
	public Transform BulletTrailPrefab;
	public float effectSpawnRate = 10;
	public float fireRate = 0;
	
	void Awake () {
		firePoint = transform.FindChild ("FirePoint");
		firePoint2 = transform.FindChild ("FirePoint2");
		firePoint3 = transform.FindChild ("FirePoint3");
		firePoint4 = transform.FindChild ("FirePoint4");
		firePoint5 = transform.FindChild ("FirePoint5");
		firePoint6 = transform.FindChild ("FirePoint6");
		firePoint7 = transform.FindChild ("FirePoint7");
		firePoint8 = transform.FindChild ("FirePoint8");
	}

	public void Shoot() {
		if (Time.time >= timeToSpawnEffect) {
			Effect ();
			timeToSpawnEffect = Time.time + 1/effectSpawnRate;
		}
	}
	
	void Effect () {
		Instantiate (BulletTrailPrefab, firePoint.position, firePoint.rotation);
		Instantiate (BulletTrailPrefab, firePoint2.position, firePoint2.rotation);
		Instantiate (BulletTrailPrefab, firePoint3.position, firePoint3.rotation);
		Instantiate (BulletTrailPrefab, firePoint4.position, firePoint4.rotation);
		Instantiate (BulletTrailPrefab, firePoint5.position, firePoint5.rotation);
		Instantiate (BulletTrailPrefab, firePoint6.position, firePoint6.rotation);
		Instantiate (BulletTrailPrefab, firePoint7.position, firePoint7.rotation);
		Instantiate (BulletTrailPrefab, firePoint8.position, firePoint8.rotation);
	}

}
