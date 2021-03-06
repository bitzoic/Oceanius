using UnityEngine;
using System.Collections;

public class SubHealth : MonoBehaviour {

	public float StartingHealth = 100f;
	public float CurrentHealth;
	public float DamageSmallBullet = 0.5f;
	public float DamageBigBullet = 2f;
	public float DamageMelee = 1f;
	public float HealthIncrease = 30f;
	public float Timer = 0;
	public AudioSource SubAudio;
	public AudioSource SubDeath;
	public Transform Player;
	public Transform Submarine;
	public Transform Window;
	public Transform MainCamera;
	public Transform KeepPlayer;
	public string scene;
	public Canvas Death;
	public bool PlayOnce = false;
	public ParticleSystem Debris1;
	public ParticleSystem Debris2;
	public ParticleSystem Debris3;
	public ParticleSystem Debris4;

	public Texture2D bgTexture;
	public Texture2D airBarTexture;
	public Texture2D HealthTexture;
	public int iconWidth = 212;
	public Vector2 airOffset = new Vector2 (10, 10);
	//public Slider HealthSlider;
	
	void Start () {
		CurrentHealth = StartingHealth;
		Death.enabled = false;
	}

	void Update () {
		Submarine.GetComponent<SubAnimation> ().Health = CurrentHealth;
		Window.GetComponent<SubWindowAnimation> ().Health = CurrentHealth;
		if (CurrentHealth <= 0) {
			Debris1.emissionRate = 3;
			Debris2.emissionRate = 2;
			Debris3.emissionRate = 3;
			Debris4.emissionRate = 4;
			Submarine.GetComponent<SinkSub>().Dead = true;
			Window.GetComponent<SubWindowAnimation>().Dead = true;
			MainCamera.GetComponent<CameraFollow>().Dead = true;
			Player.GetComponent<Player>().Dead = true;
			Submarine.GetComponent<SubAnimation>().Dead = true;
			KeepPlayer.GetComponent<StayNearSubUI>().Dead = true;
			Death.enabled = true;
			SubAudio.mute = true;
			SubDeath.enabled = true;
			if(Timer < 210){
				Timer = Timer + 1;
			} else if(Timer >= 210){
				Application.LoadLevel(scene);
			}
		}
	}

	public void AddHealth(){
		if (CurrentHealth >= 71) {
			var HealthNeeded = (CurrentHealth - 100) * -1;
			CurrentHealth = CurrentHealth + HealthNeeded;
		} else if (CurrentHealth <= 70) {
			CurrentHealth = CurrentHealth + HealthIncrease;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "EnemyBulletSmall") {
					CurrentHealth = CurrentHealth - DamageSmallBullet;
				}
		if (col.gameObject.tag == "EnemyBulletBig") {
					CurrentHealth = CurrentHealth - DamageBigBullet;
				}
		if (col.gameObject.tag == "EnemyMelee") {
						if (!col.GetComponent<EnemyWholeAnimation> ().Clean) {
								CurrentHealth = CurrentHealth - DamageMelee;
						}
				}
	}
	void OnGUI(){
		if (!Submarine.GetComponent<SinkSub> ().MenuRunning) {
						var percent = Mathf.Clamp01 (CurrentHealth / StartingHealth);
		
						DrawMeter (airOffset.x, airOffset.y, HealthTexture, airBarTexture, percent);
				}
	}
	
	void DrawMeter(float x, float y, Texture2D texture, Texture2D background, float percent){
		if (!Submarine.GetComponent<SinkSub> ().MenuRunning) {
						var bgW = background.width;
						var bgH = background.height;
		
						GUI.DrawTexture (new Rect (x, y, bgW, bgH), background);
		
						var nW = ((bgW - iconWidth) * percent) + iconWidth;
		
						GUI.BeginGroup (new Rect (x, y, nW, bgH));
						GUI.DrawTexture (new Rect (0, 0, bgW, bgH), texture);
						GUI.EndGroup ();
				}
	}
}
