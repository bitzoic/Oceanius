using UnityEngine;
using System.Collections;

public class Egg32030329 : MonoBehaviour {

	public bool number1 = false;
	public bool number2 = false;
	public bool number3 = false;
	public bool number4 = false;
	public bool number5 = false;
	public bool number6 = false;
	public bool number7 = false;
	public bool number8 = false;
	public bool playmusic = false;
	public float timer1 = 0f;
	public float timer2 = 0f;
	public float timer3 = 0f;
	public float timer4 = 0f;
	public float timer5 = 0f;
	public float timer6 = 0f;
	public float timer7 = 0f;
	public float timer8 = 0f;
	public float timer = 0;
	public float MusicTime = 3540f;
	public AudioClip Music;
	public AudioSource MainMusic;
	public Transform musicsource;
	
	void Update () {
		//3
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			number1 = true;
		}
		if (number1 == true) {
			if(timer1 < 500){
				timer1 = timer1 + 1f;
			} else if (timer1 >= 500){
				number1 = false;
				timer1 = 0;
			}
		}
		//2
		if (Input.GetKeyDown (KeyCode.Alpha2) && number1 == true) {
			number2 = true;
		}
		if (number2 == true) {
			if(timer2 < 500){
				timer2 = timer2 + 1f;
			} else if (timer2 >= 500){
				number2 = false;
				timer2 = 0;
			}
		}
		//0
		if (Input.GetKeyDown (KeyCode.Alpha0) && number2 == true) {
			number3 = true;
		}
		if (number3 == true) {
			if(timer3 < 500){
				timer3 = timer3 + 1f;
			} else if (timer3 >= 500){
				number3 = false;
				timer3 = 0;
			}
		}
		//3
		if (Input.GetKeyDown (KeyCode.Alpha3) && number3 == true) {
			number4 = true;
		}
		if (number4 == true) {
			if(timer4 < 500){
				timer4 = timer4 + 1f;
			} else if (timer4 >= 500){
				number4 = false;
				timer4 = 0;
			}
		}
		//0
		if (Input.GetKeyDown (KeyCode.Alpha0) && number4 == true) {
			number5 = true;
		}
		if (number5 == true) {
			if(timer5 < 500){
				timer5 = timer5 + 1f;
			} else if (timer5 >= 500){
				number5 = false;
				timer5 = 0;
			}
		}
		//3
		if (Input.GetKeyDown (KeyCode.Alpha3) && number5 == true) {
			number6 = true;
		}
		if (number6 == true) {
			if(timer6 < 500){
				timer6 = timer6 + 1f;
			} else if (timer6 >= 500){
				number6 = false;
				timer6 = 0;
			}
		}
		//2
		if (Input.GetKeyDown (KeyCode.Alpha2) && number6 == true) {
			number7 = true;
		}
		if (number7 == true) {
			if(timer7 < 500){
				timer7 = timer7 + 1f;
			} else if (timer7 >= 500){
				number7 = false;
				timer7 = 0;
			}
		}
		//9
		if (Input.GetKeyDown (KeyCode.Alpha9) && number7 == true) {
			number8 = true;
		} 
		//EGG!
		if (number8 == true) {
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
	void PlayMusic(){
		if (Music)
			musicsource.GetComponent<MainMusica>().EasterEgg = true;
		AudioSource.PlayClipAtPoint (Music, transform.position);
	}
	}
