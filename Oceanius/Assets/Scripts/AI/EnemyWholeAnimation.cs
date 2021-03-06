using UnityEngine;
using System.Collections;

public class EnemyWholeAnimation : MonoBehaviour
{

		public bool Clean = false;
		public bool IsAttacking = false;
		public bool Activated = false;
		public bool CloseToSub = false;
		public bool IsAngler = false;
		public bool LightEnabled = false;
		public bool InBetween = false;
		public Light lighty;
		public float Timer = 0f;
		public float AttackLength = 0.5f;
		public float speed = 100;
		public SpriteRenderer Spritey;
		private Animator anim;
		private Vector3 Player;
		private Vector2 Playerdirection;
		private float Xdif;
		private float Ydif;

		void Start ()
		{
				anim = gameObject.GetComponent<Animator> ();
				Spritey.enabled = false;
		}
	
		void Update ()
		{
				if (Activated == true) {
						gameObject.rigidbody2D.isKinematic = false;
						Spritey.enabled = true;
						if (Clean == false && IsAttacking == false) {
								anim.SetInteger ("state", 0);
						}
						if (IsAttacking == true && IsAngler == true) {
								if (lighty.intensity <= 6) {
										lighty.enabled = true;
										lighty.intensity += 0.8f;
										LightEnabled = true;
								}
						}
						if (IsAttacking == false && IsAngler == true) {
								if (lighty.intensity >= 0.7) {
										lighty.intensity -= 0.8f;
										InBetween = true;
								} else {
										lighty.enabled = false;
										LightEnabled = false;
										InBetween = false;
								}
						}
						if (IsAttacking == true && Clean == false) {
								anim.SetInteger ("state", 1);
								//Timer += Time.deltaTime;
								if (Timer < AttackLength) {
										//Timer -= AttackLength;
										Timer = Timer + 1;
								} else if (Timer >= AttackLength) {
										Timer = 0f;
										IsAttacking = false;
								}
						}
						if (Clean == true) {
								anim.SetInteger ("state", 2);
								if (LightEnabled == true || InBetween == true) {
										if (lighty.intensity >= 0.7) {
												lighty.intensity -= 0.8f;
										} else {
												lighty.enabled = false;
												LightEnabled = false;
												InBetween = false;
										}
								}
						}
				} else if (Activated == false) {
						Spritey.enabled = false;
				}
		}
	
		public void Cleaned ()
		{
				Clean = true;
		}

		public void Attack ()
		{
				IsAttacking = true;
		}

		void OnTriggerEnter2D (Collider2D col)
		{
				if (col.gameObject.tag == "Submarine") {
						IsAttacking = true;		
				} 
		}



}
