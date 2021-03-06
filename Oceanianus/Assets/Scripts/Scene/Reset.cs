using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {

	public string scene;

	public void RestScene(int index){
		Application.LoadLevel(scene);
		Time.timeScale = 1;
	}
}
