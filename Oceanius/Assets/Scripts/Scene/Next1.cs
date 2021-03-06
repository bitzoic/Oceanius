using UnityEngine;
using System.Collections;

public class Next1 : MonoBehaviour {
	
	public GameObject NextButton;
	public GameObject LastButton;
	public GameObject Info;
	public GameObject LastInfo;
	public Transform MainCamera;
	public SpriteRenderer Shark;
	public SpriteRenderer Playery;

	void Start(){
		Playery.enabled = false;
		Shark.enabled = false;
	}

	public void Next12(int index){
		NextButton.SetActive (true);
		LastButton.SetActive (false);
		LastInfo.SetActive (false);
		Info.SetActive (true);
		Shark.enabled = true;
		Playery.enabled = true;
		MainCamera.GetComponent<CameraFollow> ().Help1 = false;
		MainCamera.GetComponent<CameraFollow> ().Help2 = true;
	}
}
