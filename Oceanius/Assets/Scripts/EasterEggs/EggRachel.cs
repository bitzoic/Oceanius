using UnityEngine;
using System.Collections;

public class EggRachel : MonoBehaviour {

	public bool Rach1 = false;
	public bool Rach2 = false;
	public bool Rach3 = false;
	public bool Rach4 = false;
	public bool playmusic = false;
	public ParticleSystem particlesystem;
	public AudioClip Music;
	public AudioSource MainMusic;
	public float timer = 0;
	public Transform musicsource;
	
	void Update () {
		if (Input.GetKey (KeyCode.R)) {
			Rach1 = true;
		} else {
			Rach1 = false;
		}
		if(Input.GetKey(KeyCode.A) && Rach1 == true){
			Rach2 = true;
		} else {
			Rach2 = false;
		}
		if(Input.GetKey(KeyCode.C) && Rach2 == true){
			Rach3 = true;
		} else {
			Rach3 = false;
		}
		if(Input.GetKey(KeyCode.H) && Rach3 == true){
			Rach4 = true;
		}
		
		if (Rach4 == true) {
			MainMusic.mute = true;
			particlesystem.emissionRate = 30;
			if(playmusic == false){
				PlayMusic();
				playmusic = true;
			} else if(playmusic == true){
				if(timer < 13020){
					timer = timer + 1;
				} else if(timer >= 13020){
					timer = 0;
					playmusic = false;
				}
			}
		}
	}
	void PlayMusic(){
		if (Music)
			musicsource.GetComponent<MainMusica>().EasterEgg = true;
			AudioSource.PlayClipAtPoint (Music, transform.position);
	}
}
