using UnityEngine;
using System.Collections;

public class mortePersonagem : MonoBehaviour {

	public GameObject UIDerrota;
	public float intensidadeCameraShake, tempoCameraShake;

	public AudioSource boomSound;

	void OnTriggerEnter(Collider other) {
		if (PlayerPrefs.HasKey ("best")) {
			int oldbest = PlayerPrefs.GetInt ("best");
			if (oldbest < ControladorColunas.pontuacao) {
				PlayerPrefs.SetInt ("best", (int)ControladorColunas.pontuacao);
			}
		} else {
			PlayerPrefs.SetInt ("best", 0);
		}


		emitParticlesAndDisappear (other.gameObject);

		if (UIDerrota != null) {
			UIDerrota.transform.GetComponent<UIMenuDeDerrota> ().Derrota ();
		} else {
			Debug.LogError("Não há UIDerrota aqui");
		}
	}

	void emitParticlesAndDisappear(GameObject thePlayer){
		//emite particulas de morte
		GameObject.Find ("bgm").GetComponent<AudioSource> ().Stop ();
		Transform deathParticleTransform = GameObject.Find ("deathParticle").transform;
		deathParticleTransform.position = thePlayer.transform.position;
		thePlayer.SetActive (false);
		ParticleSystem theSystem = deathParticleTransform.GetComponent<ParticleSystem> ();
		Color randomColorForParticle = theSystem.startColor;
		randomColorForParticle.b = Random.Range (0, 1f);
		randomColorForParticle.g = Random.Range (0, 1f);
		theSystem.startColor = randomColorForParticle;
		theSystem.Emit (128);
		boomSound.Play ();
		TelaFlashBranco.instancia.PiscaFade (Color.black, 4.5f, true);

		Camera.main.GetComponent<CameraScreenShake> ().ShakeScreen (intensidadeCameraShake, tempoCameraShake);

		GameObject.Find ("Controlador Das Colunas").GetComponent<ControladorColunas> ().enabled = false;
	}

}