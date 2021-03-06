using UnityEngine;
using System.Collections;

public class PlayGameButton : MonoBehaviour {

	public Transform Submarine;
	public Transform MainCamera;
	public Transform SoundManager;
	public Canvas MainMenuCanvas;
	public SpriteRenderer Playery;
	
	public void PlayGame(int index){
		MainCamera.GetComponent<CameraFollow> ().PlayPressed = true;
		Submarine.GetComponent<SinkSub> ().PlayPressed = true;
		SoundManager.GetComponent<MainMusica> ().Menuy = false;
		MainMenuCanvas.enabled = false;
		Playery.enabled = true;
	}
}
