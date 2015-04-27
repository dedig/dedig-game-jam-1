using UnityEngine;
using System.Collections;

public class UIMainMenu : MonoBehaviour {

	public GameObject pauseMenu;
	public GameObject somHabilitado, somDesabilitado;
	static bool audioHabilitado = true;

	void Start(){
		// Validação de menu de pausa
		if (pauseMenu == null) {
			Debug.LogError("Não há ligação com o menu de pausa");
			Debug.Break();
		}
	}

	public void IniciaJogo(){
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
