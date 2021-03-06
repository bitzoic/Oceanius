using UnityEngine;
using System.Collections;

public class DepthPopups : MonoBehaviour
{

		public Canvas DepthCanvas;
		public float Timer = 0;
		public float Timer2 = 0;
		public float Timed = 3;
		public float Timed2 = 10;
		public bool Started = false;
		public bool Ran = false;
		public bool Menu = false;

	void Start(){
		DepthCanvas.enabled = false;
	}

		void Update ()
		{
				if (Menu == false) {
						if (Started == false && Ran == false) {
								Timer += Time.deltaTime;
								if (Timer > Timed) {
										Timer -= Timed;
										Timer = 0;
										Started = true;
										DepthCanvas.enabled = true;
								}
						} else if (Started == true && Ran == false) {
								Timer2 += Time.deltaTime;
								if (Timer2 > Timed2) {
										Timer2 -= Timed2;
										Timed2 = 0;
										DepthCanvas.enabled = false;
										Ran = true;
								}
						}
				}
		}

}
