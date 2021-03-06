using UnityEngine;
using System.Collections;

public class EnemyDirection : MonoBehaviour
{

	public bool FacingRight = true;
	public bool Timed = false;
	public float Timer = 0;
	public float TargetTime = 0.5f;
	public bool Playerl = false;

	void Update (){
				if (Timed == false) {
						if (transform.rotation.eulerAngles.z > 90 && transform.rotation.eulerAngles.z < 270 && FacingRight == true) {
								FacingRight = false;
								transform.localScale = new Vector3 (transform.localScale.x, -transform.localScale.y, transform.localScale.z);
								Timed = true;
						} 
						if (transform.rotation.eulerAngles.z < 90 && FacingRight == false) {
								FacingRight = true;
								transform.localScale = new Vector3 (transform.localScale.x, -transform.localScale.y, transform.localScale.z);
								Timed = true;
						}
						if (transform.rotation.eulerAngles.z > 270 && FacingRight == false) {
								FacingRight = true;
								transform.localScale = new Vector3 (transform.localScale.x, -transform.localScale.y, transform.localScale.z);
								Timed = true;
						}	
				} else if (Timed == true && Playerl == false) {
						Timer += Time.deltaTime;
						if (Timer > TargetTime) {
								Timer -= TargetTime;
								//Timer = Timer + 1;
								//} else if (Timer >= 20){
								Timer = 0;
								Timed = false;
						}
				} else if (Playerl == true && Timed == true) {
						Timed = false;
				}
		}
}

