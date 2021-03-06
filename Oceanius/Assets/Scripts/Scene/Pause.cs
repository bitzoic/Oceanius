using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	public Canvas PauseCanvas;
	public bool Menu = true;

	void Start(){
		PauseCanvas.enabled = false;
		}

	void Update () {
		if (Input.GetKeyUp(KeyCode.Escape) && Menu == false){
			StartCoroutine(togglePause());
		}
	}

	public void PauseButton(int index){
		StartCoroutine (togglePause ());
	}

	IEnumerator togglePause(){
		if(Time.timeScale <= 0){
			PauseCanvas.enabled = false;
			Time.timeScale = 1;
			yield return new WaitForSeconds(0.5f);
		} else if(Time.timeScale >= 1){
			PauseCanvas.enabled = true;
			Time.timeScale = 0;
			yield return new WaitForSeconds(0.5f);
		}
	}
}
