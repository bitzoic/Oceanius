using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour
{

		public Canvas Loading;
		public SpriteRenderer CutScene;
		public bool Load = false;
		public float Timer = 0;
		public float Timer2 = 0;
		public float CutSceneDuration = 0;
		public float LoadingDuration = 0;
		public string scene;
		private Animator anim;

		void Start ()
		{
				anim = gameObject.GetComponent<Animator> ();
				Screen.showCursor = false;
		}

		void Update ()
		{
				if (Timer < LoadingDuration && Load == false) {
						Timer = Timer + 1;
				} else if (Timer >= LoadingDuration) {
						Timer = 0;
						Load = true;
						Loading.enabled = false;
				}

				if (Load == true) {
						CutScene.enabled = true;
						anim.SetInteger ("state", 1);
						if (Timer2 < CutSceneDuration) {
								Timer2 = Timer2 + 1;
						} else if (Timer2 >= CutSceneDuration) {
								CutScene.enabled = false;
								Loading.enabled = true;
								Application.LoadLevel (scene);
						}
				}
		}
}
