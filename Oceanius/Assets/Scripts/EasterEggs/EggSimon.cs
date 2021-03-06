using UnityEngine;
using System.Collections;

public class EggSimon : MonoBehaviour {

	public bool Rach1 = false;
	public bool Rach2 = false;
	public bool Rach3 = false;
	public bool Rach4 = false;
	public bool Rach5 = false;
	public bool playmusic = false;
	public AudioClip Music;
	public AudioSource MainMusic;
	public float timer = 0;
	public float MusicTime = 3540f;
	public Transform musicsource;
	public Texture2D Image;

	private int drawDepth = -1000;

	void Update () {
		if (Input.GetKey (KeyCode.S)) {
			Rach1 = true;
		} else {
			Rach1 = false;
		}
		if(Input.GetKey(KeyCode.I) && Rach1 == true){
			Rach2 = true;
		} else {
			Rach2 = false;
		}
		if(Input.GetKey(KeyCode.M) && Rach2 == true){
			Rach3 = true;
		} else {
			Rach3 = false;
		}
		if(Input.GetKey(KeyCode.O) && Rach3 == true){
			Rach4 = true;
		} else {
			Rach4 = false;
		}
		if(Input.GetKey(KeyCode.N) && Rach4 == true){
			Rach5 = true;
		}
		
		if (Rach5 == true) {
			MainMusic.mute = true;
			if(playmusic == false){
				PlayMusic();
				playmusic = true;
			} else if(playmusic == true){
				if(timer < MusicTime){
					timer = timer + 1;
				} else if(timer >= MusicTime){
					timer = 0;
					playmusic = false;
				}
			}
		}
	}

	void OnGUI(){
				if (Rach5 == true) {
						GUI.depth = drawDepth;		
						GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), Image);
				}
		}


	void PlayMusic(){
		if (Music)
			musicsource.GetComponent<MainMusica>().EasterEgg = true;
			AudioSource.PlayClipAtPoint (Music, transform.position);
	}
}
