using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {

	public Transform Player;
	public Transform MainCamera;
	public Transform Submarine;
	public bool IfLevel4 = false;
	public float Timer = 0f;
	public string scene;
	public bool Triggered = false;
	public Canvas Load;

	void Start(){
		Load.enabled = false;
	}

	void Update(){
		if (IfLevel4 == true && Triggered == true) {
			if(Timer < 200){
				Timer = Timer + 1f;
			} else if( Timer >= 200){
				Load.enabled = true;
				Application.LoadLevel(scene);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Submarine") {
			Triggered = true;
			MainCamera.GetComponent<CameraFollow>().endScene = true;
			Player.GetComponent<Player>().Dead = true;
			if(IfLevel4 == true){
				MainCamera.GetComponent<CameraShake>().ShakeIt = true;
				Submarine.GetComponent<SinkSub>().StopSubs = true;
			} else {
				Load.enabled = true;
				Application.LoadLevel(scene);
			}
		}
	}
}
