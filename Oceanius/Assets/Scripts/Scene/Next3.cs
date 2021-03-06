using UnityEngine;
using System.Collections;

public class Next3 : MonoBehaviour {

	public GameObject NextButton;
	public GameObject LastButton;
	public GameObject Info;
	public GameObject LastInfo;
	public Transform MainCamera;



	public void Next32(int index){
		NextButton.SetActive (true);
		LastButton.SetActive (false);
		LastInfo.SetActive (false);
		Info.SetActive (true);
		MainCamera.GetComponent<CameraFollow> ().Help3 = false;
		MainCamera.GetComponent<CameraFollow> ().Help4 = true;
	}
}
