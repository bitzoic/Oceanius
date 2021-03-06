using UnityEngine;
using System.Collections;

public class LookAtTarget : MonoBehaviour {

	public Transform targetTransform;
	public Transform SubWindow;
	public float speedSpin = 6f;
	public bool Clean = false;
	public bool Activated = false;
	public bool CloseToSub = false;

	void Start(){
		if (CloseToSub == true) {
			Activated = true;
				}
	}

	void FixedUpdate () {
				if (Activated == true) {
						if (Clean == false) {
								Vector3 vectorToTarget = targetTransform.position - transform.position;
								float angle = Mathf.Atan2 (vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
								Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
								transform.rotation = Quaternion.Slerp (transform.rotation, q, Time.deltaTime * speedSpin);
						} else if (Clean == true) {
								Vector3 vectorToTarget = targetTransform.position - transform.position;
								float angle = Mathf.Atan2 (vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
								Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
								transform.rotation = Quaternion.Slerp (transform.rotation, q, Time.deltaTime * speedSpin);
						} else if (SubWindow.GetComponent<SubWindowAnimation> ().Dead && Clean == false){
								Vector3 vectorToTarget = targetTransform.position - transform.position;
								float angle = Mathf.Atan2 (vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
								Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
								transform.rotation = Quaternion.Slerp (transform.rotation, q, Time.deltaTime * speedSpin);
						} 
				}
		}

	public void Cleaned(){
		Clean = true;
	}
}
