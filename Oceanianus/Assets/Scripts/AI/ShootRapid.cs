using UnityEngine;
using System.Collections;

public class ShootRapid : MonoBehaviour {

	float timeToFire = 0;
	float timeToSpawnEffect = 0;
	public bool IfFirePoint = false;
	public bool IfFirePoint2 = false;
	public bool IfFirePoint3 = false;
	public bool IfFirePoint4 = false;
	public bool IfFirePoint5 = false;
	public bool IfFirePoint6 = false;
	public bool IfFirePoint7 = false;
	public bool IfFirePoint8 = false;
	public bool Cleaned = false;
	Transform firePoint;
	Transform firePoint2;
	Transform firePoint3;
	Transform firePoint4;
	Transform firePoint5;
	Transform firePoint6;
	Transform firePoint7;
	Transform firePoint8;
	public bool Activated = false;

	public Transform BulletTrailPrefab;
	public float effectSpawnRate = 10;
	public float fireRate = 0;
	

	void Update(){
		if (Time.time > timeToFire && Activated == true && Cleaned == false) {
			timeToFire = Time.time + 1/fireRate;
			Shoot();
		}
	}

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

	public void Shoot () {
		if (Time.time >= timeToSpawnEffect) {
			gameObject.GetComponent<MoveAtSub>().Attack();
			gameObject.GetComponent<EnemyWholeAnimation>().Attack ();
			Effect ();
			timeToSpawnEffect = Time.time + 1/effectSpawnRate;
		}
	}

	void Effect () {
		if (IfFirePoint == true) {
						Instantiate (BulletTrailPrefab, firePoint.position, firePoint.rotation);
				}
		if (IfFirePoint2 == true) {
						Instantiate (BulletTrailPrefab, firePoint2.position, firePoint2.rotation);
				}
		if (IfFirePoint3 == true) {
						Instantiate (BulletTrailPrefab, firePoint3.position, firePoint3.rotation);
				}
		if (IfFirePoint4 == true) {
						Instantiate (BulletTrailPrefab, firePoint4.position, firePoint4.rotation);
				}
		if (IfFirePoint5 == true) {
						Instantiate (BulletTrailPrefab, firePoint5.position, firePoint5.rotation);
				}
		if (IfFirePoint6 == true) {
						Instantiate (BulletTrailPrefab, firePoint6.position, firePoint6.rotation);
				}
		if (IfFirePoint7 == true) {
						Instantiate (BulletTrailPrefab, firePoint7.position, firePoint7.rotation);
				}
		if (IfFirePoint8 == true) {
						Instantiate (BulletTrailPrefab, firePoint8.position, firePoint8.rotation);
				}
	}

}
