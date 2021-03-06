using UnityEngine;
using System.Collections;

public class SinkSub : MonoBehaviour {

	public float speed = 0;
	public float timer1 = 0;
	public float TargetSwitchTime = 200;
	public float timer2 = 0;
	public float WaterTimer = 0;
	public float HitWater = 60f;
	public float StopSwitchTime = 200f;
	public float NormalSpeed = -0.6f;
	public bool WaterStop = false;
	public bool WaterDrop = false;
	public bool WaterHit = false;
	public bool MenuRunning = true;
	public bool PlayPressed = false;
	public bool MaximumSpeed = false;
	public bool Continue = false;
	public bool Level1 = true;
	public bool Dead = false;
	public bool StopSubs = false;
	public Transform MainCamera;
	public Transform Player;
	public Transform Submarine;
	public Transform Pause;
	public Transform Bubbles1;
	public Transform Bubbles2;
	public Transform Bubbles3;
	public Transform SoundManager;
	public Transform Banner;
	
	void Update (){
		transform.Translate (Vector2.up * speed * Time.deltaTime);
		//If Sub continues or stops to switch camera
		if (Level1 == true && Dead == false) {
			if (Continue == false) {
				if (MenuRunning == true && PlayPressed == true) {
					if (WaterHit == false) {
						speed = speed - 0.03f; //Falling Speed
						if (WaterTimer < HitWater) {
							WaterTimer = WaterTimer + 1;
						} else if (WaterTimer >= HitWater) {
							WaterHit = true;
						}
					} else if (WaterHit == true) {
						if (speed < 0.3f && WaterStop == false) { //Target speed when water is hit
							speed = speed + 0.04f; // Stopping Speed
						} else {
							WaterStop = true;
							if (speed > -0.3f && WaterDrop == false) {//Target speed when in water
								speed = speed - 0.005f; // Water speed
							} else if (speed <= -0.3f) {
								WaterDrop = true;
							}
						}
						if (timer1 < TargetSwitchTime) { //Time to switch the camera target
							timer1 = timer1 + 1f;
						} else if (timer1 >= TargetSwitchTime) {
							if (speed < 0) { // Target speed to switch camera
								speed = speed + 0.001f;//Slow down sub for switch
							} else if (speed >= 0) {
								speed = 0f;//Switch speed
								if (timer2 < StopSwitchTime) {
									timer2 = timer2 + 1;
								} else if (timer2 >= StopSwitchTime) {
									MenuRunning = false;
									MainCamera.GetComponent<CameraFollow> ().Menu = false;
									Player.GetComponent<Player> ().Menu = false;
									Player.GetComponent<PlayerShoot> ().Menu = false;
									Banner.GetComponent<DepthPopups> ().Menu = false;
									Pause.GetComponent<Pause> ().Menu = false;
									SoundManager.GetComponent<MainMusica>().Menuy = false;
									Bubbles1.GetComponent<SubBubbles> ().Menu = false;
									Bubbles2.GetComponent<SubBubbles> ().Menu = false;
									Bubbles3.GetComponent<SubBubbles> ().Menu = false;
								}	
							}
						}
					}
				}
				if (MenuRunning == false && Dead == false) {
					if (speed > NormalSpeed && MaximumSpeed == false) {//Bring sub to normal speed
						speed = speed - 0.002f; // Sink sub
					} else if (speed <= NormalSpeed && MaximumSpeed == false) {
						MaximumSpeed = true;
						speed = NormalSpeed; // Target speed
					}
				}
				
				
				
				
				//If Sub stops or continues to switch camera
			} else if (Continue == true) {
				if (MenuRunning == true && PlayPressed == true) {
					if (WaterHit == false) {
						speed = speed - 0.03f; // Sub falling speed
						if (WaterTimer < HitWater) {
							WaterTimer = WaterTimer + 1;
						} else if (WaterTimer >= HitWater) {
							WaterHit = true;
						}
					} else if (WaterHit == true) {
						if (speed < 0.3f && WaterStop == false) { // Target water hit speed
							speed = speed + 0.04f; // Water hit speed
						} else {
							WaterStop = true;
							if (speed > -0.3f && WaterDrop == false) { // Target water sink
								speed = speed - 0.005f; // Sink sub
							} else if (speed <= -0.3f) {
								WaterDrop = true;
							}
						}
						if (timer1 < TargetSwitchTime) { // Time to switch Camera
							timer1 = timer1 + 1f;
						} else if (timer1 >= TargetSwitchTime) {
							MenuRunning = false;
							MainCamera.GetComponent<CameraFollow> ().Menu = false;
							Player.GetComponent<Player> ().Menu = false;
							Player.GetComponent<PlayerShoot> ().Menu = false;
							Banner.GetComponent<DepthPopups> ().Menu = false;
							Pause.GetComponent<Pause> ().Menu = false;
							SoundManager.GetComponent<MainMusica>().Menuy = false;
							Bubbles1.GetComponent<SubBubbles> ().Menu = false;
							Bubbles2.GetComponent<SubBubbles> ().Menu = false;
							Bubbles3.GetComponent<SubBubbles> ().Menu = false;
						}
					}
				}
			}
			if (MenuRunning == false && Dead == false) {
				if (speed > NormalSpeed && MaximumSpeed == false) { // Target sink speed
					speed = speed - 0.002f; // sink sub
				} else if (speed <= NormalSpeed && MaximumSpeed == false) {
					MaximumSpeed = true;
					speed = NormalSpeed; // Target speed
				}
			}
			
		} else if (Dead == true && StopSubs == false) {
			if(speed < 0){
				speed = speed + 0.02f;
			} else if(speed >= 0){
				speed = 0;
			}
		} else  if(StopSubs == false && Dead == false){
			if (speed > NormalSpeed && MaximumSpeed == false) { // Target sink speed
				speed = speed - 0.002f; // sink sub
			} else if (speed <= NormalSpeed && MaximumSpeed == false) {
				MaximumSpeed = true;
				speed = NormalSpeed; // Target speed
			}
		} else if(StopSubs == true){
			speed = 0f;
		}
	}
}
