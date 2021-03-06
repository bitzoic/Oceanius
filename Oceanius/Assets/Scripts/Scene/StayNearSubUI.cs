using UnityEngine;
using System.Collections;

public class StayNearSubUI : MonoBehaviour
{

		public Canvas PopUp;
		public Canvas Flashing;
		public bool Enabled = false;
		public bool Dead = false;
		public float Timer = 0;
		public float Timer2 = 0;
		public float Timed = 10;
		public float Timed2 = 10;

		// Use this for initialization
		void Start ()
		{
				PopUp.enabled = false;
				Flashing.enabled = false;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Enabled == true && Dead == false) {

						if (Timer < Timed) {
								Timer = Timer + 1;
								Flashing.enabled = false;
						} else if (Timer <= Timed) {
								Flashing.enabled = true;
								if (Timer2 < Timed2) {
										Timer2 = Timer2 + 1;
								} else if (Timer2 <= Timed2) {
										Timer2 = 0;
										Timer = 0;
								}
						}

						PopUp.enabled = true;
				} else if (Enabled == false) {
						PopUp.enabled = false;
						Flashing.enabled = false;
				}
		}

		void OnTriggerEnter2D (Collider2D col)
		{
				if (col.gameObject.tag == "Player") {
						Enabled = true;
				}
		}
}
