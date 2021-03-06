using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour {

	private Vector3 mousePosition;
	public float moveSpeed = 1000f;
	public Transform targetTransform;
	public float speedSpin = 1000;
	public Transform Sub;

	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () {
		mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
		transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);

		if (!Sub.GetComponent<SinkSub> ().MenuRunning) {
						Vector3 vectorToTarget = targetTransform.position - transform.position;
						float angle = Mathf.Atan2 (vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
						Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
						transform.rotation = Quaternion.Slerp (transform.rotation, q, Time.deltaTime * speedSpin);
				}
	}
}
