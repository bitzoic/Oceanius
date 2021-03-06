using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 900f;
	public float maxSpeed = 100f;
	public float Timer = 0;
	public float Timed1 = 3.33f;
	public float SpeedIncrease = 600;
	public bool surfaceTouch = false;
	public bool SurfaceFall = false;
	public bool Menu = true;
	public bool Dead = false;
	public bool Timed = true;
	public bool TimerEnabled = false;
	public ParticleSystem AirBubbles;

	private Animator anim;

	// Use this for initialization
	void Start () {
		rigidbody2D.gravityScale = 0;
		AirBubbles.emissionRate = 0;
		anim = gameObject.GetComponent<Animator> ();
		StartCoroutine (bubbleAir ());
	}


	void FixedUpdate(){
		if (Time.timeScale > 0f) {
						if (Menu == false && Dead == false) {
								Vector3 mousePos = Input.mousePosition;
								mousePos.z = 0f;
			
								Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
								mousePos.x = mousePos.x - objectPos.x;
								mousePos.y = mousePos.y - objectPos.y;
			
								var speedTurn = 500f;
			
								float angle = Mathf.Atan2 (mousePos.y, mousePos.x) * Mathf.Rad2Deg;
								Quaternion qTo = Quaternion.Euler (new Vector3 (0, 0, angle));
								transform.rotation = Quaternion.RotateTowards (transform.rotation, qTo, speedTurn * Time.deltaTime);


								var pos = Input.mousePosition;
								pos = Camera.main.ScreenToWorldPoint (pos);
								var dir = pos - transform.position;
								float TimeSpeed = Time.deltaTime * speed;
								if(rigidbody2D.velocity.magnitude < maxSpeed)
								{
									rigidbody2D.AddForce (dir * TimeSpeed);
								}
								
						}
				}
	}

	
	// Update is called once per frame
	void Update () {

				if (TimerEnabled == true) {
						Timer += Time.deltaTime;
						if (Timer > Timed1) {
								Timer -= Timed1;
								//Timer = Timer + 1;
						//} else if (Timer >= 200) {
								Timer = 0;
								TimerEnabled = false;
								maxSpeed = 4;
						}
				}

						//Animation
						anim.SetInteger ("state", 0);
						var absVel = Mathf.Abs (rigidbody2D.velocity.magnitude);
						if (absVel < 1f) {
								anim.speed = 0.1f;
						} else 	if (absVel > 1f && absVel < 3f) {
								anim.speed = 0.3f;
						} else 	if (absVel > 3f && absVel < 5f) {
								anim.speed = 0.7f;
						} else 	if (absVel > 5f) {
								anim.speed = 1f;
						}
				}

	public void UpgradeSpeed(){
		if (Timed == true) {
			maxSpeed = SpeedIncrease;
			TimerEnabled = true;
		} else {
			maxSpeed = SpeedIncrease;
		}
	}

	void OnCollisionEnter2D(Collision2D col)   {
		if (col.gameObject.tag == "Surface") {
			var absVelY = Mathf.Abs (rigidbody2D.velocity.y);
			if(absVelY < 0.5){
				rigidbody2D.gravityScale = 0.6f;
				SurfaceFall = true;
				StartCoroutine( SurfaceDown() );
			} else if (absVelY < 1 && absVelY > 0.5){
				rigidbody2D.gravityScale = 1f;
				SurfaceFall = true;
				StartCoroutine( SurfaceDown() );
			} else if (absVelY > 1){
				rigidbody2D.gravityScale = 1.5f;
				SurfaceFall = true;
				StartCoroutine( SurfaceDown() );
			}
		}
	}
	//Surface
	IEnumerator SurfaceDown(){
		if (SurfaceFall == true) {
			yield return new WaitForSeconds(0.2f);
			rigidbody2D.gravityScale = 0;
			SurfaceFall = false;
		}
	}
	//Air bubbles
	IEnumerator bubbleAir(){
		var bubbles = 5;
		while(bubbles > 0){
			yield return new WaitForSeconds (10);
			AirBubbles.emissionRate = 7f;
			yield return new WaitForSeconds(2);
			AirBubbles.emissionRate = 0f;
		}
	}

}
