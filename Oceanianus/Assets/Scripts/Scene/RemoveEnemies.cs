using UnityEngine;
using System.Collections;

public class RemoveEnemies : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "EnemyShoot") {
			if(col.gameObject.GetComponent<LookAtTarget>().Clean == true){
				Destroy(col.gameObject);
			}
		}
		if (col.gameObject.tag == "EnemyMelee") {
			if(col.gameObject.GetComponent<LookAtTarget>().Clean == true){
				Destroy(col.gameObject);
			}
		}
		if (col.gameObject.tag == "EnemyCharge") {
			if(col.gameObject.GetComponent<LookAtTarget>().Clean == true){
				Destroy(col.gameObject);
			}
		}
	}
}
