using UnityEngine;
using System.Collections;

public class Next4 : MonoBehaviour {

	public Canvas Info;
	public Canvas NextButtons;
	public Canvas MainMenu;
	public GameObject Next1;
	public GameObject Next2;
	public GameObject Next3;
	public GameObject Next41;
	public GameObject Info1;
	public GameObject Info2;
	public GameObject Info3;
	public GameObject Info4;
	public Transform MainCamera;
	public SpriteRenderer Shark;
	public SpriteRenderer Playery;
	
	public void Next14(int index){
		Info.enabled = false;
		Next1.SetActive (false);
		Info1.SetActive (false);
		Next2.SetActive (false);
		Next3.SetActive (false);
		Next41.SetActive (false);
		Info2.SetActive (false);
		Info3.SetActive (false);
		Info4.SetActive (false);
		Shark.enabled = false;
		Playery.enabled = false;
		MainMenu.enabled = true;
		MainCamera.GetComponent<CameraFollow> ().Help4 = false;
	}
}
