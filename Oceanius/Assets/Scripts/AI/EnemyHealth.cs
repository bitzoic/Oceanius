using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public Transform CleanAnimation;
	public Collider2D SwimThu;
	public float StartingHealth = 100f;
	public float DamageTaken = 100f;
	public float CurrentHealth;
	public bool Damaged = false;
	public bool LookAtTarget = false;
	public bool MoveAtSub = false;
	public bool MoveAtPlayer = false;
	public bool EnemyCuthulu = false;
	public bool FlipSprite = false;
	public bool EnemyHeadAnimation = false;
	public bool EnemyBodyAnimation = false;
	public bool EnemyWholeAnimation = false;
	public bool IsShootRapid = false;
	public bool Jellyfish = false;
	public bool AnimationPlayed = false;
	public bool ScaleOnce = false;
	public bool Activated = false;

	void Start(){
		CurrentHealth = StartingHealth;
	}
	
	void Update () {
		if (CurrentHealth <= 0) {
			if(LookAtTarget == true){
				gameObject.GetComponent<LookAtTarget>().Cleaned();
			}
			if(MoveAtSub == true){
				gameObject.GetComponent<MoveAtSub>().Cleaned();
			}
			if(MoveAtPlayer == true){
				gameObject.GetComponent<MoveAtPlayer>().Cleaned();
			}
			if(FlipSprite == true && ScaleOnce == false){
				gameObject.GetComponent<FlipSprite>().Cleaned();
				ScaleOnce = true;
			}
			if(IsShootRapid == true){
				gameObject.GetComponent<ShootRapid>().Cleaned = true;
			}
			if(EnemyWholeAnimation == true){
				gameObject.GetComponent<EnemyWholeAnimation>().Clean = true;
			}
			if(Jellyfish == true){
				gameObject.GetComponent<EnemyJellyfish>().Cleaned();
			}
			if(EnemyCuthulu == true){
				gameObject.GetComponent<EnemyCuthulu>().Cleaned();
			}
			if(AnimationPlayed == false){
				CleanAnimation.GetComponent<CleanAnimation>().Clean = true;
				AnimationPlayed = true;
			}
		}
		if (Damaged == true && Activated == true) {
			Damaged = false;
			CurrentHealth = CurrentHealth - DamageTaken;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "PlayerBullet" && Activated == true) {
			Damaged = true;
		}
		if (col.gameObject.tag == "Impermeable" && Damaged == true) {
			SwimThu.enabled = false;
		}
	}
}
