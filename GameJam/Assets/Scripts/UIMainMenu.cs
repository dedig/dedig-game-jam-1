using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour {

	public GameObject pauseMenu, scoreCanvas;
	public GameObject somHabilitado, somDesabilitado;
	static bool audioHabilitado = true;
	float posicaoTexto = 1.0f;


	void Start(){
		// Validação de menu de pausa
		if (pauseMenu == null) {
			Debug.LogError("Está faltando um gameobject");
			Debug.Break();
		}
	}

	public void IniciaJogo(){
		scoreCanvas.SetActive (true);
		pauseMenu.SetActive (true);
		gameObject.SetActive (false);
	}

	public void AlternarSom(){
		if (audioHabilitado) {
			AudioListener.volume = 0;
			audioHabilitado = false;
			somHabilitado.SetActive(false);
			somDesabilitado.SetActive(true);
		} else {
			AudioListener.volume = 1;
			audioHabilitado = true;
			somHabilitado.SetActive(true);
			somDesabilitado.SetActive(false);
		}
	}
}
