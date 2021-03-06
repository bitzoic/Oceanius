using UnityEngine;
using System.Collections;

public class CreditsButton : MonoBehaviour {

	public Canvas MainMenu;
	public Canvas NextButton;
	public Canvas Info;
	public GameObject Next1;
	public GameObject Next2;
	public GameObject Next3;
	public GameObject Next4;
	public GameObject Info1;
	public GameObject Info2;
	public GameObject Info3;
	public GameObject Info4;
	public Transform MainCamera;
	public SpriteRenderer Playery;

	void Start(){
		NextButton.enabled = false;
		Info.enabled = false;
	}
	
	public void Credits(int index){
		MainMenu.enabled = false;
		NextButton.enabled = true;
		Playery.enabled = true;
		Info.enabled = true;
		Next1.SetActive (true);
		Info1.SetActive (true);
		Next2.SetActive (false);
		Next3.SetActive (false);
		Next4.SetActive (false);
		Info2.SetActive (false);
		Info3.SetActive (false);
		Info4.SetActive (false);
		MainCamera.GetComponent<CameraFollow> ().Help1 = true;
	}
}
