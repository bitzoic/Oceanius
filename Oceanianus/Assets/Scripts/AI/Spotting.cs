using UnityEngine;
using System.Collections;

public class Spotting : MonoBehaviour {
	
	public bool EnemyCrawler = false;
	public bool EnemyWhole = false;
	public bool MoveAtSub = false;
	public bool MoveAtPlayer = false;
	public bool LookAtTarget = false;
	public bool EnemyChuthulu = false;
	public bool EnemyJellyfish = false;
	public bool ShootRapid = false;

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Spotter"){
			gameObject.GetComponent<EnemyHealth>().Activated = true;
		}
		if(col.gameObject.tag == "Spotter"){
			if(EnemyCrawler == true){
			gameObject.GetComponent<EnemyCrawler>().Activated = true;
			}
		}
		if(col.gameObject.tag == "Spotter"){
			if(EnemyChuthulu == true){
			gameObject.GetComponent<EnemyCuthulu>().Activated = true;
			}
		}
		if(col.gameObject.tag == "Spotter"){
			if(EnemyWhole == true){
			gameObject.GetComponent<EnemyWholeAnimation>().Activated = true;
			}
		}
		if(col.gameObject.tag == "Spotter"){
			if(MoveAtSub == true){
			gameObject.GetComponent<MoveAtSub>().Activated = true;
			}
		}
		if(col.gameObject.tag == "Spotter"){
			if(MoveAtPlayer == true){
			gameObject.GetComponent<MoveAtPlayer>().Activated = true;
			}
		}
		if(col.gameObject.tag == "Spotter"){
			if(LookAtTarget == true){
			gameObject.GetComponent<LookAtTarget>().Activated = true;
			}
		}
		if(col.gameObject.tag == "Spotter"){
			if(EnemyJellyfish == true){
				gameObject.GetComponent<EnemyJellyfish>().Activated = true;
			}
		}
		if(col.gameObject.tag == "Spotter"){
			if(ShootRapid == true){
				gameObject.GetComponent<ShootRapid>().Activated = true;
			}
		}
	}
	}

