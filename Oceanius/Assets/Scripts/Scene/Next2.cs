using UnityEngine;
using System.Collections;

public class Next2 : MonoBehaviour {

	public GameObject NextButton;
	public GameObject LastButton;
	public GameObject Info;
	public GameObject LastInfo;
	public Transform MainCamera;
	

	public void Next22(int index){
		NextButton.SetActive (true);
		LastButton.SetActive (false);
		LastInfo.SetActive (false);
		Info.SetActive (true);
		MainCamera.GetComponent<CameraFollow> ().Help2 = false;
		MainCamera.GetComponent<CameraFollow> ().Help3 = true;
	}
}
