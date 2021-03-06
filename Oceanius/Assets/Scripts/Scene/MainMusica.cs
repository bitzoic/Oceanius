using UnityEngine;
using System.Collections;

public class MainMusica : MonoBehaviour {

	public bool Menuy = true;
	public bool RunOnce = false;
	public bool SubDead = false;
	public AudioSource MenuMusic;
	public AudioSource MainMusic;
	public bool EasterEgg = false;

	void Update () {
		if (Menuy == false && RunOnce == false) {
			MenuMusic.mute = true;
			MenuMusic.enabled = false;
			MainMusic.enabled = true;
			RunOnce = true;
		}
		if (SubDead == true) {
			MainMusic.mute = true;
			MainMusic.enabled = false;
		}
		if(EasterEgg == true){
			MainMusic.mute = true;
			MainMusic.enabled = false;
		}
	}
}
