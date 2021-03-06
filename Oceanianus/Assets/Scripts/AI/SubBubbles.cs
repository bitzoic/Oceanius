using UnityEngine;
using System.Collections;

public class SubBubbles : MonoBehaviour {

	public ParticleSystem Particle;
	public bool Menu = true;
	public float Rate = 1;

	void Update () {
	if (Menu == true) {
				Particle.emissionRate = 0;
		} else if (Menu == false) {
			Particle.emissionRate = Rate;
		}
	} 
}
